using Microsoft.AspNetCore.Mvc;

namespace WebTest.Controllers
{
    public class TestsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Show()
        {
            return View();
        }
    }
}
