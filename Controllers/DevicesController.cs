using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTest.Models.ViewModels.Devices;

namespace WebTest.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new List<DevicesIndexVM> {
                new DevicesIndexVM { Id = 1, TestDate = DateTime.Now, Name = "x1", Connect = false },
                new DevicesIndexVM { Id = 2, TestDate = DateTime.Now.AddDays(-1), Name = "x2", Connect = true }
            };

            return View(viewModel);
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
