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
            Manufacturers = _context.Brand
                .OrderByDescending(b => b.Products.Count)
                .ThenBy(b => b.Name)
                .ToList();
            Categories = _context.Category
                .OrderByDescending(c => c.Products.Count)
                .ThenBy(c => c.Name)
                .ToList();
            OfferedProducts = _context.Product
                .Where(p => p.ProductImage != null && p.ProductImage.Count > 0 && p.Stock > 0)
                .OrderByDescending(p => p.ViewsCount)
                .Take(5)
                .ToList();
        }

        public IActionResult Index() => View(
                _context.Product
                .Where(p => p.Stock != 0)
                .OrderByDescending(p => p.ViewsCount)
                .ThenByDescending(p => p.Stock)
                .ToList());

        public IActionResult Products(String keyword)
        {
            var products = keyword == null ?
                _context.Product
                .ToList() :
                _context.Product.Where(p => p.Title.Contains(keyword) || p.Category.Name.Contains(keyword) || p.Brand.Name.Contains(keyword))
                .ToList();
            SearchValue = keyword ?? "";
            HeadLine = $"{products.Count} products found.";
            return View("Index", products);
        }

        public IActionResult ProductDetail(Guid productId)
        {
            var product = _context.Product.Find(productId);
            if (product != null)
            {
                SimilarProducts = _context.Product
                    .Where(p => p.ProductId != product.ProductId && p.Category.CategoryId == product.Category.CategoryId)
                    .Take(3)
                    .ToList();
                product.ViewsCount += 1;
                _context.Product.Update(product);
                _context.SaveChanges();
                return View(product);
            }
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

        public IActionResult PageNotFound() => View("NotFound");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}