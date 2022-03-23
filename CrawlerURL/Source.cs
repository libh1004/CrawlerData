using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerURL
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ListLink { get; set; }
        public int CategoryId { get; set; }
        public string LinksSelector { get; set; }
        public string SelectorTitle { get; set; }
        public string SelectorContent { get; set; }
        public string SelectorThumbnail { get; set; }
        public string SelectorAuthor { get; set; }
        public int AuthorId { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}
