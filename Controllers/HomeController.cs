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
        private readonly IProductServiceOperations _productService;
        private readonly IBrandServiceOperations _brandService;
        private readonly ICategoryServiceOperations _categoryService;

        public HomeController(ILogger<HomeController> logger,
            IProductServiceOperations productService,
            IBrandServiceOperations brandService,
            ICategoryServiceOperations categoryService)
        {
            _logger = logger;
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

#nullable enable
        public IActionResult Index(string? keyword)
        {
            var products = keyword == null ? _productService.Get() : _productService.Get(keyword);
            var brands = _brandService.Get();
            var categories = _categoryService.Get();
            // Console.WriteLine($"Found {brands.Count} brands and {categories.Count} categories in service.");
            ViewData["Manufacturers"] = brands;
            ViewData["Categories"] = categories;
            ViewData["OfferedProducts"] = products;
            return View(products);
        }

        public IActionResult ProductDetail(Guid productId)
        {
            ViewData["SimilarProducts"] = _productService.Get();
            var product = _productService.Get(productId);
            if (product == null) return NotFound();
            ViewData["Manufacturers"] = _brandService.Get();
            ViewData["Categories"] = _categoryService.Get();
            var products = _productService.Get();
            ViewData["OfferedProducts"] = products;
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