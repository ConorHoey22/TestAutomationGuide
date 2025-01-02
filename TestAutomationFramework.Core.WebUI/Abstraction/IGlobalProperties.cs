using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IGlobalProperties
    {

        string dataSetLocation { get; set; }
        string downloadedLocation { get; set; }
        string browsertype { get; set; }
        bool stepscreenshot { get; set; }
        void Configuration();
    }
}
