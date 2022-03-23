using CrawlerURL;
using HtmlAgilityPack;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CrawlerContent
{
    public class ContentJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            List<Article> articles = new List<Article>();
            //var filterData = from a in db.Articles.Where(ar => ar.Status == 0) select a;
            //foreach (var item in filterData)
            //{
            //    // day la 1 object nhung khi ben kia 
            //    articles.Add(new HelloJob().GetContent(item.Url));
            //    db.Articles.Add(new HelloJob().GetContent(item.Url));
            //    item.Status = 1;
            //    db.SaveChanges();

            //}
            // save in db
        }

    }
}
