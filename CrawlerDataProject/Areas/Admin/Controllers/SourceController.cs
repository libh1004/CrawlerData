using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        private MyDbContext db = new MyDbContext();

        // GET: Admin/Articles
        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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
                sources = sources.Where(p => p.LinksSelector.Contains(searchString) || p.Name.Contains(searchString) 
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

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sources.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Source source = db.Sources.Find(id);
            if (source == null)
            {
                return HttpNotFound();
            }
            return View(source);
        }

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ListLink,LinksSelector,SelectorTitle" +
            ",SelectorContent,SelectorThumbnail,SelectorAuthor,AuthorId,Status")] Source source)
        {
            if (ModelState.IsValid)
            {
                db.Sources.Add(source);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(source);
        }

        // GET: Admin/Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(SourceViewModel sourceViewModel)
        {
            var source = new Models.Source()
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ListLink,LinksSelector,SelectorTitle" +
            ",SelectorContent,SelectorThumbnail,SelectorAuthor,AuthorId,Status")] Source source)
        {
            if (ModelState.IsValid)
            {
                db.Entry(source).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(source);
        }

        // GET: Admin/Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Source source = db.Sources.Find(id);
            if (source == null)
            {
                Name = sourceViewModel.Name
            };
            db.Sources.Add(source);
                return HttpNotFound();
            }
            return View(source);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Source source = db.Sources.Find(id);
            db.Sources.Remove(source);
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