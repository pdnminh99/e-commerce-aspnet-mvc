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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // _context = ctx;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("iPhone X", 1000, DateTime.Now, "smartphone", "Apple"));
            products.Add(new Product("iPhone X", 1000, DateTime.Now, "smartphone", "Apple"));
            products.Add(new Product("iPhone X", 1000, DateTime.Now, "smartphone", "Apple"));
            // if (displayProduct == null)
            // {
            //     return NotFound();
            // }
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
