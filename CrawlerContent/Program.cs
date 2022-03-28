using CrawlerContent;
using CrawlerDataProject;
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
            //xong truyen url vao cai ham nay-- > tuc la phai truyen url vao kia de lay ra bai viet
            StdSchedulerFactory scheFactory = new StdSchedulerFactory();
            IScheduler sche = await scheFactory.GetScheduler();
            await sche.Start();
            IJobDetail job = JobBuilder.Create<ContentJob>()
                .WithIdentity("myjob2", "group1")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("mytrigger2", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();
            sche.ScheduleJob(job, trigger);
            Console.ReadLine();
        }

    }
}
