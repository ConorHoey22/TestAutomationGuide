using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Reports
{
    public class ExtentReport : IExtentReport
    {
        IDefaultVariables _idefaultVariables;

        public ExtentReport(IDefaultVariables idefaultVariable) 
        { 
            _idefaultVariables = idefaultVariable;
        }   

        public void intializeExtentReport()
        {
            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter(_idefaultVariables.getExtentReport); // File path to store reports using our DefaultVartiables object
            AventStack.ExtentReports.ExtentReports extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);   
        }
    }
}
