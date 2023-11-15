using WebTest.Data.Tests;

namespace WebTest.Models.Dashboard
{
    public class DashboardIndexVM
    {
        public DateTime LastTestDate { get; set; }

        public DashboardIndexVM(
            DateTime TestDate
        )
        {
            LastTestDate = TestDate;
        }
    }
}
