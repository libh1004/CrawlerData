using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CrawlerDataProject.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        [HttpGet]
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            //Article article = db.Articles.Last();
            //ViewBag.LastId = article.Id;
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
            var articles = from a in db.Articles select a;
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(a => a.Author.Contains(searchString) || a.Content.Contains(searchString) || a.Description.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "id_desc":
                    articles = articles.OrderByDescending(a => a.Id);
                    break;
                default:
                    articles = articles.OrderBy(a => a.Id);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
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

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}