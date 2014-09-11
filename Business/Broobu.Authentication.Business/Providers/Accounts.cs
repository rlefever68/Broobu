// ***********************************************************************
// Assembly         : Broobu.Authorization.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 08-14-2014
// ***********************************************************************
// <copyright file="AccountProvider.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Exceptions;

using NLog;

namespace Broobu.Authentication.Business.Providers
{
    /// <summary>
    /// Class AccountProvider.
    /// </summary>
    class Accounts :   IAccounts
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
        public Account GetAccountForSession(WulkaSession session)
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
        /// Gets the accounts.
        /// </summary>
        /// <returns>IEnumerable&lt;IAccount&gt;.</returns>
        public IEnumerable<IAccount> GetAccounts()
        {
            var req = new RequestBase() {
                Function = "emit(doc.Id,doc)",
                StartId = null,
                Limit = 10

            };
            return Provider<Account>.Query(req);
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
                    var acc = Generator.CreateGuestAccount();
                    Provider<Account>.Save(acc);
                    var admin = Generator.CreateAdministratorAccount();
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
            var req = new RequestBase() 
            { 
                Function = String.Format("if(doc.Username=='{0}' && doc.Pwd=='{1}' && doc.Active=='1') " +
                                         "emit(doc.Id,doc)",userName, password),
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
                Value = userName,
                KeepView = false
            };
            var res = Provider<Account>.Where(req);
            if (res.Any())
            {
                acc = res.First();
                acc.Pwd = "****************";
            }
            if(acc!=null)
                _logger.Info("Account for username:{0} \t id:{1} found!", acc.Username, acc.Id);
            return acc;
        }


        /// <summary>
        /// Gets the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Account.</returns>
        public Account GetAccountById(string id)
        {
            var res = Provider<Account>.GetById(id);
            if (res == null) return null;
            res.Pwd = "****************";
            _logger.Info("Account for username:{0} \t id:{1} found!", res.Username, res.Id);
            return res;
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
        /// Activates the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Account.</returns>
        /// <exception cref="System.Exception"></exception>
        public Account Activate(string accountId, string userName)
        {
            var acc = Provider<Account>.GetById(accountId);
            if (acc == null)
            {
                _logger.Info("Activation:Account {0} was not found.", accountId);
                throw new Exception(String.Format("Account {0} does not exist.", accountId));
            }
            if (acc.Username != userName)
            {
                _logger.Info("Activation:User names do not match");
                throw new Exception(String.Format("User names do not match."));
            }
            acc.Active = 1;
            acc.DtStart = DateTime.UtcNow;
            acc.DtEnd = acc.DtStart.Value.AddMonths(36);
            return Provider<Account>.Save(acc);
        }



    }
}
