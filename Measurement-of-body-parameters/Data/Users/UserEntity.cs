using Microsoft.AspNetCore.Identity;
using WebTest.Data.Devices;
using WebTest.Data.Profiles;
using WebTest.Data.Tests;

namespace WebTest.Data.Users
{
    public class UserEntity : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }

        public ProfileEntity Profile { get; set; }
        public int ProfileId { get; set; }

        public ICollection<TestEntity> Tests { get; set; }
        public ICollection<DeviceEntity> Devices { get; set; }
    }
    public enum Role
    {
        Client,
        Admin,
        SuperAdmin
    }
}
