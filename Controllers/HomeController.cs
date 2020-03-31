using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceApp2259.Models;
using System;
using EcommerceApp2259.Context;
using System.Threading.Tasks;

namespace EcommerceApp2259.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductContext _context;
        // private List<Product> products = new List<Product>();

        public HomeController(ILogger<HomeController> logger, ProductContext ctx)
        {
            _logger = logger;
            _context = ctx;
            //products.Add(new Product(name: "iPhone X", price: 1000, createdDate: DateTime.Now, "smartphone", brand: "Apple"));
            //products.Add(new Product("iPhone 7", 1000, DateTime.Now, "smartphone", "Apple"));
            // Add(new Product("iPhone 8", 1000, DateTime.Now, "smartphone", "Apple"));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.getAll());
        }

        // public IActionResult ProductDetail(string productId)
        // {
        //     // var product = new Product("iPhone 7", 1000, DateTime.Now, "smartphone", "Apple");
        //     return View(product);
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
