using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using HtmlAgilityPack;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //var links = db.Links.Where(a => a.Status == 0).Include(a => a.Source).ToList();
            var sources = db.Sources.Where(s => s.Status == 0);
            foreach(var source in sources)
            {
                Console.WriteLine(source.ListLink);
            }
            //foreach (var item in links)
            //{
            //    var listLink = GetLinks(item.Source, item.Url);
            //    /**
            //     * Mô tả nội dung:
            //     * chưa hiểu rõ định làm gì ở đây.
            //     * nếu như cách hiểu:
            //     * sẽ có 1 danh sách link và sau đó sẽ lấy tiếp 1 danh sách link nữa
            //     * xong compare 2 cái vs nhau
            //     * chưa xdinhg đc mục đích sử dụng.
            //     * nếu như đoán thì là tránh trùng lặp những link đã có rồi
            //     * cái getLink là để xét link có trùng lặp hay ko 
            //     */
            //    foreach(var url in listLink)
            //    {
            //        //db.Links.Add(url);
            //        item.Status = 1;
            //        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            //        db.SaveChanges();
            //    }  
            //}
        }
        public HashSet<string> GetLinks(Source src, string url)
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            var source = src;
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
