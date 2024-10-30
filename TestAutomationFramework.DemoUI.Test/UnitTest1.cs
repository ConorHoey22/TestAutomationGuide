using Microsoft.Extensions.DependencyInjection;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.ContainerConfig;
using TestAutomationFramework.Core.WebUI.Reports;

namespace TestAutomationFramework.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Logging logging = new Logging();

            IServiceProvider iserviceProvider = ContainerConfig.ContainerServices();
            ILogging logging = iserviceProvider.GetRequiredService<ILogging>();

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