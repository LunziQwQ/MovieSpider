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


        public bool downloadMovieInfoFromInternet() {
            
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
