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
        public decimal Price { get; set; }
        public string Availability { get; set; } = string.Empty;
        public int Rating { get; set; }
        
    }
}