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

namespace Spider {
    public partial class MainForm: Form {
        public MainForm() {
            InitializeComponent();
            PageVisitor pageVisitor = new PageVisitor();
            NetSpider netSpider = new NetSpider();
            //Debug.Print(pageVisitor.getHtmlTextByURL("http://66ys.cc", Encoding.Default));
            Debug.Print(pageVisitor.downloadFileByUrl("https://ss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superman/img/logo/logo_redBlue.png", FileManager.rootPath, "cover").ToString());
            Debug.Print(System.Environment.UserName);
            Debug.Print(netSpider.checkConnect().ToString());
        }
        
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
            if(textBox_setDeep.Text.Length < 1)
                return;
            if (Int32.Parse(textBox_setDeep.Text) > 3000)
                textBox_setDeep.Text = "3000";
            if (Int32.Parse(textBox_setDeep.Text) < 1)
                textBox_setDeep.Text = "1";

            _setDeepTemp = textBox_setDeep.Text;
        }
    }
}
