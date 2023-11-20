using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTest.Data;
using WebTest.Models.Profile;

namespace WebTest.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
