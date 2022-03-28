using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public Source Source { get; set; }
    }
}