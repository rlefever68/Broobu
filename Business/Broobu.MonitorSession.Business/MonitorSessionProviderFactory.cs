using Iris.MonitorSession.Contract.Interfaces;

namespace Iris.MonitorSession.Business
{
    public class MonitorSessionProviderFactory
    {
        public static IMonitorSession CreateProvider()
        {
            return new MonitorSessionProvider();
        }
    }
}
