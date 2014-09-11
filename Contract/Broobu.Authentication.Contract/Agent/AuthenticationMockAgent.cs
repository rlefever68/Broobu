using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Pms.Framework.Domain;
using Pms.Authentication.Contract.Interfaces;
using Pms.Authentication.Contract.Domain;


namespace Pms.Authentication.Contract.Agent
{
    class AuthenticationMockAgent : IAuthenticationAgent
    {
        /// <summary>
        /// Logging an action performed by a user for auditing.
        /// </summary>
        /// <param name="affectedDatabaseName">The identification of the affected database.</param>
        /// <param name="affectedTableName">The name of the affected table.</param>
        /// <param name="operation">The operation that is performed (insert, update, delete)</param>
        /// <param name="applicationCode">Code of the application in wich the user is working</param>
        /// <param name="user">Id of the user that performed the operation</param>
        /// <param name="affectedFieldInformation">information about the edited field (fieldname + old and new values)</param>
        /// <returns></returns>
        public ServiceResponse LogDatabaseChange(string affectedDatabaseName, string affectedTableName, string operation, string applicationCode, string user, XElement affectedFieldInformation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Authenticates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The password.</param>
        /// <param name="productCode">A valid product code</param>
        /// <param name="productPassword">A valid product password</param>
        /// <returns></returns>
        public LogonResponse Login(string userName, string userPassword, string productCode, string productPassword)
        {
            return new LogonResponse()
                       {
                           Session =
                               new PMSSession()
                                   {
                                       ConnectionTime = DateTime.Now,
                                       AccountId = "1",
                                       LastRequest = DateTime.Now,
                                       SessionId = "SessionId1",
                                       Username = userName
                                   },
                           SessionTimeout = 3600,
                       };
        }

        /// <summary>
        /// Logins the user on the Authentication Service.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns>a Logon Response</returns>
        public LogonResponse LoginUser(string userName, string userPassword)
        {
            return new LogonResponse()
            {
                Session =
                    new PMSSession()
                    {
                        ConnectionTime = DateTime.Now,
                        AccountId = "1",
                        LastRequest = DateTime.Now,
                        SessionId = "SessionId1",
                        Username = userName
                    },
                SessionTimeout = 3600,
            };
        }

        /// <summary>
        /// Selects the given application with the current user settings
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="productCode">The product code.</param>
        /// <param name="productPassword">The product password.</param>
        /// <returns></returns>
        public ServiceResponse SelectApplication(string sessionId, string productCode, string productPassword)
        {
            return new ServiceResponse() {};
        }

        /// <summary>
        /// Logoffs the specified session id.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public ServiceResponse Logoff(string sessionId)
        {
            return new ServiceResponse() {  };
        }

        /// <summary>
        /// Prevent the session from expiring.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public ServiceResponse Ping(string sessionId)
        {
            return new ServiceResponse() {  };
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public UserResponse GetUserDetails(string sessionId)
        {
            return new UserResponse()
                       {
                           FirstName = "Karel",
                           LastName = "Vandingen",
                           Username = "Username1"
                       };
        }

        /// <summary>
        /// Gets the available functions of the specified application.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="applicationCode">The application code.</param>
        /// <returns></returns>
        public FunctionsResponse GetAvailableFunctions(string sessionId, string applicationCode)
        {
            return new FunctionsResponse()
                       {
                           Functions =
                               new List<UserFunction>()
                                   {
                                       new UserFunction() 
                                       {
                                           Id = 1, 
                                           Code="Code1", 
                                           HasParameter = false, 
                                           ParameterValue="ParameterValue1"
                                       },
                                       new UserFunction() 
                                       {
                                           Id = 1, 
                                           Code="Code1", 
                                           HasParameter = false, 
                                           ParameterValue="ParameterValue1"
                                       },
                                       new UserFunction() {
                                           Id = 1, 
                                           Code="Code1", 
                                           HasParameter = false, 
                                           ParameterValue="ParameterValue1"
                                       }
                                   },
                       };
        }

        /// <summary>
        /// Gets the version of the Authentication Service
        /// </summary>
        /// <returns>
        /// Service Version with version of authentication service
        /// </returns>
        public ServiceVersion GetVersion()
        {
            return new ServiceVersion() {CompatibilityVersion = "1", Version = "2"};
        }

        #region IAuthenticationAgent Members


        public IEnumerable<AccountViewItem> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public void GetAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public event Action<AccountViewItem[]> GetAccountsCompleted;

        #endregion

        #region IAuthenticationAgent Members


        public void RegisterDefaults()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IAuthenticationService Members


        public PMSSession ValidateSession(PMSSession pmsSession)
        {
            throw new NotImplementedException();
        }

        public PMSSession GetUserSession(PMSAuthRequest pmsAuthRequest)
        {
            throw new NotImplementedException();
        }

        AccountViewItem[] IAuthenticationService.GetAccounts()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IAuthenticationAgent Members

        public event Action<LogonResponse> LoginCompleted;

        public void LoginAsync(string userName, string userPassword, string productCode, string productPassword)
        {
            throw new NotImplementedException();
        }

        public event Action<LogonResponse> LoginUserCompleted;

        public void LoginUserAsync(string userName, string userPassword)
        {
            throw new NotImplementedException();
        }

        public event Action<ServiceResponse> LogoffCompleted;

        public void LogoffAsync(string sessionId)
        {
            throw new NotImplementedException();
        }

        public event Action<ServiceResponse> PingCompleted;

        public void PingAsync(string sessionId)
        {
            throw new NotImplementedException();
        }

        public event Action<PMSSession> ValidateSessionCompleted;

        public void ValidateSessionAsync(PMSSession pmsSession)
        {
            throw new NotImplementedException();
        }

        public event Action<PMSSession> GetUserSessionCompleted;

        public void GetUserSessionAsync(PMSAuthRequest pmsAuthRequest)
        {
            throw new NotImplementedException();
        }

        event Action<AccountViewItem[]> IAuthenticationAgent.GetAccountsCompleted
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

    

        #endregion

        #region IAuthenticationAgent Members

        public event Action<PMSSession> AuthenticateUserCredentialsCompleted;

        public void AuthenticateUserCredentialsAsync(PMSAuthRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IAuthenticationService Members

        public PMSSession AuthenticateUserCredentials(PMSAuthRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
