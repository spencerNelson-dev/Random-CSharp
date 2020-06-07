using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        public List<ProductModel> products { get; set; }

        public ProductController()
        {

        }

        
        [HttpGet]
        public IActionResult Index()
        {
            var test = new ProductModel() { Id = 1, Name = "Boots" };
            var products = new List<ProductModel>();
            products.Add(test);

            return Json(products);
        }
    }
}