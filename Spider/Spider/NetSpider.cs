using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace Spider {
    class NetSpider {
        public static string SourceURL = @"http://66ys.cc";
        public bool isNetStatusOK;
        public string getUrl() {
            return "";
        }

        

        public bool checkConnect() {
            string TestURL = "66ys.cc";
            Ping ping = new Ping();
            try {
                PingReply pingReply = ping.Send(TestURL);
                isNetStatusOK = (pingReply.Status == IPStatus.Success);
                return isNetStatusOK;
            }catch(Exception e) {
                Debug.Print(e.Message);
                isNetStatusOK = false;
                return isNetStatusOK;
            }
        }

    }
}
