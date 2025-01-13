using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using webScraper.Data;
using webScraper.Models;

namespace webScraper.Services
{
    public class ScraperService
    {
        private readonly ApplicationDbContext _context;

        public ScraperService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ScrapeAndSaveBook(string url)
        {
            var client = new HttpClient();
            var html = await client.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Získání všech karet knih
            var bookCards = doc.DocumentNode.SelectNodes("//li[contains(@class, 'col-xs-6')]");

            if (bookCards != null)
            {
                foreach (var bookCard in bookCards)
                {
                    // Získání názvu knihy
                    var title = bookCard.SelectSingleNode(".//h3/a")?.GetAttributeValue("title", string.Empty);

                    var price = bookCard.SelectSingleNode(".//div//p[contains(@class, 'price_color')]");

                    var productLink = bookCard.SelectSingleNode(".//div[contains(@class, 'image_container')]/a")?.GetAttributeValue("href", string.Empty);

                    var availability = bookCard.SelectSingleNode(".//div//p[contains(@class, 'availability')]");

                    var rating = bookCard.SelectSingleNode(".//p[contains(@class, 'star-rating')]")?.GetAttributeValue("class", string.Empty);


                    var book = new Book
                    {
                        Title = title?? "Unknown",
                        Price = price?.InnerText?? "Unknown",
                        ProductLink = productLink?? "Unknown",
                        Availability = availability?.InnerText.Trim()?? "Unknown",
                        Rating = rating?.Replace("star-rating", "").Trim()?? "Unknown"
                    };

                    // Přidání knihy do DB a uložení
                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                Console.WriteLine("No books found");
            }
        }
    }
}