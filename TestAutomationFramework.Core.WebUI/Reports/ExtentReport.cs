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
        IExtentFeatureReport _iextentFeatureReport;
        AventStack.ExtentReports.ExtentTest _feature,_scenario;

        public ExtentReport(IExtentFeatureReport iextentFeatureReport) 
        {
            _iextentFeatureReport = iextentFeatureReport;    
        }
        public void CreateFeature(string featureName) 
        {
            _feature = _iextentFeatureReport.GetExtentReports().CreateTest(featureName);
        }

        public void CreateScenario(string scenarioName)
        {
            _scenario = _feature.CreateNode(scenarioName);  
        }

        public void Pass(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Pass, msg);
        }

        public void Fail(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Fail, msg);
        }
        public void Warning(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Warning, msg);
        }

        public void Fatal(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Fatal, msg);
        }
    }
}
