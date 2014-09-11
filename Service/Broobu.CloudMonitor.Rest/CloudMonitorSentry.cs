using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Broobu.MonitorDisco.Business;
using Broobu.MonitorDisco.Contract.Domain;

namespace Broobu.CloudMonitor.Rest
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CloudMonitorSentry : ICloudMonitor
    {
        public DiscoInfo[] GetAllEndpoints()
        {
            return MonitorDiscoProvider
                .DiscoViewItems
                .GetAllEndpoints();

        }
    }
}