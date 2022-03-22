using CrawlerURL;
using HtmlAgilityPack;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CrawlerContent
{
    public class ContentJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            List<Article> articles = new List<Article>();
            //var filterData = from a in db.Articles.Where(ar => ar.Status == 0) select a;
            //foreach (var item in filterData)
            //{
            //    // day la 1 object nhung khi ben kia 
            //    articles.Add(new HelloJob().GetContent(item.Url));
            //    db.Articles.Add(new HelloJob().GetContent(item.Url));
            //    item.Status = 1;
            //    db.SaveChanges();

            //}
            // save in db
        }
        // ben nay dang nhan vao 1 string ==!
        // khi do nhan vao day phai la 1 url =)))
        public Article GetContent(string url)
        {
            var web = new HtmlWeb();
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
                Title = title,
                Description = desc,
                Content = content,
                Thumbnail = thumbnail,
                Author = author
            };
            return article;
        }
    }
}
