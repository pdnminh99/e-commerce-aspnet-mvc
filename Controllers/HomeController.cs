using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceApp2259.Models;
using System;
using System.Collections.Generic;
using EcommerceApp2259.Services;

namespace EcommerceApp2259.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServiceOperations _service;
        private readonly List<String> _manufacturers = new List<string>();
        private readonly List<String> _categories = new List<string>();

        public HomeController(ILogger<HomeController> logger, IProductServiceOperations service)
        {
            _logger = logger;
            _service = service;
            _manufacturers.Add("Samsung");
            _manufacturers.Add("Daewoo");
            _manufacturers.Add("Fujitsu Siemens");
            _manufacturers.Add("Motorola");
            _manufacturers.Add("Phillips");
            _manufacturers.Add("Beko");
            _categories.Add("Motherboards");
            _categories.Add("Desktops");
            _categories.Add("Laptops");
            _categories.Add("Notebooks");
        }

#nullable enable
        public IActionResult Index(string? keyword)
        {
            var products = keyword == null ? _service.Get() : _service.Get(keyword);
            ViewData["Manufacturers"] = _manufacturers;
            ViewData["Categories"] = _categories;
            return View(products);
        }

        public IActionResult ProductDetail(Guid productId)
        {
            ViewData["SimilarProducts"] = _service.Get();
            var product = _service.Get(productId);
            if (product == null) return NotFound();
            ViewData["Manufacturers"] = _manufacturers;
            ViewData["Categories"] = _categories;
            return View(product);
        }

        // public IActionResult Category(string categoryId)
        // {
        //     if (categoryId == null)
        //     {
        //         return NotFound();
        //     }
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}