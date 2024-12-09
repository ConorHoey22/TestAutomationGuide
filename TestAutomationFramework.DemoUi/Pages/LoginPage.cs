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
        IWebDriver webDriver;

        IAtConfiguration _iatConfiguration;

        IWebElement Username => webDriver.FindElement(By.XPath("//input[@id='user-name']"));
        IWebElement Password => webDriver.FindElement(By.XPath("//input[@id='password']"));
        IWebElement Login => webDriver.FindElement(By.XPath("//input[@id='login-button']"));

        public LoginPage(IAtConfiguration iatConfiguration) 
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            _iatConfiguration = iatConfiguration;    

        }  


        public void LoginWithValidCredentials(string username,string password)
        {

            string url = _iatConfiguration.GetConfiguration("url");

            webDriver.Navigate().GoToUrl(url);
      
            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();

        }



        public void LoginWithInvalidCredentials(string username, string password)
        {
            string url = _iatConfiguration.GetConfiguration("url");


            webDriver.Navigate().GoToUrl(url);


            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }
    }
}
