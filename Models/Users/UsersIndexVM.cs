using WebTest.Data.Users;
using WebTest.Data.Profiles;

namespace WebTest.Models.Users
{
    public class UsersIndexVM
    {
        public UserEntity User { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
