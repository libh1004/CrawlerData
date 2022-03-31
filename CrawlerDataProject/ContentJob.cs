using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using HtmlAgilityPack;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CrawlerDataProject
{
    public class ContentJob : IJob
    {
        MyDbContext db = new MyDbContext();
        public async Task Execute(IJobExecutionContext context)
        {
            List<Link> listLink = new List<Link>();
            var articles = from a in db.Links.Where(ar => ar.Status == 0) select a;
            foreach (var item in articles)
            {
                
                db.Articles.Add(GetContent(item));
                item.Status = 1;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Article GetContent(Link item)
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(item.Url);
            Debug.WriteLine(item.Url);
            var source = item.Source;
            Debug.WriteLine(source.ToString());
            // nếu ko lấy đc source theo link thì phải query get source by ;
            //var sourceId = db.Sources.FirstOrDefault(ar => ar.Id == source.Id);
            var titleNode = doc.QuerySelector(source.SelectorTitle);
            var title = titleNode.InnerText;
            Debug.WriteLine("Title"+title.ToString());
            var contentNode = doc.QuerySelector(source.SelectorContent);
            var content = contentNode.InnerText;
            Debug.WriteLine("content" + content.ToString());
            var descriptionNode = doc.QuerySelector(source.SelectorDescription);
            var description = descriptionNode.InnerText;
            Debug.WriteLine("desc" + description.ToString());
            var thumbnailNode = doc.QuerySelector(source.SelectorThumbnail);
            var thumbnail = thumbnailNode.Attributes["data-src"].Value;
            var authorNode = doc.QuerySelector(source.SelectorAuthor);
            var author = authorNode.InnerText;
            Debug.WriteLine("Author" + author.ToString());
            Article art = new Article()
            {
                Url = item.Url,
                Title = title,
                Description = description,
                Content = content,
                Thumbnail = thumbnail,
                Author = author
            };
            return art;
            Console.ReadLine();
        }
    }
}