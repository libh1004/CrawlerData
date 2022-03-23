using CrawlerContent;
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
        Article art = new Article();
        public static async Task Main(string[] args)
        {
            //var hello = new ContentJob();
            Console.OutputEncoding = Encoding.UTF8;
            // url nay
            var url = "https://vnexpress.net/omicron-chua-phai-lan-song-cuoi-cung-cua-dai-dich-4436334.html";
            var web = new HtmlWeb();
            Console.WriteLine("Crawling data from: " + url);
            HtmlDocument doc = web.Load(url);
            var titleNode = doc.QuerySelector("h1.title-detail");
            var title = titleNode.InnerText;
            var descriptionNode = doc.QuerySelector("p.description");
            var desc = descriptionNode.InnerText;
            var contentNode = doc.QuerySelector("article.fck_detail");
            var content = contentNode.InnerText;
            var thumbnailNode = doc.QuerySelector("article.fck_detail img");
            var thumbnail = thumbnailNode.Attributes["data-src"].Value;
            var authorNode = doc.QuerySelector("p strong");
            var author = "";
            if (authorNode.InnerText.Length > 0)
            {
                author = authorNode.InnerText;
            }
            Article article = new Article()
            {
                Url = url,
                Title = title,
                Content = content,
                Thumbnail = thumbnail,
                Author = author
            };
            Console.WriteLine(article.ToString());
            Console.ReadLine();
            //xong truyen url vao cai ham nay --> tuc la phai truyen URL vao kia de lay ra bai viet
            //var article = hello.GetContent(url);
            //Console.WriteLine(article.ToString());
            //StdSchedulerFactory factory = new StdSchedulerFactory();
            //IScheduler sched = await factory.GetScheduler();
            //sched.Start();
            //IJobDetail job = JobBuilder.Create<ContentJob>()
            //    .WithIdentity("myjob", "group1")
            //    .Build();
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("mytrigger", "group1")
            //    .StartNow()
            //    .WithSimpleSchedule(x => x
            //        .WithIntervalInSeconds(2)
            //        .RepeatForever())
            //    .Build();
            //sched.ScheduleJob(job, trigger);
            //Console.ReadLine();
        }

    }
}
