using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.DIContainerConfig;
using TestAutomationFramework.Core.WebUI.Params;
using TestAutomationFramework.Core.WebUI.Reports;

namespace TestAutomationFramework.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Logging logging = new Logging();

            //GlobalProperties globalProperties = new GlobalProperties();
            //globalProperties.Configuration();

            IServiceProvider iserviceProvider = ContainerConfig.ContainerServices();
            
            IGlobalProperties globalProperties = iserviceProvider.GetRequiredService<IGlobalProperties>();
            //globalProperties.Configuration();
            
            //ILogging logging = iserviceProvider.GetRequiredService<ILogging>();
            //logging.Warning("There is a Warning here");
            //logging.Information("There is a informaion log here");
        }

        [Test]
        public void Test1()
        {
            //Assert.Pass();
        }
    }
}