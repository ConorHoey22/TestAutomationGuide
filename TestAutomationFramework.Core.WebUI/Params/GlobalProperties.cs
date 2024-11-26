using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Params
{

    public class GlobalProperties : IGlobalProperties
    {

        IDefaultVariables _idefaultVariables;
        ILogging _ilogging;



        public string browsertype { get; set; }
        public string gridHubUrl { get; set; }

        public bool stepscreenshot { get; set; }   

        public string extentReportPortalUrl { get; set; }

        public bool extentReportToPortal {  get; set; }

        public string logLevel { get; set; }    

        public string dataSetLocation { get; set; } 

        public string downloadedLocation { get; set; }







        public GlobalProperties(IDefaultVariables idefaultVariables , ILogging ilogging)
        {
            _idefaultVariables = idefaultVariables;
            _ilogging = ilogging;
            Configuration();
        }   

        public void Configuration() 
        {

            // use microsoft.confg.json package to read the json file , remember to set the file properties to copy always 

            var configBuilder = (dynamic)null;

            try
            {
                configBuilder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                          .AddJsonFile(_idefaultVariables.getFrameworkSettings)
                         .Build();
            }
            catch (Exception e)
            {
                //File does not exist
                _ilogging.Error("File does not exists." + e.Message);
                //stop the execution 
                System.Environment.Exit(0);
            }

                 browsertype = string.IsNullOrEmpty(configBuilder["BrowserType"]) ? "chrome" : configBuilder["BrowserType"];
                 gridHubUrl = string.IsNullOrEmpty(configBuilder["GridHubUrl"]) ? _idefaultVariables.gridhuburl : configBuilder["GridHubUrl"];
                 stepscreenshot = configBuilder["StepScreenShot"].ToLower().Equals("on") ? true : false;
                 extentReportPortalUrl = configBuilder["ExtentReportPortalUrl"];
                 extentReportToPortal = configBuilder["StepScreenShot"].ToLower().Equals("on") ? true : false;
                 logLevel = configBuilder["LogLevel"];
                 dataSetLocation = string.IsNullOrEmpty(configBuilder["DataSetLocation"]) ? _idefaultVariables.dataSetLocation : configBuilder["DataSetLocation"];
                 downloadedLocation = string.IsNullOrEmpty(configBuilder["DataSetLocation"]) ? _idefaultVariables.dataSetLocation : configBuilder["DownloadedLocation"];


            _ilogging.LogLevel(logLevel);
            _ilogging.Information("Configuration Settings");
            _ilogging.Information("Browser: " + browsertype);
            _ilogging.Information("Grid Hub Url : " + gridHubUrl);
            _ilogging.Information("Step screenshot : " + stepscreenshot);
            _ilogging.Information("Extent report portal url : " + extentReportPortalUrl);
            _ilogging.Information("Extent report portal  : " + extentReportToPortal);
            _ilogging.Information("Log Level: " + logLevel);
            _ilogging.Information("Data set location : " + dataSetLocation);
            _ilogging.Information("Downloaded Location: " + dataSetLocation);


        }
    }
}
