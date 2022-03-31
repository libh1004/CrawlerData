using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using HtmlAgilityPack;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrawlerDataProject.Data
{
    public class LinksJob : IJob
    {
        MyDbContext db = new MyDbContext();
        public async Task Execute(IJobExecutionContext context)
        {
            var links = from so in db.Links select so;
            foreach (var item in links)
            {
                var listLink = GetLinks(item.Url);
                //db.Links.Add(listLink);
                db.SaveChanges();
                item.Status = 1;
            }
        }
        public List<Article> GetLinks(string url)
        {
            List<Article> listArticle = new List<Article>(); 
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            var source = new Source();
            var nodeList = doc.QuerySelectorAll(source.SelectorSource);
            HashSet<string> setLink = new HashSet<string>();
            foreach (var node in nodeList)
            {
                var link = node.Attributes["href"].Value;
                if (string.IsNullOrEmpty(link))
                {
                    continue;
                }
                setLink.Add(link);
            }
            return listArticle;
        }

    }
}
