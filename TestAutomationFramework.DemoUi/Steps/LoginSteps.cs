﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.DemoUi.Pages;
using TestAutomationFramework.DemoUi.WebAbstraction;

namespace TestAutomationFramework.DemoUi.Steps
{

    [Binding]
    public class LoginSteps
    {
        LoginPage _loginPage;
        IAtConfiguration _iatConfiguration;

        public LoginSteps(IAtConfiguration iatConfiguration) 
        { 
        
            _iatConfiguration = iatConfiguration; 
            _loginPage = new LoginPage(_iatConfiguration);  
        
        }

        [Given(@"login with valid login")]
        public void GivenLoginWithValidLogin()
        {
            _loginPage.LoginWithValidCredentials(_iatConfiguration.GetConfiguration("username"), _iatConfiguration.GetConfiguration("password"));
        }


        [Given(@"login with invalid login")]
        public void GivenLoginWithInvalidLogin()
        {
            _loginPage.LoginWithInvalidCredentials("incorrectUsername" , "DDD");
        }



    }
}