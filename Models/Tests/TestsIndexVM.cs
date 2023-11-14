using WebTest.Data.Tests;
namespace WebTest.Models.Tests
{
    public class TestsIndexVM
    {
        public TestEntity Test { get; set; }

        public TestsIndexVM(
            string name,
            string description,
            double safeRange,
            string unit,
            string valueTemplate,
            TestType testType,
            BodyMeasure bodyMeasure,
            string value
        )
        {
            Test = new TestEntity();
            Test.Name = name;
            Test.Date = DateTime.Now;
            Test.Description = description;
            Test.SafeRange = safeRange;
            Test.Unit = unit;
            Test.ValueTemplate = valueTemplate;
            Test.TestType = testType;
            Test.BodyMeasure = bodyMeasure;
            Test.Value = value;
        }
    }
}
