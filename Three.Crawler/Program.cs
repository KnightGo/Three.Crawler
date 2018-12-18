using Crawler;
using ICrawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            ////模拟http请求 下载html
            //string html = CrawlerHelper.DownloadHtml("https://www.jd.com/allSort.aspx");

            //JD_ICrawler _ICrawler = new JD_Crawler();
            ////分析html节点，获取数据
            //_ICrawler.Crawler_Product_Type(html);


            string html = CrawlerHelper.DownloadHtml_Pochta("https://www.pochta.ru/tracking");
            

            Console.Read();
        }
    }
}
