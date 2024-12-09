using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;
using TestAutomationFramework.DemoUi.WebAbstraction;

namespace TestAutomationFramework.DemoUi.Configuration
{
    public class AtConfiguration : IAtConfiguration
    {

        IConfiguration _builder;
        public AtConfiguration()
        {

            IDefaultVariables idefaultVariables = SpecflowRunner._iserviceProvider.GetRequiredService<IDefaultVariables>();

            _builder = new ConfigurationBuilder().AddJsonFile(idefaultVariables.getApplicationSettings).Build();

        }

        public string GetConfiguration(string key)
        {
            return _builder[key];
        }

 
    }

}
