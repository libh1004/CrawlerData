using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using CrawlerDataProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrawlerDataProject.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AccountViewModel account)
        {
            var accounts = new Account()
            {
                Fullname = account.Fullname,
                Password = account.Password,
                Email = account.Email,
                Phone = account.Phone
            };
            db.Accounts.Add(accounts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}