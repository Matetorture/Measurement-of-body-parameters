namespace WebTest.Models.ViewModels.Devices
{
    public class DevicesIndexVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TestDate { get; set; }
        public string Name { get; set; }
        public bool Connect { get; set; }
    }
}
