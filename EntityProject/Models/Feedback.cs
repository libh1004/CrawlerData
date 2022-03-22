using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ArticleId { get; set; }
        public string Description { get; set; }
    }
}