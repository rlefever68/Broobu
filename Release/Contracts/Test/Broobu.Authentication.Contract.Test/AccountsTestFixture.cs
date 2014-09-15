// ***********************************************************************
// Assembly         : Broobu.Authentication.Contract.Test
// Author           : Rafael Lefever
// Created          : 07-22-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-14-2014
// ***********************************************************************
// <copyright file="AccountsTestFixture.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Agent;
using Wulka.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Domain.Authentication;

namespace Broobu.Authentication.Contract.Test
{
    /// <summary>
    /// Class AccountsTestFixture.
    /// </summary>
    [TestClass]
    public class AccountsTestFixture : IAccountAgent
    {


        [TestMethod]
        public void Try_GetAccountsEndpoints()
        {
            var res = GetEndpoints(String.Format("{0}:IAccountSentry", AuthenticationServiceConst.Namespace));
            foreach (var serializableEndpoint in res)
            {
                Console.WriteLine("{0}", serializableEndpoint.Address);
            }
        }

        private SerializableEndpoint[] GetEndpoints(string contract)
        {
            return DiscoPortal
                .Disco
                .GetEndpoints(contract);
        }


        /// <summary>
        /// Try_s the get accounts.
        /// </summary>
        [TestMethod]
        public void Try_GetAccounts()
        {
            var res = GetAccounts();
            foreach (var account in res)
            {
                Console.WriteLine(account);
            }
        }




        /// <summary>
        /// Gets the account for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Account.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Account GetAccountForUser(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Activates the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>Account.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Account Activate(string accountId, string username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the account item.
        /// </summary>
        /// <param name="accountItem">The account item.</param>
        /// <returns>Account.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Account SaveAccountItem(Account accountItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Account.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Account GetAccountById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the account for session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>Account.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Account GetAccountForSession(WulkaSession session)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>IEnumerable&lt;IAccount&gt;.</returns>
        public IEnumerable<IAccount> GetAccounts()
        {
            return AuthenticationPortal
                .Accounts
                .GetAccounts();
        }

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void RegisterRequiredDomainObjects()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>ValidationResult.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValidationResult ValidateCredentials(string userName, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the accounts asynchronous.
        /// </summary>
        /// <param name="act">The act.</param>
        public void GetAccountsAsync(Action<IEnumerable<IAccount>> act = null)
        {
            
        }
    }
}
