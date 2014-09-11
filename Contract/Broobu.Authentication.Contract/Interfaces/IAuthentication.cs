using System.ServiceModel;
using Broobu.Authentication.Contract.Domain;

using Wulka.Domain;
using System;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;

namespace Broobu.Authentication.Contract.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(Namespace = AuthenticationServiceConst.Namespace)]
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(IdResult))]
    [ServiceKnownType(typeof(DomainObject<WulkaSession>))]
    [ServiceKnownType(typeof(DomainObject<UserRegistrationInfo>))]
    public interface IAuthentication
    {
        [OperationContract]
        WulkaSession AuthenticateUserCredentials();
        [OperationContract]
        WulkaSession AuthenticateByUserNameAndPassword(string userName, string passWord);
        [OperationContract]
        UserRegistrationInfo RegisterNewUser(UserRegistrationInfo item);

        [OperationContract]
        IdResult<bool> UserNameExists(string userName);

        [OperationContract]
        WulkaSession TerminateSession();
    }


    

}