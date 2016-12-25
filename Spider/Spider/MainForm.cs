using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spider {
    public partial class MainForm: Form {
        PageVisitor pageVisitor = new PageVisitor();
        NetSpider netSpider = new NetSpider();
        FileManager fileManager = FileManager.getInstance();
        MovieDB movieDB = MovieDB.getInstance();
        public static int width;
        public static Point location;

        private MovieViewerForm movieViewer;

        public MainForm() {
            InitializeComponent();
        }
        #region check textBox input
        private string _setDeepTemp = "1", _setIntervalTemp = "10";
        private void textBox_setInterval_TextChanged(object sender, EventArgs e) {
            foreach (char x in textBox_setInterval.Text) {
                if (x < '0' || x > '9' ) {
                    textBox_setInterval.Text = _setIntervalTemp;
                    return;
                }
            }
            if(textBox_setInterval.Text.Length < 1)
                return;
            if (Int32.Parse(textBox_setInterval.Text) > 1000)
                textBox_setInterval.Text = "1000";
            if (Int32.Parse(textBox_setInterval.Text) < 1)
                textBox_setInterval.Text = "1";
            _setIntervalTemp = textBox_setInterval.Text;
        }
        private void textBox_setDeep_TextChanged(object sender, EventArgs e) {
            foreach (char x in textBox_setDeep.Text) {
                if (x < '0' || x > '9') {
                    textBox_setDeep.Text = _setDeepTemp;
                    return;
                }
            }
            if (textBox_setDeep.Text.Length < 1)
                return;
            if (Int32.Parse(textBox_setDeep.Text) > 3000)
                textBox_setDeep.Text = "3000";
            if (Int32.Parse(textBox_setDeep.Text) < 1)
                textBox_setDeep.Text = "1";

            _setDeepTemp = textBox_setDeep.Text;
        }
        #endregion


        private int TickCount = 0;
        private void timer_Main_Tick(object sender, EventArgs e) {
            TickCount++;
            location = this.Location;
            if (movieViewer != null)
                movieViewer.updateLocation();

            if (TickCount == 1) {
                netSpider.mainForm = this;
                fileManager.mainform = this;
                netSpider.label_count = label_ItemCount;
                width = this.Width;
                updateUsage();
                bool isNetStatusOK = netSpider.checkConnect();
                label_netStatus.Text = isNetStatusOK ? "OK" : "Failed";
                label_netStatus.ForeColor = isNetStatusOK ? Color.Green : Color.Red;
                movieDB.initMovieDBFromLocalFile();
                listBox_ShowCategoryItemList();
                listBox_ShowMovieItemList();
            }
            updateItemCount();

            if (TickCount % 100 == 0)
                updateUsage();
                
        }
        
        public void updateUsage() {
            label_spaceUsage.Text = (fileManager.getCacheUsage() / 1000).ToString() + " KB";
        }

        public void updateItemCount() {
            label_ItemCount.Text = movieDB.movieList.Count.ToString();
        }
        #region Buttons's Events
        private void btn_CopyLink_Click(object sender, EventArgs e) {
            string text = movieDB.getItemByName((string)listBox_movie.SelectedItem).downloadLink;
            if(text == null || text == "") {
                MessageBox.Show("Error:未选择电影或电影无效，加入剪切板失败");
                return;
            }
            Clipboard.SetDataObject(text, true);
            MessageBox.Show("下载链接已加入剪贴板");

        }

        private void btn_Remove_Click(object sender, EventArgs e) {
            movieViewer.Close();

            MovieItem mv = movieDB.getItemByName((string)listBox_movie.SelectedItem);
            if (mv.name == null || mv.name == "" ) {
                MessageBox.Show("Error:未选择电影或电影无效，删除失败");
                return;
            }
            movieDB.movieList.Remove(mv);
            fileManager.deleteMovieItem(mv);
            listBox_ShowCategoryItemList();
            listBox_ShowMovieItemList();
        }

        private void btn_Grab_Click(object sender, EventArgs e) {
            if (!netSpider.isNetStatusOK) {
                MessageBox.Show("Net status is Failed.The Spider can't grab without internet.");
            } else {
                int _deep = Int32.Parse(textBox_setDeep.Text),
                    _interval = Int32.Parse(textBox_setInterval.Text);
                netSpider.startGrab(_deep, _interval);
            }
        }

        #endregion


        private void listBox_ShowCategoryItemList() {
            listBox_category.Items.Clear();
            foreach(string x in movieDB.categoryList) {
                listBox_category.Items.Add(x);
            }
        }

        private void listBox_category_SelectedIndexChanged(object sender, EventArgs e) {
            listBox_ShowMovieItemList((String)listBox_category.SelectedItem);
        }

        private void btn_Reload_Click(object sender, EventArgs e) {
            if (movieViewer != null) {
                movieViewer.Close();
            }
            listBox_ShowCategoryItemList();
            listBox_ShowMovieItemList();
        }

        private void listBox_movie_SelectedIndexChanged(object sender, EventArgs e) {
            if (movieViewer != null) {
                movieViewer.Close();
            }
            movieViewer = new MovieViewerForm();
            movieViewer.init(movieDB.getItemByName((string)listBox_movie.SelectedItem));
        }

        private void listBox_ShowMovieItemList(string category = "undefined") {
            listBox_movie.Items.Clear();
            if (category == "undefined" && listBox_category.Items.Count > 0) { 
                category = (String)listBox_category.Items[0];
            }
            if(category != "undefined") { 
                foreach (MovieItem x in movieDB.movieList) {
                    if (x.category == category) {
                        listBox_movie.Items.Add(x.name);
                    }
                }
            }
        }
    }
}
