using System;
using FindARide.Controlers;
using FindARide.Views;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FindARide.Models
{
    public class Website
    {
        public string BaseUrl { get; set; }
        public AngleSharp.Dom.IDocument BaseDocument { get; set; }
        public List<string> AdvertUrls { get; set; }
    }
}