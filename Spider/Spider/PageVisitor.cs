using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace Spider {
    class PageVisitor {
        private WebClient webClient = new WebClient();
        private byte[] _tempData;
        private const string SaveCoverFileName = "cover.png";

        /// <summary>
        /// 返回目标URL的HTML文本，需要在第二个参数指定字符编码，访问失败时返回字符串"Error"
        /// </summary>
        public string getHtmlTextByURL(string url, Encoding coding) {
            try {
                webClient.Credentials = CredentialCache.DefaultCredentials;
                _tempData = webClient.DownloadData(url);
            } catch (Exception e) {
                Debug.Print(e.Message);
                return "Error";
            }
            return coding.GetString(_tempData);
        }
        //获取url文件的后缀名（不带点）        
        private string getSuffixByUrl(string url) {
            string[] _temp = System.IO.Path.GetFileName(url)
                .Split('.');
            return _temp[_temp.Length - 1];
        }


        public bool downloadFileByUrl(string url, string path, string fileName) {
            try {
                webClient.DownloadFile(url, path + fileName + "." + getSuffixByUrl(url));
            }catch(Exception e) {
                Debug.Print(e.Message);
                return false;
            }
            return true;
        }


    }
}
