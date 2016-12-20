using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider {
    /// <summary>
    /// 数据类：一部电影
    /// </summary>
    public class MovieItem {
        private string name;            //片名\
        FileManager fileManager = FileManager.getInstance();
        public string Name {
            set { name = value; }
            get { return name; }
        }

        public bool isDownload = false; //该项目是否被下载

        private string translatedTerm;  //译名
        public string TranslatedTerm {
            set { translatedTerm = value; }
            get { return translatedTerm; }
        }

        private string time;            //上映时间
        public string Time {
            set { time = value; }
            get { return time; }
        }

        private string language;        //语言
        public string Language {
            set { language = value; }
            get { return language; }
        }

        private string lengthOfFilm;    //片长
        public string LengthOfFilm {
            set { lengthOfFilm = value; }
            get { return lengthOfFilm; }
        }

        private string imdbScore;      //IMDB评分
        public string IMDBScore {
            set { imdbScore = value; }
            get { return imdbScore; }
        }

        private string director;        //导演
        public string Director {
            set { director = value; }
            get { return director; }
        }

        private string leadingRole;     //主演
        public string LeadingRole {
            set { leadingRole = value; }
            get { return leadingRole; }
        }

        private string summary;         //电影概括/简介
        public string Summary {
            set { summary = value; }
            get { return summary; }
        }

        private string area;            //国家/区域
        public string Area {
            set { area = value; }
            get { return area; }
        }

        private string category;        //类别
        public string Category {
            set { category = value; }
            get { return category; }
        }

        private string coverPath;
        public string CoverPath {
            set { coverPath = value; }
            get { return coverPath; }
        }

        private string downloadLink;
        public string DownloadLink {
            set { downloadLink = value; }
            get { return downloadLink; }
        }

        /// <summary>
        /// MovieItem的构造函数,除了片名和分类外，其他参数有默认值null，分类的默认值为default，片名无默认值
        /// </summary>
        /// <param name="name">片名</param>
        /// <param name="translatedTerm">影片译名</param>
        /// <param name="time">上映时间</param>
        /// <param name="language">电影语言</param>
        /// <param name="lengthOfFilm">电影时长</param>
        /// <param name="imdbScore">IMDB评分</param>
        /// <param name="director">导演</param>
        /// <param name="leadingRole">主演</param>
        /// <param name="summary">概括/简介</param>
        /// <param name="area">地区/国家</param>
        /// <param name="cover">封面链接</param>
        public MovieItem(string name = "", string translatedTerm = "", string time = "",
            string language = "", string lengthOfFilm = "", string imdbScore = "",
            string director = "", string leadingRole = "", string summary = "",
            string area = "", string category = "default", string cover = "", string downloadLink = "") {
            Name = name;
            TranslatedTerm = translatedTerm;
            Time = time;
            Language = language;
            LengthOfFilm = lengthOfFilm;
            IMDBScore = imdbScore;
            Director = director;
            LeadingRole = leadingRole;
            Summary = summary;
            Area = area;
            Category = category;
            CoverPath = cover;
            this.downloadLink = downloadLink;
        }

        public bool save() {
            return fileManager.saveMovieItem(this);
        }

        public string getMovieInfoString() {
            return Name + "&" +
            TranslatedTerm + "&" +
            Time + "&" +
            Language + "&" +
            LengthOfFilm + "&" +
            IMDBScore + "&" +
            Director + "&" +
            LeadingRole + "&" +
            Summary + "&" +
            Area + "&" +
            Category + "&" +
            CoverPath + "&" +
            downloadLink;
        }

        public static MovieItem create(string movieInfo) {
            MovieItem tempItem = new MovieItem();
            string[] temp = movieInfo.Split('&');
            tempItem.Name = temp[0];
            tempItem.TranslatedTerm = temp[1];
            tempItem.Time = temp[2];
            tempItem.Language = temp[3];
            tempItem.LengthOfFilm = temp[4];
            tempItem.IMDBScore = temp[5];
            tempItem.Director = temp[6];
            tempItem.LeadingRole = temp[7];
            tempItem.Summary = temp[8];
            tempItem.Area = temp[9];
            tempItem.Category = temp[10];
            tempItem.CoverPath = temp[11];
            tempItem.downloadLink = temp[12];
            return tempItem;
        }
    }
}
