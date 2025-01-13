using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webScraper.Data;
using webScraper.Services;

var serviceProvider = new ServiceCollection()
    .AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseMySQL("server=localhost;database=webScraper;user=root;");
    })
    .AddScoped<ScraperService>()
    .BuildServiceProvider();


var scraperService = serviceProvider.GetRequiredService<ScraperService>();

string url = "https://books.toscrape.com/";
await scraperService.ScrapeAndSaveBook(url);

Console.WriteLine("Book scraped and saved");