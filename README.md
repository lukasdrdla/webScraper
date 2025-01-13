
# Web Scraper Project

Tento projekt je jednoduchý webový scraper napsaný v jazyce C# s využitím knihovny HtmlAgilityPack a Entity Framework Core. Scraper stahuje informace o knihách ze stránky Books to Scrape (https://books.toscrape.com/) a ukládá je do MySQL databáze.


# Požadavky
.NET 6 nebo novější

MySQL server

# Použité NuGet Balíčky
HtmlAgilityPack, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.Tools, Microsoft.EntityFrameworkCore.MySQL

## Nastavení
Klonování repozitáře

```bash
git clone https://github.com/lukasdrdla/webScraper
cd webScraper
```

Nastavení připojení k databázi (ApplicationDbContextFactory)
```bash
optionsBuilder.UseMySQL("server=localhost;database=webScraper;user=root;password=<HESLO>;");
```

Aplikujte migrace
```bash
dotnet ef database update
```

Spuštění aplikace
```bash
dotnet run
```
# Ukázka kódu

```bash
// Získání všech karet knih
var bookCards = doc.DocumentNode.SelectNodes("//li[contains(@class, 'col-xs-6')]");
```
```bash
// Získání názvu knihy
var title = bookCard.SelectSingleNode(".//h3/a")?.GetAttributeValue("title", string.Empty);
```

```bash
// Vytvoření nové knihy
var book = new Book
{
    Title = title?? "Unknown"
};
```

```bash
// Přidání knihy do DB a uložení
_context.Books.Add(book);
await _context.SaveChangesAsync();
```
