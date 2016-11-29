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
    }
}
