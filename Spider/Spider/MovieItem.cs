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
        private string name;            //片名
        public string Name {
            set { name = value; }
            get { return name; }
        }

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
        public string Director{
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
        public MovieItem(string name, string translatedTerm  =null, string time = null,
            string language = null, string lengthOfFilm = null, string imdbScore = null,
            string director = null, string leadingRole = null, string summary = null,
            string area = null, string category = "default") {
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
        }

    }
}
