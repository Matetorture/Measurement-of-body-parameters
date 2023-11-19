using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTest.Data;
using WebTest.Data.Tests;
using WebTest.Data.Users;
using WebTest.Repositories;

namespace WebTest.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsersRepository _repo;

        public UsersController(ApplicationDbContext context, IUsersRepository repo)
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

            var userEntity = _repo.Get(id);

            return View(_repo.Get(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Role,BloodType,Rh")] UserEntity userEntity)
        {
            _repo.Add(userEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            return View(_repo.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Role,BloodType,Rh")] UserEntity userEntity)
        {
            if (id != userEntity.Id)
            {
                return NotFound();
            }

            _repo.Update(userEntity);

            return RedirectToAction(nameof(Index)); ;
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
