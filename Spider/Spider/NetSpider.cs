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

        public string getUrl() {
            return "";
        }

        //将获得的电影列表添加到movieDB
        public void addItem() {

        }

        public bool checkConnect() {
            string TestURL = "66ys.cc";
            Ping ping = new Ping();
            try {
                PingReply pingReply = ping.Send(TestURL);
                return pingReply.Status == IPStatus.Success;
            }catch(Exception e) {
                Debug.Print(e.Message);
                return false;
            }
        }

    }
}
