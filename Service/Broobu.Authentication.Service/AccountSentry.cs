// ***********************************************************************
// Assembly         : Broobu.Authorization.Service
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="AuthorizationService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using Broobu.Authentication.Business;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Extensions;
using Wulka.Networking.Wcf;
using Wulka.Utils;

namespace Broobu.Authentication.Service
{

    /// <summary>
    /// Class AuthorizationService.
    /// </summary>
    public class AccountSentry : SentryBase, IAccountSentry
    {


        /// <summary>
        /// You MUST override this method, but you cannot use
        /// Initializing code in the constructor that references itself (since the object is not yet created) - Obsolete remark
        /// REMARK: since the code has been moved to the onOpen method of the servicehost; you can be certain now that
        /// the object has been created.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            AuthenticationProvider
                .Accounts
                .RegisterRequiredDomainObjects();
        }


        /// <summary>
        /// Gets the account for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>AccountItem.</returns>
        public string GetAccountForUser(string userName)
        {
            var acc = AuthenticationProvider
                .Accounts
                .GetAccountForUser(userName);
            return acc.Zip();
        }

        /// <summary>
        /// Gets the account for session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>AccountItem.</returns>
        public Account GetAccountForSession(WulkaSession session)
        {
            return AuthenticationProvider
                .Accounts
                .GetAccountForSession(session);
        }

        public string GetAccountById(string id)
        {
            return AuthenticationProvider
                .Accounts
                .GetAccountById(id)
                .Zip();
        }

        

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>AccountItem[][].</returns>
        public string[] GetAccounts()
        {
            return AuthenticationProvider
                .Accounts
                .GetAccounts()
                .Zip()
                .ToArray();
        }

        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>ValidationResult.</returns>
        public ValidationResult ValidateCredentials(string userName, string password)
        {
            return AuthenticationProvider
                .Accounts
                .ValidateCredentials(userName, password);
        }

      


        /// <summary>
        /// Saves the account item.
        /// </summary>
        /// <param name="accountItem">The account item.</param>
        /// <returns>AccountItem.</returns>
        public Account SaveAccountItem(Account accountItem)
        {
            return AuthenticationProvider
                .Accounts
                .SaveAccountItem(accountItem);
        }

        public Account Activate(string accountId, string userName)
        {
            return AuthenticationProvider
                .Accounts
                .Activate(accountId, userName);

        }
    }
}
