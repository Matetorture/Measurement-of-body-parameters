using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTest.Data.Devices;
using WebTest.Data.Tests;
using WebTest.Data.Users;
using WebTest.Data.Profiles;

namespace WebTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public DbSet<DeviceEntity> Device {  get; set; }
        public DbSet<TestEntity> Test { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProfileEntity> Profile { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>()
                .HasMany(n => n.Tests)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId);

            builder.Entity<UserEntity>()
                .HasMany(n => n.Devices)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId);

            builder.Entity<UserEntity>()
                .HasOne(n => n.Profile)
                .WithOne(n => n.User)
                .HasForeignKey<ProfileEntity>(n => n.UserId);
        }
    }
}