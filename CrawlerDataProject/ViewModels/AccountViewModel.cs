using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerDataProject.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
       
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Thumbnail { get; set; }
    }
}