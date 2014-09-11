// ***********************************************************************
// Assembly         : Broobu.Authentication.Business
// Author           : ON8RL
// Created          : 12-11-2013
//
// Last Modified By : ON8RL
// Last Modified On : 06-22-2014
// ***********************************************************************
// <copyright file="AuthenticationProvider.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Principal;
using System.Transactions;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Broobu.Publisher.Contract;
using Broobu.Publisher.Contract.Domain;
using Broobu.SessionProxy.Contract;
using Wulka.Authentication;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;
using Wulka.Exceptions;
using NLog;

namespace Broobu.Authentication.Business.Providers
{
    /// <summary>
    /// Class AuthenticationProvider.
    /// </summary>
    public class Authentications : UserNamePasswordValidator, IAuthentications
    {



        private readonly Logger _logger = LogManager.GetCurrentClassLogger();



        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        /// <value>The identity.</value>
        public IIdentity Identity { get; set; }

        /// <summary>
        /// When overridden in a derived class, validates the specified username and password.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <exception cref="SecurityTokenException"></exception>
        /// <exception cref="System.IdentityModel.Tokens.SecurityTokenException"></exception>
        public override void Validate(string userName, string password)
        {
            var res = ValidateInternal(userName, password);
            if (!res.IsValid)
                throw new SecurityTokenException(res.AllErrors);
        }

        /// <summary>
        /// Validates the internal.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>ValidationResult.</returns>
        private ValidationResult ValidateInternal(string userName, string password)
        {
            _logger.Info("Validating User Credentials for {0}", userName);
            try
            {
                var res = AuthenticationProvider
                    .Accounts
                    .ValidateCredentials(userName, password);
                _logger.Info("User {0} validated", userName);
                return res;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
                return null;
            }
        }

        #region IAuthentication Members


        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateUserCredentials()
        {
            if (Identity == null)
            {
                _logger.Error("Identity is null! Check infrastructure!");
                return SessionFactory.CreateDefaultWulkaSession();
            }
            _logger.Info("Authenticating user {0}", Identity.Name);
            if (!Identity.IsAuthenticated)
                return SessionFactory.CreateDefaultWulkaSession();
            WulkaSession sess = null;
            using (var spc = new TransactionScope())
            {
                sess = CreateValidWulkaSession(Identity.Name, (Identity is WindowsIdentity) ? AuthenticationMode.Windows : AuthenticationMode.Native);
                GetAccountForSession(sess);
                spc.Complete();
            }
            return sess;
        }


        /// <summary>
        /// Authenticates the by user name and password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateByUserNameAndPassword(string userName, string passWord)
        {
            return AuthenticateUserCredentials(userName, passWord);
        }

        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>AccountItem.</returns>
        private Account GetAccountForSession(WulkaSession session)
        {
            return
                AuthenticationProvider
                .Accounts
                .GetAccountForSession(session);
        }

        /// <summary>
        /// Creates the valid Wulka session.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>WulkaSession.</returns>
        private WulkaSession CreateValidWulkaSession(string name, string mode)
        {
            var session = new WulkaSession()
                {
                    Username = name,
                    AuthenticationMode = mode,
                    ApplicationFunctionId = AuthenticationDefaults.ServiceCode
                };
            try
            {
                var acc = GetAccountForSession(session);
                if (acc != null)
                {
                    session.IsKnown = !String.IsNullOrEmpty(acc.Email);
                    session.AccountId = acc.Id;
                    session.FirstName = acc.FirstName;
                    session.LastName = acc.LastName;
                }
                session = StartSession(session);
            }
            catch (Exception ex)
            {
                _logger.Error("A Valid Session could not be created. Message: {0}", ex.GetCombinedMessages());
            }
            return session;
        }

        /// <summary>
        /// Starts the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        private WulkaSession StartSession(WulkaSession session)
        {
            try
            {
                _logger.Info("Starting Session for {0}", session.Username);
                var res = SessionProxyPortal
                    .SessionProxy
                    .StartSession(session);
                if (res == null)
                {
                    _logger.Info("Returned null session");
                    return session;
                }
                _logger.Info("Session [{0}] created for user [{1}]. Known user: {2}", res.Id, res.Username,
                    res.IsKnown);
                return res;
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to start Session for {0}", session.Username);
                _logger.Error(ex.GetCombinedMessages);
                return session;
            }
        }

        #endregion

        #region IAuthenticationProvider Members


        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {

        }

        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateUserCredentials(IIdentity identity)
        {
            return identity.IsAuthenticated
                ? CreateValidWulkaSession(identity.Name, identity.AuthenticationType)
                : SessionFactory.CreateDefaultWulkaSession();
        }

        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns>WulkaSession.</returns>
        /// <exception cref="SecurityTokenException"></exception>
        public WulkaSession AuthenticateUserCredentials(string userName, string passWord)
        {
            var res = ValidateInternal(userName, passWord);
            if (!res.IsValid)
                throw new SecurityTokenException(res.AllErrors);
            return CreateValidWulkaSession(userName, AuthenticationMode.Native);
        }

        #endregion


        /// <summary>
        /// Registers the new user.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>NewUserRegistrationInfo.</returns>
        public UserRegistrationInfo RegisterNewUser(UserRegistrationInfo item)
        {
            _logger.Info("Registering user {0}", item.UserName);
            try
            {
                var ait = AuthenticationProvider
                    .Accounts.
                    GetAccountForUser(item.UserName);
                if (ait != null)
                    return ait.ToUserRegistrationInfo();
                ait = new Account
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    AuthModeId = item.AuthMode,
                    Pwd = item.Password,
                    Username = item.Email
                };
                ait = AuthenticationProvider
                    .Accounts
                    .SaveAccountItem(ait);
                SendConfirmationEmail(ait);
                return ait.ToUserRegistrationInfo();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
                item.AddError(ex.Message);
                return item;
            }
        }


        private void SendConfirmationEmail(Account ait)
        {
            _logger.Info("Sending Confirmation Email for '{0}'", ait.Username);
            PublisherPortal
                .Publisher
                .Publish(ait.ToConfirmationEmailInfo());
        }


        /// <summary>
        /// Users the name exists.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>IdResult&lt;System.Boolean&gt;.</returns>
        public IdResult<bool> UserNameExists(string userName)
        {
            _logger.Info("Checking if user[{0}] exists.");
            var res = AuthenticationProvider
                .Accounts
                .GetAccountForUser(userName);
            if (res == null)
                return new IdResult<bool>() { Id = false };
            return new IdResult<bool>
            {
                Id = true
            };
        }



        /// <summary>
        /// Terminates the session.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession TerminateSession()
        {
            return TerminateSession(WulkaSession.Current);
        }

        /// <summary>
        /// Terminates the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession TerminateSession(WulkaSession session)
        {
            return SessionProxyPortal
                .SessionProxy
                .EndSession(session);
        }





    }

}
