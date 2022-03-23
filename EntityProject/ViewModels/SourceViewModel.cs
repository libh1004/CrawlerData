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
        [Required(ErrorMessage = "Please enter list link.")]
        public string ListLink { get; set; }
        [Required(ErrorMessage = "Please enter information category.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter links selector.")]
        public string LinksSelector { get; set; }
        [Required(ErrorMessage = "Please enter selector title.")]
        public string SelectorTitle { get; set; }
        [Required(ErrorMessage = "Please enter selector content.")]
        public string SelectorContent { get; set; }
        [Required(ErrorMessage = "Please enter selector thumbnail.")]
        public string SelectorThumbnail { get; set; }
        [Required(ErrorMessage = "Please enter selector author.")]
        public string SelectorAuthor { get; set; }
        [Required(ErrorMessage = "Please enter information author.")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Please enter status.")]
        public int Status { get; set; }
       
    }
}