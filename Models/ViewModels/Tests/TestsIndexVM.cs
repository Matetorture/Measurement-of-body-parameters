namespace WebTest.Models.ViewModels.Tests
{
    public class TestsIndexVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TestDate { get; set; }
        public double Pulse { get; set; }
        public double Saturation { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BodyCircumference { get; set; }
        public string AdditionalObservations { get; set; } = "";
        public double Glucose { get; set; }
    }
}
