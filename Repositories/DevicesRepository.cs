using WebTest.Data;
using WebTest.Data.Devices;

namespace WebTest.Repositories
{
    public interface IDevicesRepository
    {
        DeviceEntity Get(int? id);
        List<DeviceEntity> GetAll(string userId);
        bool Add(DeviceEntity model);
        bool Update(DeviceEntity model);
        bool Delete(int? id);
    }
    public class DevicesRepository : IDevicesRepository
    {
        private readonly ApplicationDbContext _context;
        public DevicesRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public DeviceEntity Get(int? id)
        {
            return _context.Device.FirstOrDefault(n => n.Id == id);
        }

        public List<DeviceEntity> GetAll(string userId)
        {
            return _context.Device.Where(n => n.UserId == userId).OrderByDescending(n => n.Id).ToList();
        }

        public bool Add(DeviceEntity model)
        {
            _context.Device.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int? id)
        {
            var model = Get(id);
            _context.Device.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public bool Update(DeviceEntity model)
        {
            _context.Device.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
