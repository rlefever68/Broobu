using Iris.Fx.Networking.Wcf;
using Iris.MonitorSession.Business;
using Iris.MonitorSession.Contract.Domain;
using Iris.MonitorSession.Contract.Interfaces;

namespace Iris.MonitorSession.Service
{

    public class MonitorSessionService : BusinessServiceBase, IMonitorSession
    {
        #region IMonitorSessionService Members

        /// <summary>
        /// Gets the sessions.
        /// </summary>
        /// <returns></returns>
        public SessionViewItem[] GetSessions()
        {
            return MonitorSessionProviderFactory
                .CreateProvider()
                .GetSessions();
        }

        #endregion

        protected override void RegisterRequiredDomainObjects()
        {
            
        }
    }
}
