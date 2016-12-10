using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Spider {
    public partial class MainForm: Form {
        PageVisitor pageVisitor = new PageVisitor();
        NetSpider netSpider = new NetSpider();
        FileManager fileManager = FileManager.getInstance();
        MovieDB movieDB = new MovieDB();

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
                updateUsage();
                bool isNetStatusOK = netSpider.checkConnect();
                label_netStatus.Text = isNetStatusOK ? "OK" : "Failed";
                label_netStatus.ForeColor = isNetStatusOK ? Color.Green : Color.Red;
                movieDB.initMovieDBFromLocalFile();
                treeView_ShowCategoryNodeList();
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
            string text = "Test";
            // TODO: get the treeview selected for movieItem's info which is download url;
            Clipboard.SetDataObject(text, true);
        }

        private void btn_Remove_Click(object sender, EventArgs e) {
            MovieItem mv = new MovieItem();
            // TODO:get the treeview selected for movieItem
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


        class TreeNode_Movie : TreeNode {
            public MovieItem movie;
            public TreeNode_Movie(MovieItem movie) {
                this.movie = movie;
                this.Text = movie.Name;
            }
        }
        class TreeNode_Category: TreeNode {
            public string category;
            public TreeNode_Category(string category) {
                this.category = category;
                this.Text = category;
            }
        }

        private void treeView_ShowCategoryNodeList() {
            treeView_categoryList.Nodes.Clear();
            foreach(string x in movieDB.categoryList) {
                treeView_categoryList.Nodes.Add(new TreeNode_Category(x));
            }
        }

        private void treeView_ShowMovieNodeList(string category) {
            treeView_movieList.Nodes.Clear();
            foreach(MovieItem x in movieDB.movieList) {
                if (x.Category == category) {
                    treeView_movieList.Nodes.Add(new TreeNode_Movie(x));
                } 
            }
        }

        private void treeView_categoryList_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode _temp = treeView_movieList.SelectedNode;
            if (_temp != null) 
                treeView_ShowMovieNodeList(_temp.Text);
        }
    }
}
