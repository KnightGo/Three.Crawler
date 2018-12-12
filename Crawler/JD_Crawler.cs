using Common;
using HtmlAgilityPack;
using ICrawler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class JD_Crawler : JD_ICrawler
    {
        LogHelper log = new LogHelper(typeof(JD_Crawler));
       
        /// <summary>
        /// 爬取京东所有商品类型
        /// </summary>
        public void Crawler_Product_Type(string html)
        {
            string title_1 = string.Empty;
            string title_2 = string.Empty;
            string title_3 = string.Empty;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            log.Info($"开始获取京东商品类型");
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            //列表板块定位
            string first_model_div = "//*[@ class='category-item m']";
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(first_model_div);
            if (nodes != null)
            {
                //一级标题
                string second_title = "//h2/span";

                //二级DIV
                string three_title = "//div/div[@ class='items']/dl";
                
                foreach (HtmlNode node1 in nodes)
                {

                    string thisHtml_t = node1.OuterHtml;
                    HtmlDocument htmlChild_t = new HtmlDocument();
                    htmlChild_t.LoadHtml(thisHtml_t);
                    HtmlNodeCollection nodesChild_t = htmlChild_t.DocumentNode.SelectNodes(second_title);
                    foreach (HtmlNode nodetitles in nodesChild_t)
                    {
                        //模块标题（一级标题）
                        title_1 = nodetitles.InnerHtml;
                        log.Info("----------------------------------------------------" + title_1 + "-----------------------------------------------------------");
                        string thisHtml = node1.OuterHtml;
                        HtmlDocument htmlChild = new HtmlDocument();
                        htmlChild.LoadHtml(thisHtml);
                        HtmlNodeCollection nodesChild = htmlChild.DocumentNode.SelectNodes(three_title);
                        if (nodesChild == null)
                            continue;
                        foreach (HtmlNode node2 in nodesChild)
                        {
                            //模块标题（一级标题）
                            string title = node2.InnerHtml;
                            HtmlDocument htmlChilds = new HtmlDocument();
                            htmlChilds.LoadHtml(title);
                            foreach (HtmlNode node3 in htmlChilds.DocumentNode.SelectNodes("//dt/a"))
                            {
                                //模块标题（二级标题）
                                title_2 = node3.InnerHtml;
                                log.Info(title_2 + ":\t");
                                int index = 1;
                                StringBuilder stringBuilder = new StringBuilder();
                                foreach (HtmlNode nodesz2 in htmlChilds.DocumentNode.SelectNodes("//dd/a"))
                                {
                                    title_3 = nodesz2.InnerHtml;
                                    
                                    if (index == 5)
                                    {
                                    
                                        stringBuilder.Append("\n\t" + title_3);
                                        index = 1;
                                    }
                                    else
                                    {
                                        stringBuilder.Append(title_3 + "\t");
                                   
                                    }
                                    index += 1;

                                }
                                log.Info(stringBuilder.ToString());
                                Console.WriteLine();
                            }
                          
                        }
                        //Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                        log.Info("----------------------------------------------------" + title_1 + "-----------------------------------------------------------");
                    }
                }
            }
            stopwatch.Stop();
            log.Error($"读取完成，耗时：{stopwatch.ElapsedMilliseconds.ToString()}ms");

        }
    }
}
