using WebTest.Data.Users;

namespace WebTest.Data.Tests
{
    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "-";
        public DateTime Date { get; set; }
        public string Description { get; set; } = "-";
        public TestType TestType { get; set; }
        public BodyMeasure BodyMeasure { get; set; }
        public string Value { get; set; } = "-";

        public UserEntity User { get; set; }
        public string UserId { get; set; }
    }
    public enum TestType
    {
        Pulse,
        Saturation,
        Weight,
        Height,
        BodyMeasure,
        Observation
    }
    public enum BodyMeasure
    {
        Neck,
        Arm,
        Forearm,
        Chest,
        Waist,
        Hips,
        Thighs,
        Calf
    }
}
