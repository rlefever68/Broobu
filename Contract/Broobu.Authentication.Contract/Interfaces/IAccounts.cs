using System.Collections.Generic;
using Broobu.Authentication.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.Authentication.Contract.Interfaces
{
    public interface IAccounts
    {
        Account GetAccountForUser(string userName);
        Account Activate(string accountId, string username);
        Account SaveAccountItem(Account accountItem);
        Account GetAccountById(string id);
        Account GetAccountForSession(WulkaSession session);
        IEnumerable<IAccount> GetAccounts();
        void RegisterRequiredDomainObjects();
        ValidationResult ValidateCredentials(string userName, string password);
    }
}