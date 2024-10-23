using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTest
{
    [Binding]
    public class CheckoutInfoWebsteps
    {
        [Given(@"user adds a product to cart")]
        public void GivenUserAddsAProductToCart()
        {
            Console.WriteLine("add product");
        }

        [When(@"the user clicks to checkout and adds info")]
        public void WhenTheUserClicksToCheckoutAndAddsInfo(Table table)
        {
            UserCheckoutInfo userCheckoutInfo = table.CreateInstance<UserCheckoutInfo>();
            Console.WriteLine("LastName: " + userCheckoutInfo.lastName);

            foreach (TableRow row in table.Rows)
            {
                Console.WriteLine(row["firstName"]);
                foreach (string header in table.Header)
                {
                    Console.WriteLine(row[header]);
                }
            }

        }


    }
}
