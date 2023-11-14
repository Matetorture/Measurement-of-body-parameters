namespace WebTest.Data.Devices
{
    public class DeviceEntity
    {
        public int Id { get; set; }
        public DateTime PairingDate { get; set; }
        public string? Name { get; set; }
        public bool Connect { get; set; }

        public DeviceEntity(
            int id, 
            DateTime pairingDate, 
            string? name, 
            bool connect
        )
        {
            Id = id;
            PairingDate = pairingDate;
            Name = name;
            Connect = connect;
        }
    }

}
