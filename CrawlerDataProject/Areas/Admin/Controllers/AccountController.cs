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
        [HttpGet]
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
        public ActionResult Create(AccountViewModel acc)
        {
            Account account = new Account()
            {
                Fullname = acc.Fullname,
                Email = acc.Email,
                Password = acc.Password,
                Phone = acc.Phone
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int accountId)
        {
            var account = db.Accounts.Find(accountId);
            return View(account);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Account account, int accountId)
        {
            var acc = db.Accounts.Find(accountId);

            return RedirectToAction("Index");
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Delete(int accountId)
        {
            var account = db.Accounts.Find(accountId);
            db.Accounts.Remove(account);
            return RedirectToAction("Index");
        }
    }
}