using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.DemoUi.Pages;
using TestAutomationFramework.DemoUi.WebAbstraction;

namespace TestAutomationFramework.DemoUi.Steps
{
    [Binding]
    public class AddRemoveFromCartSteps
    {


        AddRemoveFromCartPage _addRemoveFromCartPage;
        IAtConfiguration _iatConfiguration;

        public AddRemoveFromCartSteps(IAtConfiguration iatConfiguration, IDrivers idrivers) 
        {

            _iatConfiguration = iatConfiguration;
            _addRemoveFromCartPage = new AddRemoveFromCartPage(_iatConfiguration, idrivers);

        } 


        [Given(@"login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _addRemoveFromCartPage.LoginWithValidCredentials(_iatConfiguration.GetConfiguration("username"), _iatConfiguration.GetConfiguration("password"));
        }

        [When(@"User adds an items from the product list to the cart")]
        public void WhenUserAddsAnItemsFromTheProductListToTheCart()
        {
            _addRemoveFromCartPage.AddItemsToCart();
        }

        [Then(@"User verifies the cart count is correct")]
        public void ThenUserVerifiesTheCartCountIsCorrect()
        {
           _addRemoveFromCartPage.CheckCartCount();

            //if statement how this Passes and Fails ? 
        }

        [When(@"User removes one item from the cart")]
        public void WhenUserRemovesOneItemFromTheCart()
        {
           _addRemoveFromCartPage.RemoveItemFromCart();
        }

        [Then(@"User verifies the count has updated")]
        public void ThenUserVerifiesTheCountHasUpdated()
        {
        ///   _addRemoveFromCartPage.CheckCartCount();
        }

    }
}
