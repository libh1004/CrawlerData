//using HtmlAgilityPack;
//using Quartz;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace CrawlerURL
//{
//    public class HelloJob : IJob
//    {
//        LinhDbContext db = new LinhDbContext();
//        public async Task Execute(IJobExecutionContext context)
//        {
//            //List<Source> sources = new List<Source>();
//            //var source = from so in db.Sources.Where (s => s.Status == 0) select so;
//            //var source = db.Sources.ToList();
//            //var a = source.FirstOrDefault();
//            //if(a != null)
//            //{
//            //    Console.WriteLine("bo to");

//            //}
//            //else
//            //{
//            //    Console.WriteLine("bo to 3");
//            //}
//            //foreach (var item in source)
//            //{
//            //    //var s = GetLinks(item);
//            //    //sources.Add();
//            //    db.SaveChanges();
//            //    item.Status = 1;
//            //}

//        }
//        public HashSet<string> GetLinks(Source source)
//        {
//            var web = new HtmlWeb();
//            HtmlDocument doc = web.Load("");
//            var nodeList = doc.QuerySelectorAll(source.SelectorSource);
//            HashSet<string> setLink = new HashSet<string>();
//            foreach (var node in nodeList)
//            {
//                var link = node.Attributes["href"].Value;
//                if (string.IsNullOrEmpty(link))
//                {
//                    continue;
//                }
//                setLink.Add(link);
//            }
//            return setLink;
//        }
//    }
//}
