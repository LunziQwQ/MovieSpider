using System;
using System.Collections.Generic;
using System.IO;

namespace Spider {
    class FileManager {
        public MainForm mainform;
        public static string rootPath =                   //缓存的根目录绝对路径
            @"C:\Users\" + System.Environment.UserName + @"\Documents\MovieCache\";
        private FileManager() {
            createRootPathExist();
        }
        private PageVisitor pageVisitor = new PageVisitor();

        private static FileManager instance;
        public static FileManager getInstance() {
            if (instance == null)
                instance = new FileManager();
            return instance;
        }

        public string getPath(MovieItem movie) {
            return rootPath + movie.category + "\\" + movie.name;
        }

        private void createRootPathExist() {
            if (!Directory.Exists(rootPath))//如果不存在就创建file文件夹
                Directory.CreateDirectory(rootPath);
        }

        //删除该电影在本地的缓存文件
        public void deleteMovieItem(MovieItem movie) {
            string path = getPath(movie);
            if (!Directory.Exists(path)) //(显示无该电影目录)
                System.Windows.Forms.MessageBox.Show("No this movie Exist.");
            else
                Directory.Delete(path, true);
        }
        
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
        public long getCacheUsage() {
            return getFolderSize(new DirectoryInfo(rootPath));
        }
    }
}
