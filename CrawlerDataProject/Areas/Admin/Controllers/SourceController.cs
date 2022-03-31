using CrawlerDataProject.Data;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Threading.Tasks;
using HtmlAgilityPack;
using CrawlerDataProject.ViewModels;
using System.Collections.Generic;
using CrawlerDataProject.Models;

namespace CrawlerDataProject.Areas.Admin.Controllers
{

    public class SourceController : Controller
    {
        MyDbContext db = new MyDbContext();
        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var sources = from p in db.Sources
                          select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                sources = sources.Where(p => p.Name.Contains(searchString)
                || p.SelectorAuthor.Contains(searchString) || p.SelectorContent.Contains(searchString)
                || p.SelectorThumbnail.Contains(searchString) || p.SelectorTitle.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    sources = sources.OrderByDescending(p => p.Id);
                    break;
                default:
                    sources = sources.OrderBy(p => p.Id);
                    break;
            }
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(sources.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,SelectorSource, SelectorTitle" +
            ",SelectorContent,SelectorThumbnail, SelectorDescription, SelectorAuthor")] Models.Source source)
        {
            if (ModelState.IsValid)
            {
                var i = db.Sources.Add(source);
                db.SaveChanges();
                return Json(i);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult SaveUrl(List<Link> links)
        {
            foreach(var link in links)
            {
                db.Links.Add(link);
                db.SaveChanges();
            }
            return View("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ListLink,LinksSelector,SelectorTitle" +
            ",SelectorContent,SelectorThumbnail,SelectorAuthor,AuthorId,Status")] Models.Source source)
        {
            if (ModelState.IsValid)
            {
                db.Entry(source).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(source);
        }

        public ActionResult Delete(int? id)
        {
         
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetLinkDetailFromSourceLink(string link, string selector)
        {
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
      
    }
}