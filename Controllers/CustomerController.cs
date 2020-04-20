using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EcommerceApp2259.Models;
using EcommerceApp2259.Contexts;
using System.Collections.Generic;

namespace EcommerceApp2259.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationContext _context;

        [ViewData]
        public List<Brand> Manufacturers { get; set; }

        [ViewData]
        public List<Category> Categories { get; set; }

        [ViewData]
        public List<Product> OfferedProducts { get; set; }

        public CustomerController(ApplicationContext context)
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

        public IActionResult Cart() => View();
    }
}