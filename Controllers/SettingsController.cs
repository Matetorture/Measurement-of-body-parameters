using Microsoft.AspNetCore.Mvc;

namespace WebTest.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Import()
        {
            return View();
        }
    }
}
