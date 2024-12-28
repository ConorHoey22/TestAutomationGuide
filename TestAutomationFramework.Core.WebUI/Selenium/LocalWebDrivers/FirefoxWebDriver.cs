using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Permissions;

namespace TestAutomationFramework.Core.WebUI.Selenium.LocalWebDrivers
{

    public class FirefoxWebDriver : IFirefoxWebDriver
    {

        IGlobalProperties _iglobalProperties;

        public FirefoxWebDriver()
        {
            _iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

  

        public IWebDriver GetFirefoxWebDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            IWebDriver webdriver = new FirefoxDriver(GetOptions());
            webdriver.Manage().Window.Maximize();
            return webdriver;

        }
       
        public FirefoxOptions GetOptions()
        {
            var options = new FirefoxOptions();

            options.AcceptInsecureCertificates = true;
            options.SetPreference("network.http.phishy-userpass-length", 255);
            options.SetPreference("network.automatic-ntlm-auth.allow-non-fqdn", true);
            options.SetPreference("network.negotiate-auth.allow-non-fqdn", true);
            options.SetPreference("browser.tabs.remote.autostart", false);
            options.SetPreference("browser.tabs.remote.autostart.1", false);
            options.SetPreference("browser.tabs.remote.autostart.2", false);
            options.SetPreference("browser.tabs.remote.force-enable", "false");
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.download.manager.focusWhenStarting", false);
            options.SetPreference("browser.download.manager.useWindow", false);
            options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            options.SetPreference("browser.download.manager.closeWhenDone", true);
            options.SetPreference("browser.download.dir", _iglobalProperties.dataSetLocation);
  
            return options;
        }

    }
}
