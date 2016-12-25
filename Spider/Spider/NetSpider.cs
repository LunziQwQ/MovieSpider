using System;
using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Spider {
    class NetSpider {
        public static string SourceURL = @"http://66ys.cc";
        public bool isNetStatusOK;
        public PageVisitor pageVisitor = new PageVisitor();
        private const RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline;
        private Encoding code = Encoding.GetEncoding("GB2312");
        private List<string> toGrabURLs = new List<string>();
        public MainForm mainForm;

        public void startGrab(int deep, int interval) {
            _nowHTML = pageVisitor.getHtmlTextByURL(@"http://www.dygang.com/ys/", code);
            while (toGrabURLs.Count < deep) {
                addMovieURLsFromNowPage();
                _nowHTML = pageVisitor.getHtmlTextByURL(getNextPageURL(), code);
            }
            int count = 0;
            foreach (string x in toGrabURLs) {
                MovieItem temp = getOneMovie(pageVisitor.getHtmlTextByURL(x, code));
                MovieDB.getInstance().addItemFromNet(temp);
                count++;
                mainForm.updateItemCount();
                if (count % 10 == 0) mainForm.updateUsage();
                if (count >= deep) break;
                System.Threading.Thread.Sleep(interval);
            }

        }

        public bool checkConnect() {
            Ping ping = new Ping();
            try {
                PingReply pingReply = ping.Send(SourceURL.Replace(@"http://", ""));
                isNetStatusOK = (pingReply.Status == IPStatus.Success);
                return isNetStatusOK;
            }catch(Exception e) {
                Debug.Print(e.Message);
                isNetStatusOK = false;
                return isNetStatusOK;
            }
        }

        public MovieItem getOneMovie(String movieHTML) {
            _nowHTML = movieHTML;
            MovieItem movie = new MovieItem();
            movie.name = getName();
            movie.translatedTerm = getTransTerm();
            movie.category = getCategory();
            movie.time = getYear();
            movie.language = getLanguage();
            movie.lengthOfFilm = getLength();
            movie.imdbScore = getIMDB();
            movie.subtitle = getSubtitle();
            movie.area = getArea();
            movie.leadingRole = getLeadingRole();
            movie.summary = getSummary();
            movie.coverURL = getImageLink();
            return movie;
        }

        #region Spider by Regex
        private string _nowHTML;
        private string getFirstRegex(string pattern) {
            Regex regex = new Regex(pattern, options);
            return (regex.IsMatch(_nowHTML)) ? regex.Matches(_nowHTML)[0].Groups[1].Value : "";
        }

        private MatchCollection getMoreMatches(string pattern) {
            Regex regex = new Regex(pattern, options);
            return (regex.IsMatch(_nowHTML)) ? regex.Matches(_nowHTML) : null;
        }

        private string doReplace(string str) {
            Regex r1 = new Regex(@"<a\s+([^>])+\s*>", options);
            Regex r2 = new Regex(@"<img\s+([^>])+\s*>", options);
            return
                r2.Replace(r1.Replace(str, ""), "")
                .Replace("<p>", "")
                .Replace("</a>", "")
                .Replace("<br />", "")
                .Replace("&nbsp;", "")
                .Replace("&middot;", "")
                .Replace("&rdquo;", "")
                .Replace("&ldquo;", "")
                .Replace("&hellip;", "")
                .Replace("nbsp;", "")
                .Replace("middot;", "")
                .Replace("rdquo;", "")
                .Replace("ldquo;", "")
                .Replace("hellip;", "");
        }

        private string getName() {
            return getFirstRegex(@"片\s+名\s*(.*?)<")
                .Replace("/", "")
                .Replace("\\", "");
        }

        private string getTransTerm() {
            return getFirstRegex(@"译\s+名.?\s*(.*?)<");
        }

        private string getCategory() {
            MatchCollection matches = getMoreMatches(@"类\s+别.*");
            string result = matches != null ? matches[0].Value : "default";
            return doReplace(result.Substring(5, result.Length - 5)).Substring(0,2);
        }

        private string getYear() {
            return getFirstRegex(@"年\s+代.?\s*(.*?)<");
        }

        private string getLanguage() {
            return getFirstRegex(@"语\s+言.?\s*(.*?)<");
        }

        private string getLength() {
            string result = getFirstRegex(@"片\s+长.?\s*(.*?)<br");
            return doReplace(result);
        }

        private string getIMDB() {
            string DB = getFirstRegex(@"豆瓣评分.?\s*(.*?)\/10");
            string IMDB = getFirstRegex(@"IMDb评分&nbsp;\s*(.*?)\/10");
            return (IMDB == "") ? IMDB : DB;
        }

        private string getDownloadLink() {
            MatchCollection matches = getMoreMatches(@"ed2k:.*""");
            if (matches != null)
                return matches[0].Value.Substring(0, matches[0].Value.Length - 1);
            else {
                string result = "";
                matches = getMoreMatches(@"http.*:\/\/pan\.baidu\.com.*""");
                if (matches != null) {
                    result += matches[0].Value.Substring(0, matches[0].Value.Length - 1);
                    result += "   BaiduYun's key:" + getFirstRegex(@"密码[：|:](.*?)<");
                    return result;
                } else {
                    return "Error: Can't find download link.";
                }
            }
        }

        private string getArea() {
            string result = getFirstRegex(@"国\s+家.?\s*(.*?)<br");
            return doReplace(result);
                
        }

        private string getSubtitle() {
            return getFirstRegex(@"字\s+幕.?\s*(.*?)<");
        }

        private string getLeadingRole() {
            MatchCollection matches = getMoreMatches(@"主\s*演[\s\S]*简\s*介");
            if (matches != null) {
                string 
                    result = "",
                    temp = matches[0].Value.Substring(4, matches[0].Value.Length - 4);
                Regex regex = new Regex(@"\s+(.*?)<", options);
                matches = regex.Matches(temp);
                for (int i = 0; i < matches.Count; i++) {
                    result += 
                        matches[i].Groups[1].Value
                        .Replace("&nbsp;", "")
                        .Replace("&middot;", "");
                }
                return result;
            } else {
                return "";
            }
        }

        private string getSummary() {
            return doReplace(getFirstRegex(@"简\s*介.*\s*(.*)<"));
        }

        private string getImageLink() {
            return getFirstRegex(@"<img\s*src='(.{1,80})'\s*width=""120""\s*height=""150""\/>");
        }

        private string getNextPageURL() {
            return getFirstRegex(@"<a\s*href=""(.{1,80})"">下一页<\/a>");
        }

        private void addMovieURLsFromNowPage() {
            MatchCollection matches = getMoreMatches(@"<a\s*href=(?:""(.*?)"")\s*target=""_blank""\s*class=""classlinkclass"">");
            if (matches != null) {
                foreach (Match x in matches) {
                    toGrabURLs.Add(x.Groups[1].Value);
                }
            }
        }
        #endregion
    }
}
