using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Params;
using TestAutomationFramework.Core.WebUI.Reports;
using TestAutomationFramework.Core.WebUI.Runner;
using TestAutomationFramework.Core.WebUI.Selenium.LocalWebDrivers;

namespace TestAutomationFramework.Core.WebUI.DIContainerConfig
{
    public class CoreContainerConfig
    {

        public static IServiceProvider ContainerServices()
        {

            //declare object service collection 
            IServiceCollection services = new ServiceCollection();


            //creating a service to request the object  <interface , Class  >
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            services.AddSingleton<IGlobalProperties, GlobalProperties>();



            // Build container
            return services.BuildServiceProvider();
        }


        public static IObjectContainer SetContainer(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<ChromeWebDriver,IChromeWebDriver>();
            iobjectContainer.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();
            return iobjectContainer;
        }

    }

}
