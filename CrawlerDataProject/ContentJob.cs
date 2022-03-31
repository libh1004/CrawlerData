using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerDataProject
{
    public class ContentJob : IJob
    {
        MyDbContext db = new MyDbContext();
        public async Task Execute(IJobExecutionContext context)
        {
            List<Link> listLink = new List<Link>();
            //var links = from a in db.Links.Include("Models.Source").Where(ar => ar.Status == 0) select a;
            var links = db.Links.Where(a => a.Status == 0).Include(a => a.Source).ToList();
            foreach (var item in links)
            {
                var article = GetContent(item);
                db.Articles.Add(article);
                item.Status = 1;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Article GetContent(Link item)
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(item.Url);
            var source = item.Source; // nếu ko lấy đc source theo link thì phải query get source by ;
            var sourceId = db.Sources.FirstOrDefault(ar => ar.Id == source.Id);
            var titleNode = doc.QuerySelector(source.SelectorTitle);
            var title = titleNode.InnerText;
            var contentNode = doc.QuerySelector(source.SelectorContent);
            var content = contentNode.InnerText;
            var descriptionNode = doc.QuerySelector(source.SelectorDescription);
            var description = descriptionNode.InnerText;
            HtmlNode checkNode = doc.DocumentNode.SelectSingleNode(source.SelectorThumbnail);
            string thumbnail = null;
            if (checkNode != null)
            {
                var thumbnailNode = doc.QuerySelector(source.SelectorThumbnail);
                thumbnail = thumbnailNode.Attributes["data-src"].Value;
            }
            var authorNode = doc.QuerySelector(source.SelectorAuthor);
            var author = "";
            if(authorNode.InnerText.Length > 0)
            {
                author = authorNode.InnerText;
            }
            Article art = new Article()
            {
                Url = item.Url,
                Title = title,
                Description = description,
                Content = content,
                Thumbnail = thumbnail,
                Author = author,
                SourceId = source.Id
            };
            return art;
        }
    }
}