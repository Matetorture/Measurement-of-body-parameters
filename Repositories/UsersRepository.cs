using WebTest.Data;
using WebTest.Data.Users;

namespace WebTest.Repositories
{
    public interface IUsersRepository
    {
        UserEntity Get(string? id);
        List<UserEntity> GetAll();
        bool Add(UserEntity model);
        bool Update(UserEntity model);
        bool Delete(string? id);
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

        public List<UserEntity> GetAll()
        {
            return _context.User.Select(n => n).ToList();
        }

        public bool Add(UserEntity model)
        {
            _context.User.Add(model);
            _context.Profile.Add(model.Profile);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(string? id)
        {
            var model = Get(id);
            _context.User.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public bool Update(UserEntity model)
        {
            _context.User.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
