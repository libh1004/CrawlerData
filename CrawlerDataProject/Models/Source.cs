using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.Models
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Link> ListLink { get; set; }
        public int CategoryId { get; set; }
        public string SelectorTitle{ get; set; }
        public string SelectorContent { get; set; }
        public string SelectorThumbnail { get; set; }
        public string SelectorAuthor { get; set; }
        public int AuthorId { get; set; }
    }
}