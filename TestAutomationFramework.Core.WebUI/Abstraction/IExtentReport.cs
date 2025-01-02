using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IExtentReport
    {
        void CreateFeature(string featureName);
        void CreateScenario(string scenarioName);
        void Pass(string msg,string base64);
        void Fail(string msg,string base64);
        void Warning(string msg,string base64);
        void Error(string msg,string base64) ;
        void Fatal(string msg,string base64);
    }
}
