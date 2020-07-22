
using System.Collections.Generic;
using FindARide.Models;
using System.Threading.Tasks;
using System;
using AngleSharp;

namespace FindARide.Controlers
{
    public class AdvertControler
    {
        private List<string> _urls;

        public AdvertControler(List<string> urls)
        {
            _urls = urls;
        }

        public async Task<List<Advert>> GetAdverts(Scraper scraper)
        {
            var VersysResults = new List<Advert>();

            foreach (var url in _urls)
            {
                var versys = new Advert();

                versys.Url = url;

                var document = await scraper.GetWebsiteDocument(url);

                try
                {
                    versys.Title = document.QuerySelector(".product-single__title").InnerHtml;

                    versys.Price = document.QuerySelector(".product-single__price").InnerHtml;

                    versys.Description = document.QuerySelector(".product-single__description").InnerHtml
                        .Replace("&nbsp;", "\n");

                    if (versys.Description.Contains("***SOLD***"))
                    {
                        versys.Sold = true;
                    }
                    else
                    {
                        versys.Sold = false;
                    }


                }
                catch
                {
                    versys.Title = document.QuerySelector(".listingDetails-title").InnerHtml;

                    versys.Price= document.QuerySelector(".listingDetails-price").InnerHtml;

                    versys.Description = document.QuerySelector(".listingDescription-content").InnerHtml;
                }

                VersysResults.Add(versys);
            }

            return VersysResults;

        }


    }
}