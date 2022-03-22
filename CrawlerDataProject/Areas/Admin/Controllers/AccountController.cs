using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using CrawlerDataProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if (acc == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
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
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if(account == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(account);
            }
           
        }
        [HttpGet]
        public ActionResult Edit(int accountId)
        {
            if(accountId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account acc = db.Accounts.Find(accountId);
            if(acc == null)
            {
                return HttpNotFound();
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public List<Account> Search(string keyword)
        {
            if(keyword != null)
            {
                var result = from p in db.Accounts.Where(a => a.Phone.Equals(keyword)) select p;
                return result.ToList();
            }
            else
            {
                return db.Accounts.ToList();
            }
        }
        public ActionResult Register(AccountViewModel accountViewModel)
        {
            var acc = new Account()
            {
                Fullname = accountViewModel.Fullname,
                Password = accountViewModel.Password,
                Email = accountViewModel.Email,
                Phone = accountViewModel.Phone
            };
            db.Accounts.Add(acc);
            db.SaveChanges();
            return View(acc);
        }
        public ActionResult Login(string username, string password)
        {

            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}