using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.ViewModels
{
    public class SourceViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name source.")]
        public string Name { get; set; }
        public string ListLink { get; set; }
        public string SelectorSource { get; set; }
        public int CategoryId { get; set; }
        public string SelectorTitle { get; set; }
        public string SelectorContent { get; set; }
        public string SelectorThumbnail { get; set; }
        public string SelectorDescription { get; set; }
        public string SelectorAuthor { get; set; }
        public int Status { get; set; }

    }
}