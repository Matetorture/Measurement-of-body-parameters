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
using WebTest.Data.Devices;
using WebTest.Data.Tests;
using WebTest.Repositories;

namespace WebTest.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDevicesRepository _repo;

        public DevicesController(ApplicationDbContext context, IDevicesRepository repo)
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
            if (id == null || _context.Device == null)
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
        public async Task<IActionResult> Create([Bind("Id,UserId,PairingDate,Name,Connect")] DeviceEntity deviceEntity)
        {
            deviceEntity.UserId = _context.User
                .FirstOrDefault(n => n.UserName == User.Identity.Name).Id;
            deviceEntity.PairingDate = DateTime.Now;

            _repo.Add(deviceEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Device == null)
            {
                return NotFound();
            }

            return View(_repo.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PairingDate,Name,Connect")] DeviceEntity deviceEntity)
        {
            if (id != deviceEntity.Id)
            {
                return NotFound();
            }

            _repo.Update(deviceEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Device == null)
            {
                return NotFound();
            }

            return View(_repo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Device == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Device'  is null.");
            }

            _repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
