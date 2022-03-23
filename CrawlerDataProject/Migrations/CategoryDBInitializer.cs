using CrawlerDataProject.Data;
using CrawlerDataProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.Migrations
{
    public class CategoryDBInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            IList<Category> categories = new List<Category>();
            categories.Add(new Category() { Name = "Doi song" });
            categories.Add(new Category() { Name = "Kinh te" });
            categories.Add(new Category() { Name = "Khoa hoc" });
            categories.Add(new Category() { Name = "Phap luat" });
            categories.Add(new Category() { Name = "Giai tri" });
            context.Categories.AddRange(categories);
            base.Seed(context);
        }
    }
}