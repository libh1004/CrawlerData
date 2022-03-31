using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter fullname.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter phone.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter thumbnail.")]
        public string Thumbnail { get; set; }
    }
}