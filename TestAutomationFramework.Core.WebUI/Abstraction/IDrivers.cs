using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IDrivers
    {
        IWebDriver GetWebDriver();

        void CloseBrowser();
    }
}
