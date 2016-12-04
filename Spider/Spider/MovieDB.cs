using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Spider {
    class MovieDB {
        
        public List<MovieItem> movieList = new List<MovieItem>();


        public bool downloadmovieItem(int index) {
            try {
                movieList[index].download();
            } catch (Exception e) {
                Debug.Print(e.Message);
                return false;
            }
            movieList[index].isDownload = true;
            return false;
        }

        //add MovieItem to movieList
        public void addItem(MovieItem temp) {
            movieList.Add(temp);
        }
    }
}
