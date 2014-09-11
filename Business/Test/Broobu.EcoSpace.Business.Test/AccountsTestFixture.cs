using System;
using System.Threading;
using Broobu.Authorization.Business.Interfaces;
using Broobu.Authorization.Contract.Domain;
using Broobu.Authorization.Contract.Interfaces;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authorization.Business.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class AccountsTestFixture : IAccounts
    {


        [TestMethod]
        public void Try_GetAccountForGuest()
        {
            RegisterRequiredDomainObjects();
            var res = GetAccountForUser("Guest");
            Console.WriteLine(res);
        }

        public Account GetAccountForSession(IrisSession session)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResult ValidateCredentials(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccountForUser(string userName)
        {
            return AuthorizationProvider
                .Accounts
                .GetAccountForUser(userName);
        }

        public Account[] GetAllAccounts()
        {
            throw new System.NotImplementedException();
        }

        public Account SaveAccountItem(Account accountItem)
        {
            throw new System.NotImplementedException();
        }

        public Account[] GetAccountsForRole(string roleId)
        {
            throw new System.NotImplementedException();
        }

        public AccountXRole[] LinkAccountsToRole(string roleId, Account[] accounts)
        {
            throw new System.NotImplementedException();
        }

        public AccountXRole[] UnlinkAccountsFromRole(string roleId, Account[] accounts)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterRequiredDomainObjects()
        {
            AuthorizationProvider
                .Accounts
                .RegisterRequiredDomainObjects();
        }
    }
}
