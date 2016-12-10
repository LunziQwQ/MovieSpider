using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Spider {
    class FileManager {
        public static string rootPath =                   //缓存的根目录绝对路径
            @"C:\User\" + System.Environment.UserName + @"\Documents\MovieCache\";
        //private string categoryPath = "\\";       //根目录下的分类文件夹名
        //private string namePath = "\\";           //以电影名为名的文件夹
        private string finalPath;                   //电影储存的绝对路径
        private static FileManager instance;
        public static FileManager getInstance() {
            if (instance == null)
                instance = new FileManager();
            return instance;
        }

        /// <summary>
        /// 设置电影储存的目录
        /// </summary>
        /// <param name="movie"></param>
        public void setPath(MovieItem movie) {
             finalPath = rootPath + movie.Category + "\\" + movie.Name;
        }

        public string getPath(MovieItem movie) {
            return rootPath + movie.Category + "\\" + movie.Name;
        }

        private void createRootPathExist() {
            if (!Directory.Exists(rootPath))//如果不存在就创建file文件夹
                Directory.CreateDirectory(rootPath);
        }

        //删除该电影在本地的缓存文件
        public void deleteMovieItem(MovieItem movie) {
            string path = getPath(movie);
            if (!Directory.Exists(path))
                ;//(显示无该电影目录)
            else
                File.Delete(path);
        }
    }
}
