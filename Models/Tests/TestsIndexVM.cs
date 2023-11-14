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
            Test = new TestEntity(
                name,
                DateTime.Now,
                description,
                safeRange,
                unit,
                valueTemplate,
                testType,
                bodyMeasure,
                value
            );
        }
    }
}
