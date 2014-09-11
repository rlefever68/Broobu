using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Activities.Asr;
using System.ServiceModel.Description;

namespace Pms.SOAStudio.UI.Controls
{
    public class SoaActivityBuilder : ClientActivityBuilder
    {
        public SoaActivityBuilder(OperationDescription operationDescription, string configurationName, string proxyNamespace)
            : base(operationDescription, configurationName, proxyNamespace)
        {
            
        }


        
    }
}
