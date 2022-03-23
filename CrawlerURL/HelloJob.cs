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
            //List<Article> articles = new List<Article>();
            //var filterData = db.Sources;
            //filterData = filterData.Where(x => x.Status = 3);
            //foreach (var item in filterData)
            //{
            //    articles.Add(GetLinks(item.Url));
            //    item.Status = 4;// set flag to mark it done
            //}

            // save articles to DB

        }
    }
}
