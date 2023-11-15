using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTest.Data.Devices;

namespace WebTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<DeviceEntity> Device {  get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}