using Microsoft.EntityFrameworkCore.Update.Internal;
using WebTest.Data;
using WebTest.Data.Tests;

namespace WebTest.Repositories
{
    public interface ITestsRepository
    {
        TestEntity Get(int? id);
        List<TestEntity> GetAll();
        bool Add(TestEntity model);
        bool Update(TestEntity model);
        bool Delete(int? id);
    }
    public class TestsRepository : ITestsRepository
    {
        private readonly ApplicationDbContext _context;
        public TestsRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public TestEntity Get(int? id)
        {
            return _context.Test.FirstOrDefault(n => n.Id == id);
        }

        public List<TestEntity> GetAll()
        {
            return _context.Test.Select(n => n).ToList();
        }

        public bool Add(TestEntity model)
        {
            _context.Test.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int? id)
        {
            var model = Get(id);
            _context.Test.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public bool Update(TestEntity model)
        {
            _context.Test.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
