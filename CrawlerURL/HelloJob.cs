using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerURL
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //JobKey key = context.JobDetail.Key;
            //JobDataMap datamap = context.JobDetail.JobDataMap;
            //string jobSays = datamap.GetString("Hello world");
            //float myFloatValue = datamap.GetFloat("4000");
            //bool myBool = datamap.GetBoolean("true");
            //await Console.Error.WriteLineAsync("Instance of " + key + ", jobSays " + jobSays + ", myFloatValue " + myFloatValue + ", myBool " + myBool);
            await Console.Out.WriteLineAsync("Hello world");
        }
    }
}
