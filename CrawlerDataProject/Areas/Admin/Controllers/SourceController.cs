using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using CrawlerDataProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrawlerDataProject.Controllers
{
    public class SourceController : Controller
    {
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
            var source = new Source()
            {

            };
            db.Sources.Add(source);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}