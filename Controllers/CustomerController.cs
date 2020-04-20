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
            Manufacturers = _context.Brand.ToList();
            Categories = _context.Category.ToList();
            OfferedProducts = _context.Product.ToList();
            _context.ProductImage.ToList();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}