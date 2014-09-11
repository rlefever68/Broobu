using System;
using Pms.Authentication.Business.Interfaces;
using Pms.Framework.Domain;
using Pms.Authentication.Contract.Domain;
using Pms.MobiGuider.Repository.Contract.Domain;
using Pms.MobiGuider.Repository.Contract.Agent;
using System.Security.Principal;

namespace Pms.Authentication.Business
{
    abstract class AuthenticationProviderBase : IAuthenticationProvider
    {
        public abstract AuthenticationMode[] GetAuthenticationModes();
        public abstract LogonResponse Login(string userName, string userPassword, string productCode, string productPassword);
        public abstract LogonResponse LoginUser(string userName, string userPassword);
        public abstract ServiceResponse SelectApplication(string sessionId, string productCode, string productPassword);
        public abstract ServiceResponse Ping(string sessionId);
        public abstract ServiceResponse LogOff(string sessionId);
        public abstract UserResponse GetUserDetails(string sessionId);
        public abstract FunctionsResponse GetAvailableFunctions(string sessionId, string applicationCode);
        public abstract PMSSession ValidateSession(PMSSession session);
        public abstract PMSSession GetUserSession(PMSAuthRequest pmsAuthRequest);
        public abstract AccountViewItem[] GetAccounts();

        /// <summary>
        /// Registers the defaults.
        /// </summary>
        public  void RegisterDefaults()
        {
            var acc = MobiGuiderDomainGenerator.CreateGuestAccount();
            SaveAccount(acc);
        }

       




        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="acc">The acc.</param>
        private static void SaveAccount(Account acc)
        {
            if (!AccountExists(acc))
            {
                MobiGuiderRepositoryAgentFactory
                    .CreateAccountRepositoryAgent()
                    .Insert(acc);
            }
            else
            {
                MobiGuiderRepositoryAgentFactory
                    .CreateAccountRepositoryAgent()
                    .Update(acc);
            }
        }

        /// <summary>
        /// Accounts the exists.
        /// </summary>
        /// <param name="acc">The acc.</param>
        /// <returns></returns>
        private static bool AccountExists(Account acc)
        {
            return (MobiGuiderRepositoryAgentFactory
                .CreateAccountRepositoryAgent()
                .SelectById(acc.Id) != null);
        }


        public abstract PMSSession AuthenticateUserCredentials();
       public abstract PMSSession AuthenticateUserCredentials(WindowsIdentity identity);
    }
}
