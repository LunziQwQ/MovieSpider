using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider {
    class FIleManager {
        private string rootPath =                   //缓存的根目录绝对路径
            @"C:\User\Public\Documents\MovieCache\";
        //private string categoryPath = "\\";       //根目录下的分类文件夹名
        //private string namePath = "\\";           //以电影名为名的文件夹
        private string finalPath;                   //电影储存的绝对路径
        private static FIleManager instance;
        public static FIleManager getInstance() {
            if (instance == null)
                instance = new FIleManager();
            return instance;
        }

        /// <summary>
        /// 设置电影储存的目录
        /// </summary>
        /// <param name="movie"></param>
        public void setPath(MovieItem movie) {
             finalPath = rootPath + movie.Category + "\\" + movie.Name;
        }
    }
}
