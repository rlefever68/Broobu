using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Pms.Authentication.Business.Interfaces;
using Pms.Authentication.Domain;
using Pms.Framework.Domain;

namespace Pms.Authentication.Business
{
    class OpenIdAuthenticationProvider : AuthenticationProviderBase
    {
        /// <summary>
        /// Gets the authentication modes.
        /// </summary>
        /// <returns></returns>
        public override AuthenticationModeViewItem[] GetAuthenticationModes()
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

        public override ServiceResponse SelectApplication(string sessionId, string productCode, string productPassword)
        {
            throw new NotImplementedException();
        }

        public override ServiceResponse Ping(string sessionId)
        {
            throw new NotImplementedException();
        }

        public override ServiceResponse LogOff(string sessionId)
        {
            throw new NotImplementedException();
        }

        public override UserResponse GetUserDetails(string sessionId)
        {
            throw new NotImplementedException();
        }

        public override FunctionsResponse GetAvailableFunctions(string sessionId, string applicationCode)
        {
            throw new NotImplementedException();
        }

        public override PMSSession ValidateSession(string sessionId, int pmsSession)
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
    }
}
