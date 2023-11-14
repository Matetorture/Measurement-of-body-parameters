using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTest.Models.Devices;
using WebTest.Data.Devices;

namespace WebTest.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new List<DevicesIndexVM> {
                new DevicesIndexVM(1, "x1", false ),
                new DevicesIndexVM(2, "x2", true )
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
