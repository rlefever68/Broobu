using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Pms.Authentication.Domain;
using Pms.Framework.Domain;

namespace Pms.Authentication.Business
{
    class MobiGuiderAuthenticationProvider : AuthenticationProviderBase
    {
        /// <summary>
        /// Gets the authentication modes.
        /// </summary>
        /// <returns></returns>
        public override AuthenticationModeViewItem[] GetAuthenticationModes()
        {
            return new AuthenticationModeViewItem[] 
            { 
                new AuthenticationModeViewItem() {} 
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
        public override LogonResponse LoginUser(string userName, string userPassword)
        {


            return  new LogonResponse();

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
            //var response = new ServiceResponse();
            //var session = SessionFactory.GetSession(sessionId);
            //if (session == null)
            //{
            //    response.Status = ResponseStatus.InvalidSession;
            //    return response;
            //}

            //SessionFactory.DeleteSession(sessionId);

            //response.Status = ResponseStatus.Success;
            //return response;
            return new ServiceResponse();
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

        public override PMSSession ValidateSession(string sessionId, int pmsSession)
        {
            throw new NotImplementedException();
        }

        public override PMSSession GetUserSession(PMSAuthRequest pmsAuthRequest)
        {
            throw new NotImplementedException();
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


    }
}
