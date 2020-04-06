using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp2259.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Name"] = "Pham Do Nhat Minh";
            ViewData["StudentId"] = 2172259;
            ViewData["University"] = "Hoa Sen University";
            ViewData["Class"] = "Web Developing 19.2A";
            return View();
        }
    }
}