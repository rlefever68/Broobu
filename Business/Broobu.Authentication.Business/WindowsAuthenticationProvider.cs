using System;
using Pms.Framework.Domain;
using Pms.Authentication.Contract.Domain;

namespace Pms.Authentication.Business
{
    class WindowsAuthenticationProvider : AuthenticationProviderBase
    {
        /// <summary>
        /// Gets the authentication modes.
        /// </summary>
        /// <returns></returns>
        public override AuthenticationMode[] GetAuthenticationModes()
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
        public override LogonResponse Login(string userName, string userPassword, string productCode, string productPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns></returns>
        public override LogonResponse LoginUser(string userName, string userPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selects the application.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="productCode">The product code.</param>
        /// <param name="productPassword">The product password.</param>
        /// <returns></returns>
        public override ServiceResponse SelectApplication(string sessionId, string productCode, string productPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pings the specified session id.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public override ServiceResponse Ping(string sessionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public override ServiceResponse LogOff(string sessionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public override UserResponse GetUserDetails(string sessionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the available functions.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="applicationCode">The application code.</param>
        /// <returns></returns>
        public override FunctionsResponse GetAvailableFunctions(string sessionId, string applicationCode)
        {
            throw new NotImplementedException();
        }

        public override PMSSession ValidateSession(PMSSession session)
        {
            throw new NotImplementedException();
        }

        public override PMSSession GetUserSession(PMSAuthRequest pmsAuthRequest)
        {
            throw new NotImplementedException();
        }

        public override AccountViewItem[] GetAccounts()
        {
            throw new NotImplementedException();
        }

        public override PMSSession AuthenticateUserCredentials()
        {
            throw new NotImplementedException();
        }

        public override PMSSession AuthenticateUserCredentials(System.Security.Principal.WindowsIdentity identity)
        {
            throw new NotImplementedException();
        }
    }
}
