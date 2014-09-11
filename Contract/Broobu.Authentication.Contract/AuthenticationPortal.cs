// ***********************************************************************
// Assembly         : Broobu.Authentication.Contract
// Author           : ON8RL
// Created          : 12-11-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-15-2013
// ***********************************************************************
// <copyright file="AuthenticationAgentFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Authentication.Contract.Agent;
using Broobu.Authentication.Contract.Interfaces;

namespace Broobu.Authentication.Contract
{
    /// <summary>
    /// Class AuthenticationAgentFactory.
    /// </summary>
    public static class AuthenticationPortal
    {


        /// <summary>
        ///     Creates the account agent.
        /// </summary>
        /// <returns>IAccountAgent.</returns>
        public static IAccountAgent Accounts
        {
            get { return new AccountAgent(null); }
        }



        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>IAuthenticationAgent.</returns>
        public static IAuthenticationAgent CreateAgent(string userName, string password)
        {
           return new AuthenticationAgent(userName, password);
        }




        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns>IAuthenticationAgent.</returns>
        public static IAuthenticationAgent Authentication
        {
            get { return new AuthenticationAgent(null); }
        }
    }
}
