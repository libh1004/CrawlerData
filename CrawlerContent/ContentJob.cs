//using CrawlerDataProject.Models;
//using CrawlerDataProject.Data;
//using HtmlAgilityPack;
//using Quartz;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace CrawlerContent
//{
//    public class ContentJob : IJob
//    {
//        MyDbContext db = new MyDbContext();
//        List<Article> listArticle = new List<Article>();
//        public async Task Execute(IJobExecutionContext context)
//        {
//            var filterLinkArticle = from a in db.Links.Where(ar => ar.Status == 0) select a;
//            var i = from a in db.Links.Where(ar => ar.Id == 1) select a;


//            using (var db = new MyDbContext())
//            {
//                var links = from url in db.Links.Where(li => li.Id == 1) select url;
//                var products = await context.products.ToListAsync(); nếu muốn dùng
//               async
//                var link = db.Links.FirstOrDefault(li => li.Id == 3);
//                Console.WriteLine(link);
//            }
//            Console.WriteLine(filterLinkArticle);
//            foreach (var item in filterLinkArticle)
//            {
//                var article = GetContent(item);
//                db.Articles.Add(article);
//                db.SaveChanges();
//                item.Status = 1;
//            }

//            Console.ReadLine();
//            Console.WriteLine("chay den day roi");
//        }
//        public Article GetContent(Link item)
//        {
//            var web = new HtmlWeb();
//            HtmlDocument doc = web.Load(item.Url);
//            var source = item.Source; // nếu ko lấy đc source theo link thì phải query get source by ;
//            //var sourceId = db.Sources.FirstOrDefault(ar => ar.Id == source.Id);
//            var titleNode = doc.QuerySelector(source.SelectorTitle);
//            var title = titleNode.InnerText;
//            var contentNode = doc.QuerySelector(source.SelectorContent);
//            var content = contentNode.InnerText;
//            var descriptionNode = doc.QuerySelector(source.SelectorDescription);
//            var description = descriptionNode.InnerText;
//            var thumbnailNode = doc.QuerySelector(source.SelectorThumbnail);
//            var thumbnail = thumbnailNode.Attributes["data-src"].Value;
//            var authorNode = doc.QuerySelector(source.SelectorAuthor);
//            var author = authorNode.InnerText;
//            Article art = new Article()
//            {
//                Url = item.Url,
//                Title = title,
//                Description = description,
//                Content = content,
//                Thumbnail = thumbnail,
//                Author = author
//            };
//            return art;
//            Console.ReadLine();
//        }

//    }
//}
