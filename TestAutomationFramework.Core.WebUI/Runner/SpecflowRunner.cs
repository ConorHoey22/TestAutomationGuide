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
        //declaure method
        static IServiceProvider iserviceProvider;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            //Call the Container Config 
            iserviceProvider =  ContainerConfig.ContainerServices();
        }
    }
}
