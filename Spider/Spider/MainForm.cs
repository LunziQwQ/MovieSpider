using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Spider {
    public partial class MainForm: Form {
        PageVisitor pageVisitor = new PageVisitor();
        NetSpider netSpider = new NetSpider();
        FileManager fileManager = FileManager.getInstance();
        MovieDB movieDB = new MovieDB();
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

        private void MainForm_Load(object sender, EventArgs e) {
            movieDB.initMovieDBFromLocalFile();
        }

        private int TickCount = 0;
        private void timer_Main_Tick(object sender, EventArgs e) {
            TickCount++;
            if(TickCount == 1) {
                width = this.Width;
                location = this.Location;
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
        
        private void updateUsage() {
            label_spaceUsage.Text = (fileManager.getCacheUsage() / 1000).ToString() + " KB";
        }

        private void updateItemCount() {
            label_ItemCount.Text = movieDB.movieList.Count.ToString();
        }
        #region Buttons's Events
        private void btn_CopyLink_Click(object sender, EventArgs e) {
            string text = movieDB.getItemByName((string)listBox_movie.SelectedItem).DownloadLink;
            if(text == null || text == "") {
                MessageBox.Show("Error:未选择电影或电影无效，加入剪切板失败");
                return;
            }
            Clipboard.SetDataObject(text, true);
        }

        private void btn_Remove_Click(object sender, EventArgs e) {
            MovieItem mv = movieDB.getItemByName((string)listBox_movie.SelectedItem);
            if (mv.Name == null || mv.Name == "" ) {
                MessageBox.Show("Error:未选择电影或电影无效，删除失败");
                return;
            }
            movieDB.movieList.Remove(mv);
            fileManager.deleteMovieItem(mv);
        }

        private void btn_Grab_Click(object sender, EventArgs e) {
            if (!netSpider.isNetStatusOK) {
                MessageBox.Show("Net status is Failed.The Spider can't grab without internet.");
            } else {
                // TODO: Grabing!
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
            Debug.Print(category);
            if (category == "undefined" && listBox_category.Items.Count > 0) { 
                category = (String)listBox_category.Items[0];
            }
            if(category != "undefined") { 
                foreach (MovieItem x in movieDB.movieList) {
                    if (x.Category == category) {
                        listBox_movie.Items.Add(x.Name);
                    }
                }
            }
        }
    }
}
