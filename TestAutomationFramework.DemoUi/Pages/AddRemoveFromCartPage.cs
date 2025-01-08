using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.DemoUi.WebAbstraction;

namespace TestAutomationFramework.DemoUi.Pages
{
    public class AddRemoveFromCartPage
    {

        IWebDriver _iwebDriver;

        IAtConfiguration _iatConfiguration;
        IWebElement Username => _iwebDriver.FindElement(By.XPath("//input[@id='user-name']"));
        IWebElement Password => _iwebDriver.FindElement(By.XPath("//input[@id='password']"));
        IWebElement Login => _iwebDriver.FindElement(By.XPath("//input[@id='login-button']"));

        //Product list 
        //*[@id="inventory_container"]/div/div[3]


       
        // Products list
        IReadOnlyCollection<IWebElement> ProductsList => _iwebDriver.FindElements(By.ClassName("inventory_item"));

        // Cart list
        IReadOnlyCollection<IWebElement> CartList => _iwebDriver.FindElements(By.ClassName("cart_item"));

        IWebElement cartIcon => _iwebDriver.FindElement(By.ClassName("shopping_cart_container"));

        //Cart Counter
        IWebElement cartCountBadge => _iwebDriver.FindElement(By.ClassName("fa-layers-counter.shopping_cart_badge"));

        //


        public AddRemoveFromCartPage(IAtConfiguration iatConfiguration, IDrivers idriver)
        {
            _iatConfiguration = iatConfiguration;

            _iwebDriver = idriver.GetWebDriver();
            _iwebDriver.Manage().Window.Maximize();
        }

        public void LoginWithValidCredentials(string username, string password)
        {
            string url = _iatConfiguration.GetConfiguration("url");

            _iwebDriver.Navigate().GoToUrl(url);

            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }

        public void AddItemsToCart()
        {
            // List of items to add to the cart
            List<string> itemsToAdd = new List<string>
            {
                "Sauce Labs Onesie",
                "Sauce Labs Fleece Jacket"
            };

            foreach (IWebElement product in ProductsList)
            {

                string productName = product.FindElement(By.ClassName("inventory_item_name")).Text;


                // Check if the product is in the list of items to add
                if (itemsToAdd.Contains(productName))
                {
                    // Click the "ADD TO CART" button for the matching product
                    IWebElement addToCartButton = product.FindElement(By.TagName("button"));
                    addToCartButton.Click();
                    Thread.Sleep(5000);
                    Console.WriteLine($"Added {productName} to cart.");
                }
            }

        }

        public void CheckCartCount()
        {
            try
            {

                string cartCountText = cartCountBadge.Text;
                int cartCount = int.Parse(cartCountText);
                Console.WriteLine($"Cart Count: {cartCount}");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cart is empty.");
            }
        }

        public void RemoveItemFromCart()
        {

            //User clicks button to go to the Cart list
            cartIcon.Click();

            // User is navigated to the Cart screen and will click remove on one of the items 

            //// List of items to Remove from the cart
            List<string> itemsToRemove = new List<string>
            {
                "Sauce Labs Fleece Jacket"
            };

            foreach (IWebElement product in CartList)
            {
                   string productName = product.FindElement(By.ClassName("inventory_item_name")).Text;

                //    // Check if the product is in the list of items to add
                if (itemsToRemove.Contains(productName))
                    {
                //        // Click the "REMOVE" button for the matching product
                        IWebElement removeButton = product.FindElement(By.TagName("button"));
                        removeButton.Click();
                        Console.WriteLine($"Removed {productName} to cart.");
                        Thread.Sleep(5000);
                    }
            }


            }

    }

}
