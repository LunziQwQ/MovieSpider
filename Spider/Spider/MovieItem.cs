using System.Text.RegularExpressions;
namespace Spider {
    public class MovieItem {
     
        public string 
            name,           //片名
            translatedTerm, //译名
            time,           //上映时间
            language,       //语言
            lengthOfFilm,   //片长
            imdbScore,      //IMDB评分
            subtitle,       //字幕
            leadingRole,    //主演
            summary,        //电影概括/简介
            area,           //国家/区域
            category,       //类别
            coverURL,       //缩略图URL
            downloadLink;   //下载链接

        public MovieItem(string name = "") {
            this.name = name;
        }

        /// <summary>
        /// 调用FileManager的储存方法将自身存储到本地，并下载封面文件。
        /// </summary>
        /// <returns>存储是否成功</returns>
        public bool save() {
            return FileManager.getInstance().saveMovieItem(this);
        }

        /// <summary>
        /// 将电影实例序列化为字符串。
        /// </summary>
        /// <returns>序列化字符串</returns>
        public string getMovieInfoString() {
            return name + "&!&" +
            translatedTerm + "&!&" +
            time + "&!&" +
            language + "&!&" +
            lengthOfFilm + "&!&" +
            imdbScore + "&!&" +
            subtitle + "&!&" +
            leadingRole + "&!&" +
            summary + "&!&" +
            area + "&!&" +
            category + "&!&" +
            coverURL + "&!&" +
            downloadLink;
        }

        /// <summary>
        /// 从字符串反序列化电影实例。
        /// </summary>
        /// <param name="movieInfo"></param>
        /// <returns>反序列化的对象</returns>
        public static MovieItem create(string movieInfo) {
            MovieItem tempItem = new MovieItem();
            string[] temp = Regex.Split(movieInfo, "&!&");
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
