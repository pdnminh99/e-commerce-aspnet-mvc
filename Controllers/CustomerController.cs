using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EcommerceApp2259.Models;
using System;
// using EcommerceApp2259.Contexts;
using EcommerceApp2259.Areas.Identity.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;


namespace EcommerceApp2259.Controllers
{
    public class CustomerController : Controller
    {
        private readonly EcommerceApp2259IdentityDbContext _context;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly UserManager<IdentityUser> _userManager;

        [ViewData]
        public List<Brand> Manufacturers { get; set; }

        [ViewData]
        public List<Category> Categories { get; set; }

        [ViewData]
        public List<Product> OfferedProducts { get; set; }

        public CustomerController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
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

        public IActionResult Cart() => View();

        public IActionResult UserDetail()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var newUser = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var registerResult = await _userManager.CreateAsync(newUser, model.Password);
            if (registerResult.Succeeded)
            {
            //     var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            //     var callbackUrl = Url.EmailConfirmationLink(newUser.Id, code, Request.Scheme);
            //     await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

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
            return RedirectToAction("SignIn");
        }
    }
}