using WebTest.Data;
using WebTest.Data.Users;

namespace WebTest.Repositories
{
    public interface IUsersRepository
    {
        UserEntity Get(int? id);
        List<UserEntity> GetAll();
        bool Add(UserEntity model);
        bool Update(UserEntity model);
        bool Delete(int? id);
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public UserEntity Get(int? id)
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
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int? id)
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
