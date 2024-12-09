using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Params
{
    public class DefaultVariables : IDefaultVariables
    {
        public string getReport
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\Results\\Report"
                  + DateTime.Now.ToString("yyyyMMdd HHmmss");
            }
        }


        public string getLog
        {
            get
            {
                return getReport + "\\log.txt";
            }
        }


        public string getFrameworkSettings
        {

            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "FrameworkSettings.json");
            }

        }

        public string getApplicationSettings
        {

            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "applicationConfig.json");
            }

        }



        public string gridhuburl
        {

            get
            {
                return "https://localhost:4444/wd/hub";
            }

        }



        public string dataSetLocation
        {

            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "\\DataSetLocation");
            }

        }


    }

}
