using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.DemoUi.WebAbstraction;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomationFramework.DemoUi.Pages
{
    public class LoginPage
    {
        IWebDriver _iwebDriver;

        IAtConfiguration _iatConfiguration;

        IWebElement Username => _iwebDriver.FindElement(By.XPath("//input[@id='user-name']"));
        IWebElement Password => _iwebDriver.FindElement(By.XPath("//input[@id='password']"));
        IWebElement Login => _iwebDriver.FindElement(By.XPath("//input[@id='login-button']"));

        public LoginPage(IAtConfiguration iatConfiguration,IWebDriver webDriver) 
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            //_iwebDriver = new ChromeDriver();

            _iwebDriver = webDriver;

            webDriver.Manage().Window.Maximize();
            _iatConfiguration = iatConfiguration;    

        }  


        public void LoginWithValidCredentials(string username,string password)
        {

            string url = _iatConfiguration.GetConfiguration("url");

            _iwebDriver.Navigate().GoToUrl(url);
      
            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();

        }



        public void LoginWithInvalidCredentials(string username, string password)
        {
            string url = _iatConfiguration.GetConfiguration("url");


            _iwebDriver.Navigate().GoToUrl(url);


            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }
    }
}
