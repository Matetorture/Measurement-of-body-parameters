using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTest.Data;
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

            return View(new ProfileIndexVM()
            {
                User = user
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserEntity user)
        {
            user.Profile.UserId = _context.User
                .FirstOrDefault(n => n.UserName == User.Identity.Name).Id;

            _repo.Add(user);

            return RedirectToAction(nameof(Index));
        }
    }
}
