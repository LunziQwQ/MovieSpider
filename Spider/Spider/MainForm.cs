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
            //Debug.Print(pageVisitor.getHtmlTextByURL("http://66ys.cc", Encoding.Default));
            //Debug.Print(pageVisitor.downloadFileByUrl("https://ss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superman/img/logo/logo_redBlue.png", FileManager.rootPath, "cover").ToString());
            movieDB.initMovieDBFromLocalFile();
        }
        private int TickCount = 0;
        private void timer_Main_Tick(object sender, EventArgs e) {
            TickCount++;
            if(TickCount == 1) {
                bool isNetStatusOK = netSpider.checkConnect();
                label_netStatus.Text = isNetStatusOK ? "OK" : "Failed";
                label_netStatus.ForeColor = isNetStatusOK ? Color.Green : Color.Red;
            }

            
        }
        
        private void btn_Grab_Click(object sender, EventArgs e) {
            if (!netSpider.isNetStatusOK) {
                MessageBox.Show("Net status is Failed.The Spider can't grab without internet.");
            } else {

            }
        }

        
    }
}
