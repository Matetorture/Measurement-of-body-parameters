using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTest.Data.Tests;
using WebTest.Models.Tests;

namespace WebTest.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {

        public IActionResult Index()
        {

            var viewModel = new List<TestsIndexVM>
            {
                new TestsIndexVM(
                    "Test 1",
                    "Description 1",
                    10.0,
                    "kg",
                    "Template 1",
                    TestType.Pulse,
                    BodyMeasure.Arm,
                    "Value 1"
                ),
                new TestsIndexVM(
                    "Test 2",
                    "Description 2",
                    15.0,
                    "lbs",
                    "Template 2",
                    TestType.Weight,
                    BodyMeasure.Chest,
                    "Value 2"
                )
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
