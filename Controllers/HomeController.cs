using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceApp2259.Models;
using System;
using EcommerceApp2259.Services;

namespace EcommerceApp2259.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServiceOperations _productCtx;

        public HomeController(ILogger<HomeController> logger, IProductServiceOperations service)
        {
            _logger = logger;
            _productCtx = service;
        }

#nullable enable
        public IActionResult Index(string? keyword)
        {
            var products = keyword == null ? _productCtx.Get() : _productCtx.Get(keyword);

            ViewData["ItemsPerRow"] = 5;
            return View(products);
        }

        public IActionResult ProductDetail(Guid productId)
        {
            if (productId == null) return NotFound();
            var product = _productCtx.Get(productId);
            if (product == null) return NotFound();
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
