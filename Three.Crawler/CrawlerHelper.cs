using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Three.Crawler
{
    public class CrawlerHelper
    {
        public static string DownloadHtml(string url)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

                #region 拼装Request Header信息+参数信息（伪装成浏览器向服务器发起请求）
                //设置30s的超时
                request.Timeout = 30 * 1000;
                //pc浏览器
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";

                request.ContentType = "text/html; charset=utf-8";// "text/html;charset=gbk";// 

                request.Host = "www.jd.com";

                //万用拼接方式
                request.Headers.Add("Cookie", @"newUserFlag=1; guid=YFT7C9E6TMFU93FKFVEN7TEA5HTCF5DQ26HZ; gray=959782; cid=av9kKvNkAPJ10JGqM_rB_vDhKxKM62PfyjkB4kdFgFY5y5VO; abtest=31; _ga=GA1.2.334889819.1425524072; grouponAreaId=37; provinceId=20; search_showFreeShipping=1; rURL=http%3A%2F%2Fsearch.yhd.com%2Fc0-0%2Fkiphone%2F20%2F%3Ftp%3D1.1.12.0.73.Ko3mjRR-11-FH7eo; aut=5GTM45VFJZ3RCTU21MHT4YCG1QTYXERWBBUFS4; ac=57265177%40qq.com; msessionid=H5ACCUBNPHMJY3HCK4DRF5VD5VA9MYQW; gc=84358431%2C102362736%2C20001585%2C73387122; tma=40580330.95741028.1425524063040.1430288358914.1430790348439.9; tmd=23.40580330.95741028.1425524063040.; search_browse_history=998435%2C1092925%2C32116683%2C1013204%2C6486125%2C38022757%2C36224528%2C24281304%2C22691497%2C26029325; detail_yhdareas=""; cart_cookie_uuid=b64b04b6-fca7-423b-b2d1-ff091d17e5e5; gla=20.237_0_0; JSESSIONID=14F1F4D714C4EE1DD9E11D11DDCD8EBA; wide_screen=1; linkPosition=search");

                request.Method = "GET";
                #region Post方式请求参数
                //request.Method = "POST";
                //Encoding enc = Encoding.GetEncoding("GB2312"); // 如果是乱码就改成 utf-8 / GB2312
                //int sort = 2;//人数
                //string dataString = string.Format("k={0}&n=24&st={1}&iso=0&src=1&v=4093&p={2}&isRecommend=false&city_id=0&from=1&ldw=1361580739", keyword, sort, 1);
                //Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  
                //byte[] postData = encoding.GetBytes(dataString);
                //request.ContentLength = postData.Length;
                //Stream requestStream = request.GetRequestStream();
                //requestStream.Write(postData, 0, postData.Length);

                #endregion


                Encoding enc = Encoding.UTF8;//.GetEncoding("GB2312");
                #endregion

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //TODO:记录日志信息
                    }
                    else
                    {
                        try
                        {
                            StreamReader reader = new StreamReader(response.GetResponseStream(), enc);
                            //读取html数据
                            html = reader.ReadToEnd();
                            reader.Close();

                        }
                        catch (Exception ex)
                        {
                            //TODO：write log
                            html = null;
                        }
                    }
                };
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                //TODO:write log
                html = null;
            }
            catch (Exception ex)
            {
                //TODO:write log
                html = null;
            }
            return html;
        }

        public static string DownloadHtml_Pochta(string url)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

                #region 拼装Request Header信息+参数信息（伪装成浏览器向服务器发起请求）
                //设置30s的超时
                request.Timeout = 30 * 1000;
                //pc浏览器
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";

                request.Host = "www.pochta.ru";

                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";

                request.ContentType = "application/x-www-form-urlencoded";
                request.KeepAlive = true;

                //万用拼接方式
                request.Headers.Add("Cookie", @"ANALYTICS_UUID=23887f48-818e-49dc-850d-2d6a23b0e86d; COOKIE_SUPPORT=true; _ga=GA1.2.487717639.1545137536; _gid=GA1.2.2120798653.1545137536; _ym_uid=1545137539415942039; _ym_d=1545137539; _ym_isad=2; HeaderBusinessTooltip=showed; _fbp=fb.1.1545137558801.2030795668; rheftjdd=rheftjddVal; _a_d3t6sf=du_06miu0m3D0QFsqLvVOZou; JSESSIONID=AE91E4014C4BD3F0A76CB3CAB716C372; GUEST_LANGUAGE_ID=ru_RU; preventPromo=1; sputnik_session=1545142325137|0");

                // request.Method = "POST";
                #region Post方式请求参数
                request.Method = "POST";
                Encoding enc = Encoding.GetEncoding("UTF-8"); // 如果是乱码就改成 utf-8 / GB2312
                string dataString = string.Format("barcode=LM391733602CN");
                Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  
                byte[] postData = encoding.GetBytes(dataString);
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length);

                #endregion

                #endregion

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //TODO:记录日志信息
                    }
                    else
                    {
                        try
                        {
                            //StreamReader reader = new StreamReader(response.GetResponseStream(), enc);
                            ////读取html数据
                            //html = reader.ReadToEnd();
                            //reader.Close();
                            Stream stream;

                            if(response.ContentEncoding.ToLower().Contains("gzip"))
                            {
                                stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                            }
                            else if (response.ContentEncoding.ToLower().Contains("deflate"))
                            {
                                stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
                            }
                            else
                            {
                                stream = response.GetResponseStream();
                            }

                            using (StreamReader reader = new StreamReader(stream, enc))
                            {
                                html = reader.ReadToEnd();
                                stream.Dispose();
                            }

                        }
                        catch (Exception ex)
                        {
                            //TODO：write log
                            html = null;
                        }
                    }
                };
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                //TODO:write log
                html = null;
            }
            catch (Exception ex)
            {
                //TODO:write log
                html = null;
            }
            return html;
        }

        public static string HttpGet(string url)
        {
            string responsestr = "";
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";

            using (HttpWebResponse response = req.GetResponse() as HttpWebResponse)
            {
                Encoding enc = GetEncodingType(response.CharacterSet);
                Stream stream; if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else
                {
                    stream = response.GetResponseStream();
                }

                using (StreamReader reader = new StreamReader(stream, enc))
                {
                    responsestr = reader.ReadToEnd(); stream.Dispose();
                }
            }
            return responsestr;
        }

        public static Encoding GetEncodingType(string CharacterSet)
        {
            switch (CharacterSet)
            {
                case "gb2312":
                    return Encoding.GetEncoding("gb2312");
                case "utf-8":
                    return Encoding.UTF8;
                default:
                    return Encoding.Default;
            }
        }


        public string OpenReadWithHttps(string URL, string strPostdata, string strEncoding)
        {
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "post";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] buffer = encoding.GetBytes(strPostdata);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding(strEncoding)))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
