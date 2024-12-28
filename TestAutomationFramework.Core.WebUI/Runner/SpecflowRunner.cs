using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.WebUI.DIContainerConfig;

namespace TestAutomationFramework.Core.WebUI.Runner
{

    [Binding]
    public class SpecflowRunner
    {
        //declare method
        public static IServiceProvider _iserviceProvider;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            //Call the Container Config 
            _iserviceProvider = CoreContainerConfig.ContainerServices();
        }
    }
}
