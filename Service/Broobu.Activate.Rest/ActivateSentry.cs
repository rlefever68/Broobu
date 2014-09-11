// ***********************************************************************
// Assembly         : Broobu.Activate.Rest
// Author           : Rafael Lefever
// Created          : 08-10-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="ActivateSentry.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Broobu.Authentication.Contract;
using Wulka.Exceptions;
using NLog;

namespace Broobu.Activate.Rest
{
    /// <summary>
    /// Class ActivateSentry.
    /// </summary>
    public class ActivateSentry : IActivate
    {


        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Activates the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="username"></param>
        /// <returns>System.String.</returns>
        public string Activate(string accountId, string username)
        {
            try
            {
                Logger.Info("Activating account {0} for user {1}", accountId,username);
                var res = AuthenticationPortal
                    .Accounts
                    .Activate(accountId,username);
                var s = String.Format("Account '{0}' of {1} {2} has succesfully been activated!", res.Username, res.FirstName, res.LastName);
                Logger.Info(s);
                return s;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages());
                return exception.GetCombinedMessages();
            }
        }
    }
}
