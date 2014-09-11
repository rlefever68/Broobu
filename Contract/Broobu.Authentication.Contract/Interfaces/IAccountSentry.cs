using System.ServiceModel;
using Broobu.Authentication.Contract.Domain;

using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;

namespace Broobu.Authentication.Contract.Interfaces
{
    [ServiceKnownType(typeof (Result))]
    [ServiceKnownType(typeof (Account))]
    [ServiceKnownType(typeof (WhereRequest))]
    [ServiceKnownType(typeof (RequestBase))]
    [ServiceContract(Namespace = AuthenticationServiceConst.Namespace)]
    public interface IAccountSentry
    {
        [OperationContract]
        Account GetAccountForSession(WulkaSession session);

        [OperationContract]
        ValidationResult ValidateCredentials(string userName, string password);

        [OperationContract]
        string GetAccountForUser(string userName);

        [OperationContract]
        Account SaveAccountItem(Account accountItem);

        [OperationContract]
        Account Activate(string accountId, string username);

        [OperationContract]
        string GetAccountById(string id);

        [OperationContract]
        string[] GetAccounts();
    }
}