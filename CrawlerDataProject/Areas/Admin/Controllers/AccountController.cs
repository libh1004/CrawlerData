using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using CrawlerDataProject.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CrawlerDataProject.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        MyDbContext db = new MyDbContext();
        [HttpGet]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.ListAccount = this.db.Accounts.ToList();

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

            var accounts = from p in db.Accounts
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                accounts = accounts.Where(p => p.Fullname.Contains(searchString) || p.Email.Contains(searchString) || p.Phone.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "id_desc":
                    accounts = accounts.OrderByDescending(p => p.Id);
                    break;
                default:
                    accounts = accounts.OrderBy(p => p.Id);
                    break;
            }

            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(accounts.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["Id"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var account = this.db.Accounts.Find(int.Parse(id));
                this.db.Accounts.Remove(account);
                this.db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account acc)
        {
            if (acc == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(AccountViewModel acc)
        //{
        //    if (acc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        Account account = new Account()
        //        {
        //            Fullname = acc.Fullname,
        //            Email = acc.Email,
        //            Password = acc.Password,
        //            Phone = acc.Phone,
        //            Thumbnail = acc.Thumbnail
        //        };
        //        db.Accounts.Add(account);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View("Login");
        //}
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
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
            return null;
        }
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> idDelete)
        {
            foreach (var item in idDelete)
            {
                return View(db.Accounts.ToList());
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = db.Accounts.Where(a => a.Email == username && a.Password == password).ToList();
                if(user.Count() > 0)
                {
                    Session["Email"] = user.FirstOrDefault().Email;
                    Session["Password"] = user.FirstOrDefault().Password;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
