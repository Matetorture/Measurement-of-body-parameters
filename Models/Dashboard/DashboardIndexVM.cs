using WebTest.Data.Users;

namespace WebTest.Models.Dashboard
{
    public class DashboardIndexVM
    {
        public UserEntity User { get; set; }
        public DateTime LastTestDate {  get; set; }
        public int ConnectedDevices { get; set; }
    }
}
