namespace Spider {
    /// <summary>
    /// 数据类：一部电影
    /// </summary>
    public class MovieItem {
        FileManager fileManager = FileManager.getInstance();
     

        public bool isDownload = false; //该项目是否被下载

        public string name;            //片名
        public string translatedTerm;  //译名
        public string time;            //上映时间
        public string language;        //语言
        public string lengthOfFilm;    //片长
        public string imdbScore;       //IMDB评分
        public string subtitle;        //字幕
        public string leadingRole;     //主演
        public string summary;         //电影概括/简介
        public string area;            //国家/区域
        public string category;        //类别
        public string coverURL;        //缩略图URL
        public string downloadLink;    //下载链接

        /// <summary>
        /// MovieItem的构造函数
        /// </summary>
        /// <param name="name">片名</param>
        /// <param name="translatedTerm">影片译名</param>
        /// <param name="time">上映时间</param>
        /// <param name="language">电影语言</param>
        /// <param name="lengthOfFilm">电影时长</param>
        /// <param name="imdbScore">IMDB评分</param>
        /// <param name="subtitle">字幕</param>
        /// <param name="leadingRole">主演</param>
        /// <param name="summary">概括/简介</param>
        /// <param name="area">地区/国家</param>
        /// <param name="cover">封面链接</param>
        public MovieItem(string name = "", string translatedTerm = "", string time = "",
            string language = "", string lengthOfFilm = "", string imdbScore = "",
            string subtitle = "", string leadingRole = "", string summary = "",
            string area = "", string category = "default", string cover = "", string downloadLink = "") {
            this.name = name;
            this.translatedTerm = translatedTerm;
            this.time = time;
            this.language = language;
            this.lengthOfFilm = lengthOfFilm;
            this.imdbScore = imdbScore;
            this.subtitle = subtitle;
            this.leadingRole = leadingRole;
            this.summary = summary;
            this.area = area;
            this.category = category;
            this.coverURL = cover;
            this.downloadLink = downloadLink;
        }

        public bool save() {
            return fileManager.saveMovieItem(this);
        }

        public string getMovieInfoString() {
            return name + "&" +
            translatedTerm + "&" +
            time + "&" +
            language + "&" +
            lengthOfFilm + "&" +
            imdbScore + "&" +
            subtitle + "&" +
            leadingRole + "&" +
            summary + "&" +
            area + "&" +
            category + "&" +
            coverURL + "&" +
            downloadLink;
        }

        public static MovieItem create(string movieInfo) {
            MovieItem tempItem = new MovieItem();
            string[] temp = movieInfo.Split('&');
            tempItem.name = temp[0];
            tempItem.translatedTerm = temp[1];
            tempItem.time = temp[2];
            tempItem.language = temp[3];
            tempItem.lengthOfFilm = temp[4];
            tempItem.imdbScore = temp[5];
            tempItem.subtitle = temp[6];
            tempItem.leadingRole = temp[7];
            tempItem.summary = temp[8];
            tempItem.area = temp[9];
            tempItem.category = temp[10];
            tempItem.coverURL = temp[11];
            tempItem.downloadLink = temp[12];
            return tempItem;
        }
    }
}
