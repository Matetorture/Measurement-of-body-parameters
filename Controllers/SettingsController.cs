using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTest.Models.Settings;

namespace WebTest.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new List<SettingsIndexVM> {
                new SettingsIndexVM { Id = 1, Name = "op1", Value = true },
                new SettingsIndexVM { Id = 2, Name = "op2", Value = false }
            };

            return View(viewModel);
        }

        public IActionResult Import()
        {
            return View();
        }
    }
}
