using CrawlerDataProject.Data;
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
            StdSchedulerFactory scheFactory = new StdSchedulerFactory();
            IScheduler sche = await scheFactory.GetScheduler();
            await sche.Start();
            IJobDetail job = JobBuilder.Create<LinksJob>()
                .WithIdentity("myjob1", "group1")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("mytrigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(3)
                    .RepeatForever())
                .Build();
            sche.ScheduleJob(job, trigger);
            Console.ReadLine();
        }
    
    }
}
