using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;

namespace website_scraper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        private readonly String websiteUrl = "https://www.slcpowersports.com/search?q=versys+650";
        private readonly ILogger<WebScraperController> _logger;

        // Constructor
        public WebScraperController(ILogger<WebScraperController> logger)
        {
            _logger = logger;
        }

        private async Task<List<dynamic>> GetPageData(string url, List<dynamic> results)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url);

            var motorcycleCards = document.QuerySelectorAll(".product-card");

            foreach( var card in motorcycleCards)
            {
                var MotoUrl = card.GetAttribute("href").ToString();
                //System.Console.WriteLine(card.ToHtml());
                System.Console.WriteLine(MotoUrl);
            }
            System.Console.WriteLine(motorcycleCards.Length);
           return results; 
        }

        [HttpGet]
        public async Task<List<dynamic>> Get()
        {
            var motorcycles = new List<dynamic>();

            var results = await GetPageData(websiteUrl, motorcycles);

            return results;
        }
    }
}