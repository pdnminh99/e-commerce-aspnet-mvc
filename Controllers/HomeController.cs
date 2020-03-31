using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceApp2259.Models;
using System.Collections.Generic;
using System;

namespace EcommerceApp2259.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly ProductContext _context;
        private List<Product> products = new List<Product>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // _context = ctx;
            products.Add(new Product(name: "iPhone X", price: 1000, createdDate: DateTime.Now, "smartphone", brand: "Apple"));
            products.Add(new Product("iPhone 7", 1000, DateTime.Now, "smartphone", "Apple"));
            products.Add(new Product("iPhone 8", 1000, DateTime.Now, "smartphone", "Apple"));
        }

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult ProductDetail(string productId)
        {
            Console.WriteLine(productId);
            Guid uuid = Guid.Parse(productId);
            foreach (var p in products)
            {
                Console.WriteLine($"{uuid} compare to {p.ProductId}. Result {uuid == p.ProductId}");
                if (uuid == p.ProductId)
                {
                    return View(p);
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
