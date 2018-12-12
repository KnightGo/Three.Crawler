# Three.Crawler 爬虫

1.爬虫，爬虫攻防

2.下载html，log4ne

3.xpath解析html，获取数据和深度抓取

4.惰性加载、Ajax加载数据、VUE数据绑定(O(∩_∩)0)

5.不一样的属性和ajax数据的获取

6.多线程抓取

爬虫：是一个自动提取网页的程序 

url开始--分析获取数据&找到url--递归下去--结束

        下载html--解析获取数据--数据保存
        
数据：抓小说数据，做个内容站；

      电影/动漫下载站
      
      抓图片
      
  政府的公开招标数据，每天汇集这些数据

爬虫的攻防：

1、robots协议---君子协定，道德防线

2、请求检测header--爬虫去都模拟一下

3、登陆限制：使用用户登录--请求的时候带上cookie爬取

4、爬虫频率高限制IP（黑名单/返回个验证码）---多个ip(adsl拨号/168伪装IP/代理IP)

5、验证码:有开源组件做图片识别/打码平台

6、大招：数据js动态加载；转图片；js收集用户操作，然后提交；

7、用户控件(可以收集更多信息)

都是可以搞定的，道高一尺魔高一丈，浏览器的请求不能拒绝

实现方式：

使用HttpWebRequest或者HttpClient，前者功能比较丰富，后者使用比较简单；

一、获取HTML文件

1、HttpWebRequest模拟请求

2、模拟Request Header参数

3、使用HttpWebResponse发起请求

4、StreamReader获取数据（获取完成关闭数据流）


二、分析html节点

三、使用XPath解析html文件获得数据

1、添加NuGet （HtmlAgilityPack）

2、使用HtmlDocument、LoadHtml、HtmlNodeCollection…分析节点获取数据

3、F12分析html的div

通过class定位：//*【@ class=”className”】//h1

通过Div定位：//div/dl/dt/a
…



附：log4j

1、引入log4j

2、创建标准配置文件（配置文件设置始终可复制）

3、封装LogHelper（单例）
