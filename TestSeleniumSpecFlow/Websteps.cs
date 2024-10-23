using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace TestSeleniumSpecFlow
{

    [Binding]
    public class Websteps
    {
        IWebDriver iwebDriver;
        User _user;
        public Websteps(User user)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            iwebDriver = new ChromeDriver();
            _user = user;   
        }


        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext sc, FeatureContext fc)
        {
            Console.WriteLine(sc.ScenarioInfo.Title);


        }


        [AfterScenario]
        public static void AfterScenario(ScenarioContext sc, FeatureContext fc)
        {
            // We can close the browser  
            // Create report 

        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext sc)
        {
            // We can save info of the steps            
        }

        [AfterStep]
        public void AfterStep(ScenarioContext sc)
        {
            // Maybe we could take a screenshot here using ITakesScreenshot
        }

        [Given(@"The user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            iwebDriver.Navigate().GoToUrl(Runner.configurationRoot["url"]);
        }

        [When(@"The user provides a username (.*)")]
        public void WhenTheUserProvidesAUsername(string username)
        {

            iwebDriver.FindElement(By.Id("user-name")).SendKeys(username); 

        }

        [When(@"The user provides a password(.*)")]
        public void WhenTheUserProvidesAPassword(string password)
        {

            String EnteredPassword = "secret_sauce";

            iwebDriver.FindElement(By.Id("password")).SendKeys(EnteredPassword);
        }

        [Then(@"The user is logged in")]
        public void ThenTheUserIsLoggedIn()
        {
            iwebDriver.FindElement(By.Id("login-button")).Click();
        }

        [Then(@"user adds their firstName and lastName")]
        public void ThenUserAddsTheirFirstNameAndLastName()
        {
          
            _user.firstName = "Tim";
            _user.lastName = "Lee";

        }


    }
}
