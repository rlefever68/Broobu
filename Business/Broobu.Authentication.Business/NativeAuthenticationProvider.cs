using System;
using Pms.Framework.Domain;
using Pms.Authentication.Contract.Domain;
using Pms.MobiGuider.Repository.Contract.Domain;
using Pms.MobiGuider.Repository.Contract.Agent;
using System.Linq;
using Pms.MobiGuider.Repository.Contract;
using System.Security.Principal;

namespace Pms.Authentication.Business
{
    class NativeAuthenticationProvider : AuthenticationProviderBase
    {
        /// <summary>
        /// Gets the authentication modes.
        /// </summary>
        /// <returns></returns>
        public override AuthenticationMode[] GetAuthenticationModes()
        {
            return new AuthenticationMode[] 
            { 
                new AuthenticationMode() {} 
            };
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
            //using (var db = new AuthenticationServiceRepository())
            //{
            //    var response = new LogonResponse {Status = ResponseStatus.Success};
            //    response.Status = AuthenticateApplication(db, productCode, productPassword, userName);

            //    if (response.Status == ResponseStatus.Success)
            //    {
            //        return LoginUser(userName, userPassword);
            //    }

            //    return response;
            //}
            return new LogonResponse();
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns></returns>
        public override LogonResponse LoginUser(string userName, string passWord)
        {

            Account[] res = MobiGuiderRepositoryAgentFactory
                .CreateAccountRepositoryAgent()
                .SelectByUsernamePassword(userName, passWord);
            string sid = Guid.NewGuid().ToString();
            return new LogonResponse()
            {
                IsAuthenticated = (res != null),
                SessionId = sid,
                Session = new PMSSession()
                {
                    ConnectionTime = DateTime.Now,
                    AccountId = (res!=null) ? res[0].Id : AccountDefaults.Id,
                    SessionId = (res != null) ? sid : AccountDefaults.SessionId,
                    Username = (res != null) ? res[0].Username : AccountDefaults.UserName
                }
            };

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
            //using (var db = new AuthenticationServiceRepository())
            //{
            //    var response = new ServiceResponse { Status = ResponseStatus.Success };

            //    var session = SessionFactory.GetSession(sessionId);
            //    if (session == null)
            //    {
            //        response.Status = ResponseStatus.InvalidSession;
            //        return response;
            //    }

            //    response.Status = AuthenticateApplication(db, productCode, productPassword, session.Username);
            //    return response;

            //}
            return new ServiceResponse();

        }

        /// <summary>
        /// Pings the specified session id.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public override ServiceResponse Ping(string sessionId)
        {
            //var response = new ServiceResponse { Status = ResponseStatus.Success };

            //var session = SessionFactory.GetSession(sessionId);
            //if (session == null)
            //{
            //    response.Status = ResponseStatus.InvalidSession;
            //    return response;
            //}

            //this.LogDebug("Ping Service by {0}", session.Username);
            //return response;
            return new ServiceResponse();
        }

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public override ServiceResponse LogOff(string sessionId)
        {
            return null;
            //MobiGuiderRepositoryAgentFactory
            //    .CreateAccountRepositoryAgent()
            //    .Update(new Account() { });
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        public override UserResponse GetUserDetails(string sessionId)
        {
            //using (var db = new AuthenticationServiceRepository())
            //{
            //    var session = SessionFactory.GetSession(sessionId);
            //    if (session == null)
            //    {
            //        return new UserResponse { Status = ResponseStatus.InvalidSession };
            //    }

            //    var details = db.GetUserDetails(session.IdAccount);
            //    if (details == null)
            //    {
            //        var user = db.GetUser(session.IdAccount);
            //        return user != null
            //                   ? new UserResponse { Status = ResponseStatus.Success, Username = user.Username }
            //                   : new UserResponse { Status = ResponseStatus.Failed };
            //    }

            //    this.LogDebug("User details requested for {0}", session.Username);
            //    return new UserResponse
            //    {
            //        Username = details.Username,
            //        FirstName = details.Person.FirstName,
            //        LastName = details.Person.LastName,
            //        Status = ResponseStatus.Success
            //    };
            //}
            return new UserResponse();
        }

        /// <summary>
        /// Gets the available functions.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="applicationCode">The application code.</param>
        /// <returns></returns>
        public override FunctionsResponse GetAvailableFunctions(string sessionId, string applicationCode)
        {
            return new FunctionsResponse();
            //using (var db = new AuthenticationServiceRepository())
            //{
            //    var session = SessionFactory.GetSession(sessionId);
            //    if (session == null)
            //    {
            //        return new FunctionsResponse { Status = ResponseStatus.InvalidSession };
            //    }

            //    var userFunctions = db.GetFunctions(session.IdAccount, applicationCode);

            //    // merge the userFunctions that only differ in parameter
            //    var functions = new List<UserFunction>();
            //    foreach (var userFunction in userFunctions)
            //    {
            //        var function = new UserFunction
            //        {
            //            Id = userFunction.Id,
            //            Code = userFunction.Code
            //        };

            //        if (userFunction.HasParameter)
            //        {
            //            try
            //            {
            //                function.Parameter = XElement.Parse(userFunction.ParameterValue);
            //            }
            //            catch (Exception)
            //            {
            //                function.Parameter = null;
            //            }
            //        }

            //        var sameFunction = functions.FirstOrDefault(i => i.Id == function.Id);
            //        if (sameFunction != null)
            //        {
            //            // function already exists. Merge parameters
            //            if (userFunction.HasParameter)
            //            {
            //                // add distinct elements
            //                if ((function.Parameter != null) && (sameFunction.Parameter != null))
            //                {
            //                    var parameters = function.Parameter
            //                        .Elements()
            //                        .Except(sameFunction.Parameter.Elements(), new XElementComparer());

            //                    foreach (var parameter in parameters)
            //                    {
            //                        sameFunction.Parameter.Add(parameter);
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            functions.Add(function);
            //        }
            //    }

            //    this.LogDebug("{0} Requested function list for {1}", session.Username, applicationCode);
            //    return new FunctionsResponse { Status = ResponseStatus.Success, Functions = functions };
            //}

        }

        /// <summary>
        /// Validates the session.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="pmsSession">The PMS session.</param>
        /// <returns></returns>
        public override PMSSession ValidateSession(PMSSession session)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the user session.
        /// </summary>
        /// <param name="pmsAuthRequest">The PMS auth request.</param>
        /// <returns></returns>
        public override PMSSession GetUserSession(PMSAuthRequest pmsAuthRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns></returns>
        public override AccountViewItem[] GetAccounts()
        {
            return MobiGuiderRepositoryAgentFactory
                .CreateAccountRepositoryAgent()
                .SelectAll()
                .Select(CreateAccountViewItem)
                .ToArray();
        }

        private static AccountViewItem CreateAccountViewItem(Account it)
        {
            return new AccountViewItem()
                       {
                           AuthMode = it.AuthModeId,
                           CardId = it.CardId,
                           EmailAddress = it.Email,
                           FirstName = it.FirstName,
                           LastName = it.LastName,
                           MiddleName = it.MiddleName,
                           SessionId = it.SessionId,
                           Telephone1 = it.Telephone1,
                           Telephone2 = it.Telephone2,
                           UserName = it.Username,
                           ValidFrom = it.DtStart,
                           ValidUntil = it.DtEnd
                       };
        }



        //private ResponseStatus AuthenticateApplication(AuthenticationServiceRepository db, string productCode, string productPassword, string username)
        //{
        //    var application = db.GetApplication(productCode);
        //    if (application == null)
        //    {
        //        this.LogInfo("Authenticate User failed: {0} not found", productCode);
        //        return ResponseStatus.InvalidProduct;
        //    }

        //    if (!IsPasswordValid(application.Password, productPassword))
        //    {
        //        this.LogInfo("Authenticate Application failed: Invalid password for {0}", productCode);
        //        return ResponseStatus.InvalidProduct;
        //    }

        //    this.LogInfo("Application {0} Authenticated by {1}", productCode, username);
        //    return ResponseStatus.Success;
        //}



        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <returns></returns>
        public override PMSSession AuthenticateUserCredentials()
        {
            return new PMSSession();
        }

        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns></returns>
        public override PMSSession AuthenticateUserCredentials(WindowsIdentity identity)
        {
            if (identity.IsAuthenticated)
            {
                return new PMSSession() { Username = identity.Name, ConnectionTime = DateTime.Now, SessionId = Guid.NewGuid().ToString() };
            }
            return FrameworkDomainGenerator.CreateDefaultPMSSession();
        }
    }
}
