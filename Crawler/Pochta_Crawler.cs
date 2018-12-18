using HtmlAgilityPack;
using ICrawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class Pochta_Crawler : Pochta_ICrawler
    {
        public void Crawler_Info(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

        }
    }
}
