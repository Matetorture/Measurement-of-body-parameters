using WebTest.Data;
using WebTest.Data.Profiles;
using WebTest.Data.Users;
using WebTest.Models.Profile;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebTest.Repositories
{
    public interface IUsersRepository
    {
        UserEntity Get(string? id);
        bool Add(ProfileEntity model);
        bool UpdateUser(UserEntity model);
        bool Update(ProfileEntity model);
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public UserEntity Get(string? id)
        {
            return _context.User.FirstOrDefault(n => n.Id == id);
        }

        public bool Add(ProfileEntity model)
        {
            _context.Profile.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateUser(UserEntity model)
        {
            var user = Get(model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            _context.User.Update(user);
            return _context.SaveChanges() > 0;
        }

        public bool Update(ProfileEntity model)
        {
            _context.Profile.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
