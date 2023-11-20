using WebTest.Data.Users;

namespace WebTest.Data.Devices
{
    public class DeviceEntity
    {
        public int Id { get; set; }
        public DateTime PairingDate { get; set; }
        public string? Name { get; set; }
        public bool Connect { get; set; }

        public UserEntity User { get; set; }
        public string UserId { get; set; }
    }

}
