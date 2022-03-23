using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using CrawlerDataProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrawlerURL;
using CrawlerContent;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using HtmlAgilityPack;

namespace CrawlerDataProject.Areas.Admin.Controllers
{

    public class SourceController : Controller
    {
        HelloJob helloJob = new HelloJob();
        ContentJob contentJob = new ContentJob();

        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View(db.Sources.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SourceViewModel sourceViewModel)
        {
            var source = new Models.Source()
            {
                Name = sourceViewModel.Name
            };
            db.Sources.Add(source);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var source = db.Sources.Find(id);
            return View(source);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Source updateSource)
        {
            db.Entry(updateSource).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id, string source)
        {
            return View(helloJob.GetLinks(source));

        }
        public ActionResult GetArticle()
        {
            var sources = from s in db.Sources select s;
            Debug.WriteLine(sources);
            foreach (var source in sources)
            {
                foreach (var item in source.ListLink)
                {
                    if (item.Status == 0)
                    {
                        contentJob.GetContent(item.Url);
                        item.Status = 1;
                    }
                }
            }
            return View("Index");
        }
        [HttpGet]
        public async Task<ActionResult> GetLinkDetailFromSourceLink(string link, string selector)
        {
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync(link);
            //if (response.IsSuccessStatusCode) {
            //    var content = response.Content.ReadAsStringAsync();
            //    return Json(new { 
            //        responseContent = content
            //    }, JsonRequestBehavior.AllowGet);
            //}
            var url = link;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var listLink = doc.QuerySelectorAll(selector);
            HashSet<string> setLink = new HashSet<string>();
            foreach (var node in listLink)
            {
                var itemLink = node.Attributes["href"].Value;
                if (string.IsNullOrEmpty(itemLink))
                {
                    continue;
                }
                setLink.Add(itemLink);
            }
            return Json(new
            {
                links = setLink.ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetArticleDetailFromSelector(
            string linkDetail,
            string titleSelector,
            string descriptionSelector,
            string thumbnailSelector,
            string contentSelector)
        {
            var url = linkDetail;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var title = doc.QuerySelector(titleSelector).InnerText;
            var description = doc.QuerySelector(descriptionSelector).InnerText;
            var content = doc.QuerySelector(contentSelector).InnerText;
            var image = doc.QuerySelector(thumbnailSelector).Attributes["data-src"];
            // try catch xử lý lỗi            
            return Json(new
            {
                title = title,
                description = description,
                content = content,
                image = image
            }, JsonRequestBehavior.AllowGet);
        }
    }

}