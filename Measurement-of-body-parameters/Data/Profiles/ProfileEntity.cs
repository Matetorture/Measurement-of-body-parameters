using WebTest.Data.Devices;
using WebTest.Data.Tests;
using WebTest.Data.Users;

namespace WebTest.Data.Profiles
{
    public class ProfileEntity
    {
        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public bool Rh { get; set; }

        public UserEntity User { get; set; }
        public string UserId { get; set; }
    }
    public enum BloodType
    {
        O,
        A,
        B,
        AB
    }
}
