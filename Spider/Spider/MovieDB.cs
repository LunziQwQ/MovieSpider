using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Spider {
    class MovieDB {
        public FileManager fileManager = FileManager.getInstance();
        public List<MovieItem> movieList = new List<MovieItem>();
        public List<string> categoryList = new List<string>();
        private static MovieDB instance;

        public static MovieDB getInstance() {
            if (instance == null)
                instance = new MovieDB();
            return instance;
        }
        private MovieDB() { }

        /// <summary>
        /// 通过影片名返回MovieItem
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MovieItem getItemByName(string name) {
            foreach(MovieItem x in movieList) {
                if (x.name == name)
                    return x; 
            }
            return new MovieItem("NULL");
        }

        public bool initMovieDBFromLocalFile() {
            try {
                foreach (string x in fileManager.getStringByLocalFile()) {
                    addItem(MovieItem.create(x));
                }
            }catch(Exception e) {
                Debug.Print("MovieDB line39:" + e.Message);
                return false;
            }
            return true;
        }

        //add MovieItem to movieList
        public void addItem(MovieItem temp) {
            movieList.Add(temp);
            foreach(string x in categoryList) {
                if (temp.category == x)
                    return;
            }
            categoryList.Add(temp.category);
        }

        public void addItemFromNet(MovieItem movie) {
            addItem(movie);
            if (!movie.save())
                MessageBox.Show("Error: One movie has saved failed");
        }
    }
}
