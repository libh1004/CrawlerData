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
            var sources = from so in db.Sources.Where(s => s.Status == 0) select so;
            foreach (var item in sources)
            {
                if(item != null)
                {
                    //db.Sources.Add(GetLinks(item));
                    db.SaveChanges();
                    item.Status = 1;
                }
            }
        }
        public HashSet<string> GetLinks(Source source)
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(source.SelectorSource);
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
            return setLink;
        }
    }
}
