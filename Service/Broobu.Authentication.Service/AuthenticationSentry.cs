// ***********************************************************************
// Assembly         : Broobu.Authentication.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-24-2013
// ***********************************************************************
// <copyright file="AuthenticationService.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Broobu.Authentication.Business;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;
using Wulka.Networking.Wcf;

namespace Broobu.Authentication.Service
{



    /// <summary>
    /// Class AuthenticationService.
    /// </summary>
    public class AuthenticationSentry : SentryBase,  IAuthentication
    {



        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            AuthenticationProvider
                .Authentications
                .RegisterRequiredDomainObjects();
        }



        #region IAuthentication Members

        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateUserCredentials()
        {

            return AuthenticationProvider
                .Authentications
                .AuthenticateUserCredentials(ServiceSecurityContext.Current.PrimaryIdentity);
        }

        /// <summary>
        /// Authenticates the by user name and password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateByUserNameAndPassword(string userName, string passWord)
        {
            return AuthenticationProvider
                .Authentications
                .AuthenticateByUserNameAndPassword(userName,passWord);
        }

        /// <summary>
        /// Registers the new user.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>NewUserRegistrationViewItem.</returns>
        public UserRegistrationInfo RegisterNewUser(UserRegistrationInfo item)
        {
            return AuthenticationProvider
                .Authentications
                .RegisterNewUser(item);
        }

        /// <summary>
        /// Terminates the session.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession TerminateSession()
        {
            return AuthenticationProvider
                .Authentications
                .TerminateSession(new WulkaSession() { Id = SessionId, Username = UserName });
        }

        /// <summary>
        /// Users the name exists.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>IdResult{System.Boolean}.</returns>
        public IdResult<bool> UserNameExists(string userName)
        {
            return AuthenticationProvider
                .Authentications
                .UserNameExists(userName);
        }




        #endregion

    }
}