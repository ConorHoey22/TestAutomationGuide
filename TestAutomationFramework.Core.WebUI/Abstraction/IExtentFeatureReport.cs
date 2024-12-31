using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IExtentFeatureReport
    {
        void InitiliazeExtentReport();
    
        AventStack.ExtentReports.ExtentReports GetExtentReports();

        void FlushExtent();
    }
}
