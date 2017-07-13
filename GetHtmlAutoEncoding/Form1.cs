using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GetHtmlAutoEncoding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //string strTemp = "网址：" + txtUrl.Text + ",的编码：" + getEndoding(txtUrl.Text)+Environment.NewLine;
            txtResult.AppendText(GetHtml(txtUrl.Text));
        }

        /// <summary>
        /// 取得编码
        /// </summary>
        /// <param name="strUrl"></param>
        private string getEndoding(string strUrl)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);
            req.Method = "GET";
            string str;
            HttpWebResponse Stream = req.GetResponse() as HttpWebResponse;
            return Stream.CharacterSet;

        }
        /// <summary>
        /// 下载网页并自动根据编码转成字符串格式。
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        private string GetHtml(string strUrl)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);
            req.Method = "GET";
            string str;
            HttpWebResponse Stream = req.GetResponse() as HttpWebResponse;
            string strEncoding = Stream.CharacterSet;
            using (StreamReader reader = new StreamReader(Stream.GetResponseStream(), System.Text.Encoding.GetEncoding(strEncoding)))
            {
                str = reader.ReadToEnd();
                return str;
            }
            return null;
        }
    }
}
