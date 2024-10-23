using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestSeleniumSpecFlow
{

    [Binding]

    public class Event
    {
        User _user;
        public Event(User user)
        {
            _user = user;
        }

        [Then(@"display user info")]
        public void ThenDisplayUserInfo()
        {
            Console.WriteLine(_user.firstName + "" + _user.lastName);
        }

    }
}
