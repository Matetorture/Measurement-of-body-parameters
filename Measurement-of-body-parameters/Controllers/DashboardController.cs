using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTest.Data;
using WebTest.Models.Dashboard;

namespace WebTest.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _context.Users
                .Include(n => n.Tests)
                .Include(n => n.Devices)
                .Include(n => n.Profile)
                .FirstOrDefault(n => n.UserName == User.Identity.Name);

            DateTime lastTestDate;
            if (user.Tests != null && user.Tests.Any())
            {
                lastTestDate = user.Tests.Max(test => test.Date);
            }
            else
            {
                lastTestDate = DateTime.Now;
            }
            int connectedDevicesCount;
            if (user.Devices != null && user.Devices.Any())
            {
                connectedDevicesCount = user.Devices.Count(device => device.Connect);
            }
            else
            {
                connectedDevicesCount = 0;
            }

            return View(new DashboardIndexVM()
            {
                User = user,
                LastTestDate = lastTestDate,
                ConnectedDevices = connectedDevicesCount
            });
        }
    }
}
