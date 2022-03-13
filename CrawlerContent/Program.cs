using CrawlerURL;
using HtmlAgilityPack;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerContent
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var web = new HtmlWeb();
            var url = "https://vnexpress.net/omicron-chua-phai-lan-song-cuoi-cung-cua-dai-dich-4436334.html";
            Console.WriteLine("Crawling data from: " + url);
            HtmlDocument doc = web.Load(url);
            var titleNode = doc.QuerySelector("h1.title-detail");
            var descriptionNode = doc.QuerySelector("p.description");
            var desc = descriptionNode.InnerText;
            var contentNode = doc.QuerySelector("article.fck_detail");
            var content = contentNode.InnerText;
            var imageNode = doc.QuerySelector("article.fck_detail img");
            var image = imageNode.Attributes["data-src"].Value;
            var authorNode = doc.QuerySelector("p strong");
            var author = "";
            if (authorNode.InnerText.Length > 0)
            {
                author = authorNode.InnerText;
            }
            Article article = new Article()
            {
                Url = url,
                Description = desc,
                Content = content,
                Image = image,
                Author = author
            };
            Console.WriteLine(article.ToString());
            Console.ReadLine();

            //StdSchedulerFactory factory = new StdSchedulerFactory();

            //IScheduler scheduler = await factory.GetScheduler();
            //await scheduler.Start();

            //IJobDetail job = JobBuilder.Create<HelloJob>()
            //    .WithIdentity("myjob1", "group1")
            //    .Build();

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("myTrigger1", "group1")
            //    .StartNow()
            //    .WithSimpleSchedule(x => x
            //        .WithIntervalInSeconds(5)
            //        .RepeatForever())
            //    .Build();

            //scheduler.ScheduleJob(job, trigger);
        }
    }
}
