using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Spider {
    class MovieDB {
        public FileManager fileManager = FileManager.getInstance();
        public List<MovieItem> movieList = new List<MovieItem>();
        public List<string> categoryList = new List<string>();

        /// <summary>
        /// 通过影片名返回MovieItem
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MovieItem getItemByName(string name) {
            foreach(MovieItem x in movieList) {
                if (x.Name == name)
                    return x; 
            }
            return new MovieItem("NULL");
        }

        public bool downloadMovieInfoFromInternet() {
            //TODO: Finish it    
            return false;
        }

        public bool initMovieDBFromLocalFile() {
            try {
                foreach (string x in fileManager.getStringByLocalFile()) {
                    addItem(MovieItem.create(x));
                }
            }catch(Exception e) {
                Debug.Print(e.Message);
                return false;
            }
            return true;
        }

        //add MovieItem to movieList
        public void addItem(MovieItem temp) {
            movieList.Add(temp);
            foreach(string x in categoryList) {
                if (temp.Category == x)
                    return;
            }
            categoryList.Add(temp.Category);
        }
    }
}
