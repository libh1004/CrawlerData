using HtmlAgilityPack;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerURL
{

    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            List<Article> articles = new List<Article>();
            var filterData = db.Sources;
            filterData = filterData.Where(x => x.Status = 3);
            foreach (var item in filterData)
            {
                articles.Add(GetLinks(item.Url));
                item.Status = 4;// set flag to mark it done
            }

            // save articles to DB

        }
        public List<Article> GetLinks(string source)
        {
            Console.OutputEncoding = Encoding.UTF8;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://vnexpress.net/giao-duc");
            var nodeList = doc.QuerySelectorAll("h3.title-news a");
            HashSet<string> setLink = new HashSet<string>();
            foreach (var node in nodeList)
            {
                var link = node.Attributes["href"].Value;
                if (string.IsNullOrEmpty(link))
                {
                    continue;
                }
                setLink.Add(link);
                Console.WriteLine(link.ToString());
                Console.ReadLine();
            }
            return setLink;
            Console.ReadLine();
        }
    }
}
