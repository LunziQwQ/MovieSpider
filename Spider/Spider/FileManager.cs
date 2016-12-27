using System;
using System.Collections.Generic;
using System.IO;

namespace Spider {
    class FileManager {

        public static string rootPath =     //缓存的根目录绝对路径
            @"C:\Users\" + System.Environment.UserName + @"\Documents\MovieCache\";

        //要用到的实例
        public MainForm mainform;
        private PageVisitor pageVisitor = new PageVisitor();

        //单例模式
        private static FileManager instance;
        public static FileManager getInstance() {
            if (instance == null)
                instance = new FileManager();
            return instance;
        }

        /// <summary>
        /// 构造器：初始化缓存目录文件夹，若不存在则创建。
        /// </summary>
        private FileManager() {
            createRootPathExist();
        }

        /// <summary>
        /// 获取电影实例序列化所存储的目录。
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public string getPath(MovieItem movie) {
            return rootPath + movie.category + "\\" + movie.name;
        }

        /// <summary>
        /// 检测缓存根目录是否存在，不存在则创建rootPath文件夹。
        /// </summary>
        private void createRootPathExist() {
            if (!Directory.Exists(rootPath))//如果不存在就创建file文件夹
                Directory.CreateDirectory(rootPath);
        }

        //删除该电影在本地的缓存文件
        public void deleteMovieItem(MovieItem movie) {
            //FIXME: tianjia xin de gong neng 
            string path = getPath(movie);
            if (!Directory.Exists(path)) //(显示无该电影目录)
                System.Windows.Forms.MessageBox.Show("No this movie Exist.");
            else
                Directory.Delete(path, true);
        }
        
        /// <summary>
        /// 将MovieItem以"缓存根目录/分类/电影名"的格式存储，并下载封面到电影名目录下。.
        /// </summary>
        /// <param name="movie">MovieItem 要存储的电影实例</param>
        /// <returns>是否存储成功</returns>
        public bool saveMovieItem(MovieItem movie) {
            string fileName = getPath(movie) + "\\movieInfo.txt";

            try {
                if (!Directory.Exists(getPath(movie)))//如果不存在就创建file文件夹
                    Directory.CreateDirectory(getPath(movie));
                pageVisitor.downloadFileByUrl(movie.coverURL, getPath(movie) + "\\", "cover");

                File.WriteAllText(fileName, movie.getMovieInfoString());
            }catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message+"path:"+getPath(movie));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 从本地缓存中获得所有电影信息列表。
        /// </summary>
        /// <returns>List<string>所有电影的序列化字符串</returns>
        public List<string> getStringByLocalFile() {
            List<string> strList = new List<string>();
            DirectoryInfo movieCacheFolder = new DirectoryInfo(rootPath);
            foreach(DirectoryInfo cateoryFolder in movieCacheFolder.GetDirectories()) {
                foreach(DirectoryInfo movieFolder in cateoryFolder.GetDirectories()) {
                    strList.Add(File.ReadAllText(movieFolder.FullName + "\\movieInfo.txt"));
                }
            }
            return strList;
        }

        /// <summary>
        /// 获取文件夹已经所有内容所占用的空间。
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns>文件大小（Bytes）</returns>
        private long getFolderSize(DirectoryInfo dirInfo) {
            long size = 0;
            // Add file sizes.
            FileInfo[] fileInfolist = dirInfo.GetFiles();
            foreach (FileInfo x in fileInfolist) {
                size += x.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dirList = dirInfo.GetDirectories();
            foreach (DirectoryInfo x in dirList) {
                size += getFolderSize(x);
            }
            return size;
        }

        /// <summary>
        /// 获取电影缓存文件夹占用空间。
        /// </summary>
        /// <returns>文件大小(Bytes)</returns>
        public long getCacheUsage() {
            return getFolderSize(new DirectoryInfo(rootPath));
        }
    }
}
