using HtmlAgilityPack;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerURL
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //var web = new HtmlWeb();
            //var url = "https://vnexpress.net/podcast";
            //HtmlDocument doc = web.Load(url);
            //var nodeList = doc.QuerySelectorAll("h3.title-news a");
            //HashSet<string> setLink = new HashSet<string>();
            //foreach (var node in nodeList)
            //{
            //    var link = node.Attributes["href"].Value;
            //    if (string.IsNullOrEmpty(link))
            //    {
            //        continue;
            //    }
            //    setLink.Add(link);
            //    Console.WriteLine(link.ToString());
            //}
            //Console.ReadLine();

            StdSchedulerFactory scheFactory = new StdSchedulerFactory();
            IScheduler sche = await scheFactory.GetScheduler();
            await sche.Start();
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myjob1", "group1")
                .Build();

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("trigger1", "group1")
            //    .StartNow()
            //    .WithSimpleSchedule(x => x
            //        .WithIntervalInSeconds(2)
            //        .RepeatForever())
            //    .Build();
            //sche.ScheduleJob(job, trigger);
       
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("mytrigger1", "group1")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(20, 41))
                .ForJob(job)
                .Build();
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("trigger2", "group1")
            //    .WithCronSchedule("0 0/2 * * * ?")
            //    .ForJob("myjob1", "group1")
            //    .Build();
            sche.ScheduleJob(job, trigger);
            Console.ReadLine();
        }
    }
}
