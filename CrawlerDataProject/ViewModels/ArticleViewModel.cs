using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter content.")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Please enter thumbnail.")]
        public string Thumbnail { get; set; }
        [Required(ErrorMessage = "Please enter author.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please enter sourceId.")]
        public int SourceId { get; set; }
    }
}