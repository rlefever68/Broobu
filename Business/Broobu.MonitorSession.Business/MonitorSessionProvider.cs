using System;
using System.Collections.Generic;
using Iris.Fx.Contract.Agent;
using Iris.Fx.Domain;
using Iris.MonitorSession.Contract.Domain;
using Iris.MonitorSession.Contract.Interfaces;
using Iris.SessionProxy.Contract.Agent;

namespace Iris.MonitorSession.Business
{
    class MonitorSessionProvider : IMonitorSession
    {
        #region IMonitorSessionService Members
        /// <summary>
        /// Gets the sessions.
        /// </summary>
        /// <returns></returns>
        public SessionViewItem[] GetSessions()
        {
            var lst = new List<SessionViewItem>();
            foreach(var it in SessionProxyAgentFactory
                .CreateQuerySessionAgent()
                .GetSessions())
            {
                lst.Add(CreateSessionViewItem(it));
            }
            return lst.ToArray();
                
        }
        /// <summary>
        /// Creates the session view item.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns></returns>
        private SessionViewItem CreateSessionViewItem(IrisSession session)
        {
            var acc = FxAgentFactory
                .CreateAccountAgent()
                .GetAccountForSession(session);
            return new SessionViewItem() 
            { 
                Id = Guid.NewGuid().ToString(),
                AccountId = acc.Id,
                AuthenticationMode = session.AuthenticationMode,
                Email = acc.Email,
                Host = session.Host,
                LoggedInAt = session.ConnectionTime,
                Mobile = acc.Telephone1,
                SessionId = session.SessionId,
                Telephone = acc.Telephone2,
                UserFullName = String.Format("{0} {1}",acc.FirstName,acc.LastName),
                Username = acc.Username,
                LastActivity = session.LastRequest
            };
        }
        #endregion
    }
}
