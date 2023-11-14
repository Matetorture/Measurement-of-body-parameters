using WebTest.Data.Devices;
using WebTest.Data.Tests;

namespace WebTest.Models.Devices
{
    public class DevicesIndexVM
    {
        public DeviceEntity Device { get; set; }

        public DevicesIndexVM(
            int id,
            string name,
            bool connected
        )
        {
            Device = new DeviceEntity();
            Device.Id = id;
            Device.PairingDate = DateTime.Now;
            Device.Name = name;
            Device.Connect = connected;
        }
    }
}
