// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 08-14-2014
// ***********************************************************************
// <copyright file="AccountAgent.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;


namespace Broobu.Authentication.Contract.Agent
{
    /// <summary>
    /// Class AccountAgent.
    /// </summary>
    internal class AccountAgent : DiscoProxy<IAccountSentry>, IAccountAgent
    {
        public AccountAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        /// Gets the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Account.</returns>
        public Account GetAccountById(string id)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetAccountById(id)
                    .Unzip<Account>();
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
           
        }

        /// <summary>
        /// Gets the accounts asynchronous.
        /// </summary>
        /// <param name="act">The act.</param>
        public void GetAccountsAsync(Action<IEnumerable<IAccount>> act = null)
        {
            var res = (IEnumerable<IAccount>)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = GetAccounts();
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());
                    }
                };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    wrk.Dispose();
                    act(res);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the account for session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>AccountItem.</returns>
        public Account GetAccountForSession(WulkaSession session)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetAccountForSession(session);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>AccountItem[][].</returns>
        public IEnumerable<IAccount> GetAccounts()
        {
            var clt = CreateClient();
            try
            {
                string[] accs = clt.GetAccounts();
                return accs
                    .Unzip<Account>()
                    .ToArray();
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>ValidationResult.</returns>
        public ValidationResult ValidateCredentials(string userName, string password)
        {
            var clt = CreateClient();
            try
            {
                return clt.ValidateCredentials(userName, password);
            }
            finally
            {
                CloseClient(clt);
            }
        }




        /// <summary>
        /// Gets the account for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>AccountItem.</returns>
        public Account GetAccountForUser(string userName)
        {

            try
            {
                return Client
                    .GetAccountForUser(userName)
                    .Unzip<Account>();
            }
            finally
            {
                CloseClient(Client);
            }
        }

        /// <summary>
        /// Activates the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>Account.</returns>
        public Account Activate(string accountId, string username)
        {
            try
            {
                return Client.Activate(accountId,username);
            }
            finally
            {
                CloseClient(Client);
            }
            
        }




        /// <summary>
        /// Saves the account item.
        /// </summary>
        /// <param name="accountItem">The account item.</param>
        /// <returns>AccountItem.</returns>
        public Account SaveAccountItem(Account accountItem)
        {
            var clt = CreateClient();
            try
            {
                return clt.SaveAccountItem(accountItem);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return AuthenticationServiceConst.Namespace;
        }
    }
}