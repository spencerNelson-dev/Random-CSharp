
using System.ComponentModel.DataAnnotations;

namespace web_scraper
{
    public class Advert
    {
        [Key]
        public int AdvertId {get; set;}

        public string AdvertUrl { get; set; }
        public string Make {get; set;}
        public string Model {get; set;}
        public uint Year { get; set; }
        public uint Price { get; set; }        
    }
}