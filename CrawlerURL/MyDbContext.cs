
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrawlerURL
{
    public class LinhDbContext : DbContext
    {
        public LinhDbContext() : base("name=ConnectionString")
        {

        }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Link> Links { get; set; }
    }

    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Link> ListLink { get; set; }
        public string SelectorSource { get; set; }
        public int CategoryId { get; set; }
        public string SelectorTitle { get; set; }
        public string SelectorContent { get; set; }
        public string SelectorDescription { get; set; }
        public string SelectorThumbnail { get; set; }
        public string SelectorAuthor { get; set; }
        public int Status { get; set; }
    }
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public Source Source { get; set; }
    }
}