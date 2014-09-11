using System.ServiceModel;
using Broobu.SessionProxy.Contract.Interfaces;
using Wulka.Authentication;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Interfaces;
using NLog;

namespace Broobu.SessionProxy.Service
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults=true)]
    public class SessionProxy : ISessionProxy,IValidateSession,IQuerySession
    {


       private readonly Logger _logger = LogManager.GetLogger("SessionProxy");
       
        #region ISessionProxyService Members
        /// <summary>
        /// Ends the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns></returns>
        public WulkaSession EndSession(WulkaSession session)
        {
            if(session==null)
            {
                _logger.Error("No Session to End.");
                return null;
            }
            if (session.Username == AuthenticationDefaults.GuestUserName)
            {
                return SessionCache.Instance.RemoveSession(session);
            }
            var ss = SessionCache.Instance.RemoveSession(session);
            return StartSession(ss);
        }

        /// <summary>
        /// Starts the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns></returns>
        public WulkaSession StartSession(WulkaSession session)
        {
            _logger.Info("Starting Session for user [{0}]", session.Username);
            return SessionCache.Instance.AddSession(session);
        }
        #endregion

        #region ISessionProxyService Members
        public WulkaSession[] GetSessions()
        {
            return SessionCache.Instance.GetSessions();
        }
        #endregion

        #region IValidateSession Members

        /// <summary>
        /// Validates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public bool Validate(string userName, string sessionId)
        {
            return SessionCache.Instance.Validate(userName, sessionId);
        }

        #endregion
    }
}
