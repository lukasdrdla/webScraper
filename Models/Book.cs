using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webScraper.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ProductLink { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Availability { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        
    }
}