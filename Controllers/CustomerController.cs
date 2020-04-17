using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp2259.Controllers
{
    public class CustomerController : Controller {
        public IActionResult Cart()
        {
            return View();
        }
    }
}