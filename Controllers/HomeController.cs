using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        private readonly IConfiguration _config;

        [ViewData]
        public int ProductsCountPerPage { get; }

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

        [ViewData]
        public int PageNumber { get; set; }

        [ViewData]
        public int ProductsCount { get; set; }

        [ViewData]
        public List<Product> RecommendedProducts { get; set; }

        public HomeController(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
            ProductsCountPerPage = configuration.GetValue<int>("AppConf:ProductsPerPage");
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

        public IActionResult Index()
        {
            var queryable = _context.Product
                .Where(p => p.Stock != 0)
                .OrderByDescending(p => p.ViewsCount)
                .ThenByDescending(p => p.Stock);
            RecommendedProducts = queryable
                .Skip(3)
                .Take(3)
                .ToList();
            return View(queryable.Take(3).ToList());
        }

        public IActionResult Products(String keyword, int page = 0)
        {
            if (page < 0)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            var queryable = keyword == null ?
                _context.Product :
                _context.Product
                .Where(p => p.Title.Contains(keyword) || p.Category.Name.Contains(keyword) || p.Brand.Name.Contains(keyword));
            var products = queryable
                .OrderByDescending(p => p.ViewsCount)
                .Skip(page * ProductsCountPerPage)
                .Take(ProductsCountPerPage)
                .ToList();
            SearchValue = keyword ?? "";
            if (products.Count == 0)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            PageNumber = page;
            ProductsCount = queryable.Count();
            HeadLine = $"{ProductsCount} products found.";
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

        public IActionResult Category(int categoryId, int page = 0)
        {
            var queryable = _context.Product
                .Where(p => p.Category.CategoryId == categoryId)
                .OrderByDescending(p => p.ViewsCount);
            var category = _context.Category.Find(categoryId);
            if (category == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            PageNumber = page;
            ProductsCount = queryable.Count();
            HeadLine = $"Products by category {category.Name.ToLower()}.";
            ViewData["CategoryId"] = categoryId;
            return View("Index", queryable
                .Skip(page * ProductsCountPerPage)
                .Take(ProductsCountPerPage)
                .ToList());
        }

        public IActionResult Brand(int brandId, int page = 0)
        {
            var queryable = _context.Product
                .Where(p => p.Brand.BrandId == brandId)
                .OrderByDescending(p => p.ViewsCount);
            var brand = _context.Brand.Find(brandId);
            if (brand == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            PageNumber = page;
            ProductsCount = queryable.Count();
            HeadLine = $"Products by brand {brand.Name.ToLower()}.";
            ViewData["BrandId"] = brandId;
            return View("Index", queryable
                .Skip(page * ProductsCountPerPage)
                .Take(ProductsCountPerPage)
                .ToList());
        }

        public IActionResult PageNotFound() => View("NotFound");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}