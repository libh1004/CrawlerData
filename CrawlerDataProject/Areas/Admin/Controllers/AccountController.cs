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
        [HttpGet] //truyền  vào 
        public ActionResult Create(){
            return View();
        }
        [HttpPost] // Gui di
        public ActionResult Create(AccountViewModel acc)
        {
            Account account = new Account()
            {
                Fullname = acc.Fullname,
                Password = acc.Password,
                Email = acc.Email,
                Phone = acc.Phone 
            };
            db.Accounts.Add(account); //them vao db 
            db.SaveChanges(); //luu vao db 
            return RedirectToAction("Index"); // quay ve va show ra danh sach 
        }
    }
}