using Broobu.MonitorDisco.Contract.Agent;
using Broobu.MonitorDisco.Contract.Interfaces;

namespace Broobu.MonitorDisco.Contract
{
    public static class MonitorDiscoPortal
    {
        public static IMonitorDiscoAgent Agent
        {
            get 
            {
                return new MonitorDiscoAgent();
            }
        }
    }
}
