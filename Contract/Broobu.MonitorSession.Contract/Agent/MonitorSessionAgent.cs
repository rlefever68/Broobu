using System;
using System.ComponentModel;
using Iris.Fx.Networking.Wcf;
using Iris.MonitorSession.Contract.Domain;
using Iris.MonitorSession.Contract.Interfaces;

namespace Iris.MonitorSession.Contract.Agent
{
    class MonitorSessionAgent : DiscoProxy<IMonitorSession>, 
        IMonitorSessionAgent
    {
        #region IMonitorSessionAgent Members

        public event Action<Domain.SessionViewItem[]> GetSessionsCompleted;

        /// <summary>
        /// Gets the sessions async.
        /// </summary>
        /// <returns></returns>
        public void GetSessionsAsync()
        {
            SessionViewItem[] r = null;
            var wrk = new BackgroundWorker();
            wrk.DoWork += (s, e) => { r = Client.GetSessions(); };
            wrk.RunWorkerCompleted += (s, e) => { if(GetSessionsCompleted!=null) GetSessionsCompleted(r);};
            wrk.RunWorkerAsync();
        }

        #endregion

        #region IMonitorSessionService Members

        /// <summary>
        /// Gets the sessions.
        /// </summary>
        /// <returns></returns>
        public SessionViewItem[] GetSessions()
        {
            return Client.GetSessions();
        }

        #endregion
    }
}
