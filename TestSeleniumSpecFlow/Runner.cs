using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestSeleniumSpecFlow
{
    [Binding]
    public class Runner
    {

        public static IConfigurationRoot configurationRoot;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            string path = "C:\\Users\\Conor\\source\\repos\\TestSeleniumSpecFlow\\TestSeleniumSpecFlow\\Configuration.json";

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationRoot = configurationBuilder.AddJsonFile(path).AddEnvironmentVariables().Build();

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine(featureContext.FeatureInfo.Title);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {



        }
    }

}
