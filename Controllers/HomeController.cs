using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceApp2259.Models;
using System;
using EcommerceApp2259.Services;
using EcommerceApp2259.Context;

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

            _productCtx.Add(new Product(productId: Guid.NewGuid(), title: "iPhone X", owner: null, createdDate: DateTime.Now, category: "Smartphone", brand: "Apple", price: 999));

            _productCtx.Add(new Product(productId: Guid.NewGuid(), title: "iPhone 8", owner: null, createdDate: DateTime.Now, category: "Smartphone", brand: "Apple", price: 599));

            _productCtx.Add(new Product(productId: Guid.NewGuid(), title: "Pixel XL", owner: null, createdDate: DateTime.Now, category: "Smartphone", brand: "Google", price: 499));
        }

#nullable enable
        public IActionResult Index(string? keyword)
        {
            var products = keyword == null ? _productCtx.Get() : _productCtx.Get(keyword);
            return View(products);
        }

        public IActionResult ProductDetail(Guid productId)
        {
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
