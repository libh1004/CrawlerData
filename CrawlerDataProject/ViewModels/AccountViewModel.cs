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
        [Required(ErrorMessage = "Please enter fullname")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter phone")]
        public string Phone { get; set; }
    }
}