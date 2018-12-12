using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICrawler
{
    public interface JD_ICrawler
    {
        /// <summary>
        /// 爬取商品类型
        /// </summary>
        void Crawler_Product_Type(string html);
    }
}
