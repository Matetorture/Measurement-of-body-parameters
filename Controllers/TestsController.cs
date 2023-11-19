using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTest.Data;
using WebTest.Data.Tests;
using WebTest.Repositories;

namespace WebTest.Controllers
{
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
              return View(_repo.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Test == null)
            {
                return NotFound();
            }

            return View(_repo.Get(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUser,Name,Date,Description,SafeRange,Unit,ValueTemplate,TestType,BodyMeasure,Value")] TestEntity testEntity)
        {
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

            return View(_repo.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,Name,Date,Description,SafeRange,Unit,ValueTemplate,TestType,BodyMeasure,Value")] TestEntity testEntity)
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

            return View(_repo.Get(id));
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
    }
}
