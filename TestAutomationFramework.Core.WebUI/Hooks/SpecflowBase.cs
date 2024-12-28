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



        public SpecflowBase(IChromeWebDriver _chromeWebDriver, IFirefoxWebDriver _firefoxWebDriver)
        {

            _ichromeWebDriver = _chromeWebDriver;
            _ifirefoxWebDriver = _firefoxWebDriver;

        }


        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer iobjectcontainer)
        {
            IWebDriver iwebDriver;

            iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();

            switch(iglobalProperties.browsertype.ToLower())
            {
                case "chrome":
                    iwebDriver = _ichromeWebDriver.GetChromeWebDriver(); 
                    break;
                case "firefox": 
                    iwebDriver = _ifirefoxWebDriver.GetFirefoxWebDriver();
                    break;
                default:
                    iwebDriver = _ichromeWebDriver.GetChromeWebDriver();
                    break;

            }

            iobjectcontainer.RegisterInstanceAs(iwebDriver);
        }


    }
}
