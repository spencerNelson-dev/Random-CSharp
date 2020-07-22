using System;
using FindARide.Controlers;
using FindARide.Views;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Threading.Tasks;

namespace FindARide
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var query = "";

            foreach(var arg in args)
            {
                query += arg + " ";
            }

            query = System.Web.HttpUtility.HtmlEncode(query.Trim());

            var scraper = new Scraper();

            // SLC Power Sports
            Console.WriteLine("Scraping www.slcpowersports.com");

            var doc = await scraper.GetWebsiteDocument("https://www.slcpowersports.com/search?q=" + query);

            var urls = scraper.GetAdvertUrls(doc);

            var VLC = new AdvertControler(urls);

            var adverts = await VLC.GetAdverts(scraper);

            DisplayAdvertsOnConsole.Display(adverts);

            // KSL
            Console.WriteLine("Scraping KSL Classifieds");

            doc = await scraper.GetWebsiteDocument("https://classifieds.ksl.com/search/keyword/" + query);

            urls = scraper.GetAdvertUrls(doc);

            VLC = new AdvertControler(urls);

            adverts = await VLC.GetAdverts(scraper);

            DisplayAdvertsOnConsole.Display(adverts);

        }
    }
}
