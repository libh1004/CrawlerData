using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter information article.")]
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Please enter information account.")]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }
    }
}