using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using WebTest.Data;
using WebTest.Data.Profiles;
using WebTest.Data.Tests;
using WebTest.Data.Users;
using WebTest.Models.Profile;
using WebTest.Repositories;

namespace WebTest.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsersRepository _repo;

        public ProfileController(ApplicationDbContext context, IUsersRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _context.User
                .Include(n => n.Profile)
                .FirstOrDefault(n => n.UserName == User.Identity.Name);

            return View(new ProfileIndexVM()
            {
                User = user
            });
        }

        public IActionResult Create()
        {
            var user = _context.User
                .Include(n => n.Profile)
                .FirstOrDefault(n => n.UserName == User.Identity.Name);

            if(user == null)
            {
                Edit();
            }

            return View(new ProfileIndexVM()
            {
                User = user
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ProfileIndexVM user)
        {
            ProfileEntity profileEntity = new ProfileEntity()
            {
                UserId = _context.User
                .FirstOrDefault(n => n.UserName == User.Identity.Name).Id,
                BloodType = 0,
                Rh = false
            };

            _repo.Add(profileEntity);

            return RedirectToAction(nameof(Edit));
        }

        public IActionResult Edit()
        {
            var user = _context.User
                .Include(n => n.Profile)
                .FirstOrDefault(n => n.UserName == User.Identity.Name);

            return View(new ProfileIndexVM()
            {
                User = user
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id,FirstName,LastName")] UserEntity user)
        {
            _repo.UpdateUser(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEntity user)
        {
            _repo.Update(user.Profile);

            return RedirectToAction(nameof(Index));
        }
    }
}
