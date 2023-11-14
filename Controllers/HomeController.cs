using Microsoft.AspNetCore.Mvc;

namespace Allup_Template.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
