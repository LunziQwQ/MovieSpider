using System;
using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Spider {
    class NetSpider {

        //爬虫的目标网站
        public static string SourceURL = @"http://66ys.cc";

        //网络是否连通
        public bool isNetStatusOK;

        //初始化正则规则
        private const RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline;

        //指定固定文字编码
        private Encoding code = Encoding.GetEncoding("GB2312");

        //待爬取的电影URL队列
        private List<string> toGrabURLs = new List<string>();

        //需要用到的实例
        public PageVisitor pageVisitor = new PageVisitor();
        public MainForm mainForm;
        public System.Windows.Forms.Label label_count;

        /// <summary>
        /// 开始运行爬虫，爬取结果存到本地，运行成功会弹出finish消息。
        /// 深度决定队列数量，通过队列每次更新_nowHTML地址并爬取对应数据。
        /// </summary>
        /// <param name="deep">爬虫运行的深度</param>
        /// <param name="interval">每次请求的间隔时间</param>
        public void startGrab(int deep, int interval) {
            _nowHTML = pageVisitor.getHtmlTextByURL(@"http://www.dygang.com/ys/", code);
            while (toGrabURLs.Count < deep) {
                addMovieURLsFromNowPage();
                _nowHTML = pageVisitor.getHtmlTextByURL(getNextPageURL(), code);
            }
            int count = 0;
            foreach (string x in toGrabURLs) {
                MovieItem temp = getOneMovie(pageVisitor.getHtmlTextByURL(x, code));
                if (temp.name != "NoName") {
                    MovieDB.getInstance().addItemFromNet(temp);
                    label_count.Text = (Int32.Parse(label_count.Text) + 1).ToString();
                }
                count++;
                if (count % 10 == 0) mainForm.updateUsage();
                if (count >= deep) break;
                System.Threading.Thread.Sleep(interval);
            }
            System.Windows.Forms.MessageBox.Show("Finish!");
        }

        /// <summary>
        /// 向目标URL发起ping命令测试网络连通性
        /// </summary>
        /// <returns>目标网址是否正常连接</returns>
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

        /// <summary>
        /// 通过正则获取字段，初始化为一个MovieItem实例。
        /// 更新_nowHTML并运行所有正则，开始爬取。
        /// </summary>
        /// <param name="movieHTML"></param>
        /// <returns>_nowHTML所爬取到的Movie</returns>
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
            movie.downloadLink = getDownloadLink();
            return movie;
        }

        #region Spider by Regex
        //正则所要爬取的当前URL
        private string _nowHTML;

        /// <summary>
        /// 获取正则表达式所匹配到的第一个字段。匹配不到时返回“”，空字符串。
        /// 简化代码的封装方法。
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        /// <returns>匹配到的第一个字段</returns>
        private string getFirstRegex(string pattern) {
            Regex regex = new Regex(pattern, options);
            return (regex.IsMatch(_nowHTML)) ? regex.Matches(_nowHTML)[0].Groups[1].Value : "";
        }

        /// <summary>
        /// 获取正则表达式所匹配到的Matches,匹配不到时返回null。
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        /// <returns>匹配到的matches</returns>
        private MatchCollection getMoreMatches(string pattern) {
            Regex regex = new Regex(pattern, options);
            return (regex.IsMatch(_nowHTML)) ? regex.Matches(_nowHTML) : null;
        }

        /// <summary>
        /// 剔除html中常见的无用字符
        /// </summary>
        /// <param name="str">要剔除无用文本的字符串</param>
        /// <returns>完成剔除的字符串</returns>
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

        /// <summary>
        /// 通过正则表达式获取片名，匹配失败返回“NoName”。
        /// 匹配片名并去除可能会导致windows以片名存储文件失败的字符。
        /// </summary>
        /// <returns>匹配出的片名</returns>
        private string getName() {
                string result = getFirstRegex(@"片\s+名\s*(.*?)<")
                .Replace("/", "")
                .Replace("\\", "")
                .Replace(":","");
            return result == "" ? "NoName" : doReplace(result);
        }

        /// <summary>
        /// 获取类别，匹配失败返回“default”。
        /// </summary>
        /// <returns>匹配出的类别</returns>
        private string getCategory() {
            MatchCollection matches = getMoreMatches(@"类\s+别.*");
            if(matches == null) return "default";
            string result = matches != null ? matches[0].Value : "default";
            return doReplace(result.Substring(5, result.Length - 5)).Substring(0,2);
        }

        
        /// <summary>
        /// 获取影片的IMDB评分，若为空，试图匹配豆瓣评分，全部匹配失败返回“”，空字符串。
        /// </summary>
        /// <returns>匹配出的豆瓣或IMDB评分</returns>
        private string getIMDB() {
            string DB = getFirstRegex(@"豆瓣评分.?\s*(.*?)\/10");
            string IMDB = getFirstRegex(@"IMDb评分&nbsp;\s*(.*?)\/10");
            return (IMDB == "") ? IMDB : DB;
        }

        /// <summary>
        /// 获取影片的ED2K下载链接，若为空，试图匹配网盘链接及密码，全部匹配失败返回Error信息。
        /// "Error: Can't find download link."
        /// </summary>
        /// <returns>匹配出的下载链接</returns>
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

        /// <summary>
        /// 获取主演名单，逐个匹配并处理无用字符，若匹配失败返回“”，空字符串。
        /// </summary>
        /// <returns>匹配出的主演名单</returns>
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

        //获取国家
        private string getArea() {
            return doReplace(getFirstRegex(@"国\s+家.?\s*(.*?)<br"));
        }

        //获取译名
        private string getTransTerm() {
            return getFirstRegex(@"译\s+名.?\s*(.*?)<");
        }

        //获取年代
        private string getYear() {
            return getFirstRegex(@"年\s+代.?\s*(.*?)<");
        }

        //获取语言
        private string getLanguage() {
            return getFirstRegex(@"语\s+言.?\s*(.*?)<");
        }

        //获取影片时长
        private string getLength() {
            return doReplace(getFirstRegex(@"片\s+长.?\s*(.*?)<br"));
        }


        //获取字幕
        private string getSubtitle() {
            return getFirstRegex(@"字\s+幕.?\s*(.*?)<");
        }

        //获取影片简介
        private string getSummary() {
            return doReplace(getFirstRegex(@"简\s*介.*\s*(.*)<"));
        }

        //获取影片封面链接
        private string getImageLink() {
            return getFirstRegex(@"<img\s*src='(.{1,80})'\s*width=""120""\s*height=""150""\/>");
        }

        //获取下一页按钮链接
        private string getNextPageURL() {
            return getFirstRegex(@"<a\s*href=""(.{1,80})"">下一页<\/a>");
        }

        /// <summary>
        /// 将当前页的所有影片详情页URL加入待爬取队列。
        /// </summary>
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
