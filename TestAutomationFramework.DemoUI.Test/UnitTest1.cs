using TestAutomationFramework.Core.WebUI.Reports;

namespace TestAutomationFramework.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Logging logging = new Logging();
            logging.Warning("There is a Warning here");
            logging.Information("There is a informaion log here");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}