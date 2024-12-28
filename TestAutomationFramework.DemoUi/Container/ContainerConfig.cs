using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.WebUI.DIContainerConfig;
using TestAutomationFramework.DemoUi.Configuration;
using TestAutomationFramework.DemoUi.WebAbstraction;

namespace TestAutomationFramework.DemoUi.Container
{
    [Binding]
    public class ContainerConfig
    {

        [BeforeScenario(Order =1)]
        public void BeforeScenario(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<AtConfiguration,IAtConfiguration>();
            iobjectContainer = CoreContainerConfig.SetContainer(iobjectContainer);
        }
    }
}
