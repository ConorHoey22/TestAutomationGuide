using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Params;
using TestAutomationFramework.Core.WebUI.Reports;

namespace TestAutomationFramework.Core.WebUI.DIContainerConfig
{
    public class ContainerConfig
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



    }
}
