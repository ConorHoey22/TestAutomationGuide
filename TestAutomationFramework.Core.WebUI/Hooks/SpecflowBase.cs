using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;

namespace TestAutomationFramework.Core.WebUI.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        IGlobalProperties iglobalProperties;
        IChromeWebDriver _ichromeWebDriver;
        IFirefoxWebDriver _ifirefoxWebDriver;
        IDrivers _idrivers;
        ScenarioContext _scenarioContext;


        public SpecflowBase(IChromeWebDriver _chromeWebDriver, IFirefoxWebDriver _firefoxWebDriver)
        {

            _ichromeWebDriver = _chromeWebDriver;
            _ifirefoxWebDriver = _firefoxWebDriver;

        }


        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer iobjectcontainer , ScenarioContext scenarioContext, FeatureContext fc)
        {

            _idrivers = iobjectcontainer.Resolve<IDrivers>();
            _scenarioContext = scenarioContext;
            IExtentReport extentReport = (IExtentReport) fc["iextentreport"];
            extentReport.CreateScenario(scenarioContext.ScenarioInfo.Title);

        }

        public void AfterStep(ScenarioContext scenarioContext, FeatureContext fc)
        {
            IExtentReport extentReport = (IExtentReport)fc["iextentreport"];
            
            if(scenarioContext.TestError !=null)
            {
                extentReport.Fail(scenarioContext.StepContext.StepInfo.Text);
            }
            else 
            {
                extentReport.Pass(scenarioContext.StepContext.StepInfo.Text);    
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext sc, FeatureContext fc)
        {
            IExtentFeatureReport extentReport = SpecflowRunner._iserviceProvider.GetRequiredService<IExtentFeatureReport>();
            extentReport.FlushExtent();
            Thread.Sleep(1000);
            _idrivers.CloseBrowser();
        }

    }
}
