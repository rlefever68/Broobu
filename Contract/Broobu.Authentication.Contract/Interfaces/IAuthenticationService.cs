

using System.ServiceModel;
using Pms.Framework.Domain;
using Pms.Authentication.Contract.Domain;
namespace Pms.Authentication.Contract.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    public interface IAuthenticationService
    {

        //[OperationContract]
        //PMSSession AuthenticateUserCredentials(PMSAuthRequest request);

        /// <summary>
        /// Authenticates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The password.</param>
        /// <param name="productCode">A valid product code</param>
        /// <param name="productPassword">A valid product password</param>
        /// <returns></returns>
        [OperationContract]
        LogonResponse Login(string userName, string userPassword, string productCode, string productPassword);

        /// <summary>
        /// Logins the user on the Authentication Service.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns>a Logon Response</returns>
        [OperationContract]
        LogonResponse LoginUser(string userName, string userPassword);


        /// <summary>
        /// Selects the given application with the current user settings
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="productCode">The product code.</param>
        /// <param name="productPassword">The product password.</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse SelectApplication(string sessionId, string productCode, string productPassword);


        /// <summary>
        /// Logoffs the specified session id.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse Logoff(string sessionId);

        /// <summary>
        /// Prevent the session from expiring.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        [OperationContract]
        ServiceResponse Ping(string sessionId);

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns></returns>
        [OperationContract]
        UserResponse GetUserDetails(string sessionId);

        /// <summary>
        /// Gets the available functions of the specified application.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <param name="applicationCode">The app id.</param>
        /// <returns></returns>
        [OperationContract]
        FunctionsResponse GetAvailableFunctions(string sessionId, string applicationCode);

        /// <summary>
        /// Gets the version of the Authentication Service
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ServiceVersion GetVersion();


        [OperationContract]
        PMSSession ValidateSession(PMSSession pmsSession);


        [OperationContract]
        PMSSession GetUserSession(PMSAuthRequest pmsAuthRequest);


        [OperationContract]
        AccountViewItem[] GetAccounts();




    }


    

}