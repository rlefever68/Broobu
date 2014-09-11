// ***********************************************************************
// Assembly         : Broobu.Authentication.Business
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-22-2014
// ***********************************************************************
// <copyright file="AuthenticationProvider.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Configuration;
using Broobu.Authentication.Business.Providers;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Broobu.Publisher.Contract.Domain;

namespace Broobu.Authentication.Business
{
    /// <summary>
    /// Class AuthenticationProvider.
    /// </summary>
    public static class AuthenticationProvider
    {
        /// <summary>
        /// Creates the provider.
        /// </summary>
        /// <value>The authentications.</value>
        /// <param name="key">The key.</param>
        public static IAuthentications Authentications
        {
            get 
            {
                return new Authentications();
            }
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public static IAccounts Accounts
        {
            get
            {
                return new Accounts();
            }

        }



        /// <summary>
        /// To the user registration information.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>UserRegistrationInfo.</returns>
        public static UserRegistrationInfo ToUserRegistrationInfo(this Account item)
        {
            if (item == null) return null;
            return new UserRegistrationInfo
            {
                Id = item.Id,
                AuthMode = item.AuthModeId,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Mobile = item.Telephone1,
                Password = item.Pwd,
                Telephone = item.Telephone2,
                UserName = item.Username
            };
        }



        
        public static PublishInfo ToConfirmationEmailInfo(this Account account)
        {
            var res = new PublishInfo() {
                Subject = String.Format("Confirming Your registration"),
                Targets               = new[]{account.Email},
                TemplateId            = ConfirmationEmailTemplate.ID,
            };
            res.AddParameter("EmailFirstName", account.FirstName);
            res.AddParameter("ActivationLink", String.Format(AuthConfig.ActivationLinkTemplate, account.Id,account.Username));
            return res;
        }


        public static Account ToAccount(this UserRegistrationInfo viewItem)
        {
            if (viewItem == null) return null;
            return new Account
            {
                Id = viewItem.Id,
                AuthModeId = viewItem.AuthMode,
                Email = viewItem.Email,
                FirstName = viewItem.FirstName,
                LastName = viewItem.LastName,
                Pwd = viewItem.Password,
                Telephone1 = viewItem.Telephone,
                Telephone2 = viewItem.Mobile,
                Username = viewItem.UserName
            };
        }





    }

    public class AuthConfig
    {
        public static string ActivationLinkTemplate {
            get {
                return Convert.ToString(ConfigurationManager.AppSettings["Activation.LinkTemplate"]);
            }
        }
    }
}
