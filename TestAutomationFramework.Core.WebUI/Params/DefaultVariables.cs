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
    }
}
