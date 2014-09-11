using System;
using System.Xml.Linq;
using Pms.Authentication.Business.Interfaces;
using Pms.Authentication.Domain;
using Pms.Framework.Domain;

namespace Pms.Authentication.Business
{


    class AuthenticationMockProvider : IAuthenticationProvider
    {
        /// <summary>
        /// Gets the authentication modes.
        /// </summary>
        /// <returns></returns>
        public AuthenticationModeViewItem[] GetAuthenticationModes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The user password.</param>
        /// <param name="productCode">The product code.</param>
        /// <param name="productPassword">The product password.</param>
        /// <returns></returns>
        public LogonResponse Login(string userName, string userPassword, string productCode, string productPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns></returns>
        public LogonResponse LoginUser(string userName, string userPassword)
        {
            return FrameworkDomainGenerator
                .CreateMockLogonResponse(userName, userPassword);
        }

        /// <summary>
        /// Selects the application.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="productCode">The product code.</param>
        /// <param name="productPassword">The product password.</param>
        /// <returns></returns>
        public ServiceResponse SelectApplication(string sessionId, string productCode, string productPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pings the specified session id.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public ServiceResponse Ping(string sessionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public ServiceResponse LogOff(string sessionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public UserResponse GetUserDetails(string sessionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the available functions.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="applicationCode">The application code.</param>
        /// <returns></returns>
        public FunctionsResponse GetAvailableFunctions(string sessionId, string applicationCode)
        {
            throw new NotImplementedException();
        }

        public PMSSession ValidateSession(string sessionId, int pmsSession)
        {
            throw new NotImplementedException();
        }

        public PMSSession GetUserSession(PMSAuthRequest pmsAuthRequest)
        {
            throw new NotImplementedException();
        }

        public AccountViewItem[] GetAccounts()
        {
            throw new NotImplementedException();
        }

        public void RegisterDefaults()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs the database change.
        /// </summary>
        /// <param name="affectedDatabaseName">Name of the affected database.</param>
        /// <param name="affectedTableName">Name of the affected table.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="applicationCode">The application code.</param>
        /// <param name="user">The user.</param>
        /// <param name="affectedFieldInformation">The affected field information.</param>
        /// <returns></returns>
        public ServiceResponse LogDatabaseChange(string affectedDatabaseName, string affectedTableName, string operation, string applicationCode, string user, XElement affectedFieldInformation)
        {
            throw new NotImplementedException();
        }
    }
}