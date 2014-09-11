using System.ServiceModel;
using Broobu.MonitorDisco.Business;
using Broobu.MonitorDisco.Business.Provider;
using Broobu.MonitorDisco.Contract.Domain;
using Broobu.MonitorDisco.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.MonitorDisco.Service
{


    [ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    public class MonitorDiscoSentry : SentryBase, IMonitorDisco
    {
        #region IMonitorDiscoService Members

        public DiscoInfo[] GetAllEndpoints()
        {
            return  MonitorDiscoProvider
                .DiscoViewItems
                .GetAllEndpoints();
        }

        #endregion

        protected override void RegisterRequiredDomainObjects()
        {
           
        }
    }
}
