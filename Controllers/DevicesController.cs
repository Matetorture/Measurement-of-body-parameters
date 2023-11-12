using Microsoft.AspNetCore.Mvc;

namespace WebTest.Controllers
{
    public class DevicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pairing()
        {
            return View();
        }

        public IActionResult Preview()
        {
            return View();
        }
    }
}
