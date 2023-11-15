using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTest.Data.Devices;
using WebTest.Data.Tests;
using WebTest.Data.Users;

namespace WebTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<DeviceEntity> Device {  get; set; }
        public DbSet<TestEntity> Test { get; set; }
        public DbSet<UserEntity> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}