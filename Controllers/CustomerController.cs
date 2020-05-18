using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EcommerceApp2259.Models;
using EcommerceApp2259.Contexts;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace EcommerceApp2259.Controllers
{
    public class CustomerController : Controller
    {
        private readonly EcommerceApp2259IdentityDbContext _context;

        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        [ViewData]
        public List<Brand> Manufacturers { get; set; }

        [ViewData]
        public List<Category> Categories { get; set; }

        [ViewData]
        public List<Product> OfferedProducts { get; set; }

        public CustomerController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            EcommerceApp2259IdentityDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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

        [AllowAnonymous]
        public IActionResult Cart() => View();

        [Authorize]
        public async Task<IActionResult> UserDetail()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Authentication");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var newUser = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                Address = model.Address
            };
            var registerResult = await _userManager.CreateAsync(newUser, model.Password);
            if (registerResult.Succeeded)
            {
                await _signInManager.SignInAsync(user: newUser, isPersistent: false);
                return RedirectToAction("UserDetail");
            }
            return RedirectToAction("Authentication");
        }

        [AllowAnonymous]
        public IActionResult Authentication()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(
                userName: model.Email,
                password: model.Password,
                isPersistent: model.RememberMe,
                lockoutOnFailure: false
            );
            if (loginResult.Succeeded)
            {
                return RedirectToAction("UserDetail");
            }
            return RedirectToAction("Authentication");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Authentication");
        }
    }
}