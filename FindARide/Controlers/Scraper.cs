using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace FindARide.Controlers
{
    public class Scraper
    {
        private readonly IConfiguration _config;
        private readonly IBrowsingContext _context;
        private String _url;

        public Scraper()
        {
            _config = Configuration.Default.WithDefaultLoader();
            _context = BrowsingContext.New(_config);
            
        }

        public async Task<IDocument> GetWebsiteDocument(string url)
        {
            _url = url;
            return await _context.OpenAsync(url);
        }

        public List<String> GetAdvertUrls(IDocument document)
        {
            var links = new List<String>();

            var linksInDocument = document.QuerySelectorAll(".product-card");

            var baseUrl = "https://www.slcpowersports.com";

            if(linksInDocument.Length == 0)
            {
                linksInDocument = document.QuerySelectorAll(".listing-item-link");

                baseUrl = "https://classifieds.ksl.com/";
            }

            foreach (var link in linksInDocument)
            {
                links.Add( baseUrl + link.GetAttribute("href"));
            }

            return links;
        }

    }
}