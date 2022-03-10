using CrawlerDataProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=ConnectionString")
        {

        }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}