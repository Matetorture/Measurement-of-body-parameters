using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTest.Data;
using WebTest.Data.Tests;
using WebTest.Repositories;

namespace WebTest.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITestsRepository _repo;

        public TestsController(ApplicationDbContext context, ITestsRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_repo.GetAll(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpGet]
        public async Task<IActionResult> Graph()
        {
            return View(_repo.GetAll(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Test == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tests = _repo.Get(id);

            if (tests == null || tests.UserId != userId)
            {
                return NotFound();
            }

            return View(tests);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Name,Date,Description,TestType,BodyMeasure,Value")] TestEntity testEntity)
        {
            testEntity.UserId = _context.User
                .FirstOrDefault(n => n.UserName == User.Identity.Name).Id;
            testEntity.Date = DateTime.Now;

            _repo.Add(testEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Test == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tests = _repo.Get(id);

            if (tests == null || tests.UserId != userId)
            {
                return NotFound();
            }

            return View(tests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name,Date,Description,TestType,BodyMeasure,Value")] TestEntity testEntity)
        {
            if (id != testEntity.Id)
            {
                return NotFound();
            }
            
            _repo.Update(testEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Test == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tests = _repo.Get(id);

            if (tests == null || tests.UserId != userId)
            {
                return NotFound();
            }

            return View(tests);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Test == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Test'  is null.");
            }

            _repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetEnumValues()
        {
            return Json(Enum.GetNames(typeof(TestType)));
        }
    }
}
