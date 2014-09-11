// ***********************************************************************
// Assembly         : Broobu.Authorization.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="AccountProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Broobu.EcoSpace.Business.Interfaces;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using Iris.Fx.Exceptions;
using NLog;

namespace Broobu.EcoSpace.Business.Workers
{
    /// <summary>
    /// Class AccountProvider.
    /// </summary>
    class Accounts :  IAccounts
    {


        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();






        /// <summary>
        /// Gets the account for session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>AccountItem.</returns>
        public Account GetAccountForSession(IrisSession session)
        {
            var acc = GetAccountForUser(session.Username);
            if (acc != null) return acc;
            else
            {
                var result = new Account
                {
                    Username = session.Username,
                    FirstName = "New",
                    LastName = "User",
                    SessionId = session.SessionId,
                    AuthModeId = session.AuthenticationMode,
                    DtStart = DateTime.Now,
                    DtEnd = DateTime.Now.AddDays(10),
                    Email = String.Empty
                };
                Provider<Account>.Save(result);
                return result;
            }
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>AccountItem[][].</returns>
        public Account[] GetAllAccounts()
        {
            return Provider<Account>.GetAll();
        }

        /// <summary>
        /// Finds the name of the by user.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
            using (var scp = new TransactionScope())
            {
                try
                {
                    var acc = AuthorizationDomainGenerator.CreateGuestAccount();
                    Provider<Account>.Save(acc);
                    var admin = AuthorizationDomainGenerator.CreateAdministratorAccount();
                    Provider<Account>.Save(admin);
                    scp.Complete();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.GetCombinedMessages());
                }
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
            _logger.Info("Validating credentials for {0}", userName);
            var res = new ValidationResult();
            var req = new RequestBase() { 
                Function = String.Format("if(doc.Username=='{0}' && doc.Pwd=='{1}' && doc.AuthModeId=='{2}') " +
                                         "emit(doc.Id,doc)",
                userName, password, AuthenticationMode.Native)
            };
            var accounts = Provider<Account>.Query(req);
            res.IsValid = accounts.Length > 0;
            _logger.Info("I found {0} items.",accounts.Length);
            return res;
        }



        /// <summary>
        /// Gets the account for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>AccountItem.</returns>
        public Account GetAccountForUser(string userName)
        {
            Account acc = null;
            var req = new WhereRequest()
            {
                Field = "Username",
                Value = userName
            };
            var res = Provider<Account>
                .Where(req);
            if (res.Any())
            {
                acc = res.First();
            }
            if(acc!=null)
                _logger.Info("Account for username:{0} \t id:{1} found!", acc.Username, acc.Id);
            return acc;
        }




       


        /// <summary>
        /// Saves the account item.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>AccountItem.</returns>
        public Account SaveAccountItem(Account it)
        {
            _logger.Info("Saving item id:{0} -- {1} \t {2} {3} \t {4}",
                it.Id,
                it.Username,
                it.FirstName,
                it.LastName,
                it.Email
                );
            return Provider<Account>.Save(it);
        }

        /// <summary>
        /// Gets the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>AccountItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Account[] GetAccountsForRole(string roleId)
        {
            var req = new WhereRequest()
            {
                Field = "RoleId",
                Value = roleId
            };
            return Provider<AccountXRole>
                .Query(req)
                .Select(accountXRole => Provider<Account>.GetById(accountXRole.AccountId))
                .ToArray();
        }

        /// <summary>
        /// Saves the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AccountXRole[] LinkAccountsToRole(string roleId, Account[] accounts)
        {
            return Provider<AccountXRole>
                .Save(accounts.Select(accountItem => new AccountXRole() {AccountId = accountItem.Id, RoleId = roleId}).ToArray());
        }

        /// <summary>
        /// Deletes the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AccountXRole[] UnlinkAccountsFromRole(string roleId, Account[] accounts)
        {
            var lst = new List<AccountXRole>();
            foreach (var res in accounts
                .Select(account => new AccountRoleRequest() {AccountId = account.Id,RoleId = roleId})
                .Select(Provider<AccountXRole>.Query))
            {
                lst.AddRange(res.Select(Provider<AccountXRole>.Delete));
            }
            return lst.ToArray();
        }

    }
}
