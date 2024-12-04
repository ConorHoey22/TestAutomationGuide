using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.DemoUi.Pages;

namespace TestAutomationFramework.DemoUi.Steps
{

    [Binding]
    public class LoginSteps
    {
        LoginPage _loginPage;

        public LoginSteps() { 
        
            _loginPage = new LoginPage();  
        
        }

        [Given(@"login with valid login")]
        public void GivenLoginWithValidLogin()
        {
            _loginPage.LoginWithValidCredentials("standard_user","secret_sauce");
        }


        [Given(@"login with invalid login")]
        public void GivenLoginWithInvalidLogin()
        {
            _loginPage.LoginWithInvalidCredentials("incorrectUsername" , "DDD");
        }



    }
}
