using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTest.Models.ViewModels.Tests;

namespace WebTest.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {

        public IActionResult Index()
        {

            var viewModel = new List<TestsIndexVM> {
                new TestsIndexVM { Id = 1, TestDate = DateTime.Now, Pulse = 75, Saturation = 98, Weight = 70, Height = 180, BodyCircumference = 100, AdditionalObservations = "No issues", Glucose = 90 },
                new TestsIndexVM { Id = 2, TestDate = DateTime.Now.AddDays(-1), Pulse = 80, Saturation = 99, Weight = 72, Height = 175, BodyCircumference = 98, AdditionalObservations = "Stable", Glucose = 95 }
            };

            return View(viewModel);
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
