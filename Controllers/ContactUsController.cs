using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp2259.Controllers
{
    public class ContactUsController : Controller
    {
        [ViewData]
        public string Name => "Pham Do Nhat Minh";

        [ViewData]
        public int StudentId => 2172259;

        [ViewData]
        public string University => "Hoa Sen University";

        [ViewData]
        public string Class => "Web Developing 19.2A";

        public IActionResult Index() => View();
    }
}