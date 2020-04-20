using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceApp2259.Models;
using EcommerceApp2259.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceApp2259.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        [ViewData]
        public List<Brand> Manufacturers { get; set; }

        [ViewData]
        public List<Category> Categories { get; set; }

        [ViewData]
        public List<Product> OfferedProducts { get; set; }

        [ViewData]
        public List<Product> SimilarProducts { get; set; }

        [ViewData]
        public string SearchValue { get; set; }

        [ViewData]
        public string HeadLine { get; set; }

        public HomeController(ApplicationContext context)
        {
            _context = context;
            Manufacturers = _context.Brand.ToList();
            Categories = _context.Category.ToList();
            OfferedProducts = _context.Product.ToList();
            SimilarProducts = OfferedProducts;
            _context.ProductImage.ToList();
        }

        public IActionResult Index() => View(OfferedProducts);

        public IActionResult Products(String keyword)
        {
            var products = keyword == null ?
                _context.Product.ToList() :
                _context.Product.Where(p => p.Title.Contains(keyword)).ToList();
            SearchValue = keyword ?? "";
            HeadLine = $"{products.Count} products found.";
            return View("Index", products);
        }

        public IActionResult ProductDetail(Guid productId)
        {
            var product = _context.Product.Find(productId);
            if (product != null) return View(product);
            Response.StatusCode = 404;
            return View("NotFound");
        }

        public IActionResult Category(int categoryId)
        {
            var category = _context.Category.Find(categoryId);
            if (category == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            HeadLine = $"Products by category {category.Name}.";
            return View("Index", category.Products);
        }

        public IActionResult Brand(int brandId)
        {
            var brand = _context.Brand.Find(brandId);
            if (brand == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            HeadLine = $"Products by brand {brand.Name}.";
            return View("Index", brand?.Products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}