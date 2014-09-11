// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-10-2014
// ***********************************************************************
// <copyright file="ApplicationFunctionAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.EcoSpace.Contract.Agents
{
    /// <summary>
    ///     Class ApplicationFunctionAgent.
    /// </summary>
    internal class ApplicationFunctionAgent : DiscoProxy<IApplicationFunction>, IApplicationFunctionAgent
    {
        public ApplicationFunctionAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        ///     Gets the applet information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ApplicationFunction.</returns>
        public MenuButton GetAppletInfo(string id)
        {
            IApplicationFunction clt = CreateClient();
            try
            {
                return clt.GetAppletInfo(id);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Gets all application functions.
        /// </summary>
        /// <returns>ApplicationFunctionItem[][].</returns>
        public MenuButton[] GetAllApplicationFunctions()
        {
            IApplicationFunction clt = CreateClient();
            try
            {
                return clt.GetAllApplicationFunctions();
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Saves the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        public MenuButton[] SaveApplicationFunctions(MenuButton[] applicationFunctionViewItems)
        {
            IApplicationFunction clt = CreateClient();
            try
            {
                return clt.SaveApplicationFunctions(applicationFunctionViewItems);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Deletes the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        public MenuButton[] DeleteApplicationFunctions(MenuButton[] applicationFunctionViewItems)
        {
            IApplicationFunction clt = CreateClient();
            try
            {
                return clt.DeleteApplicationFunctions(applicationFunctionViewItems);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Occurs when [get all application functions completed].
        /// </summary>
        public event Action<MenuButton[]> GetAllApplicationFunctionsCompleted;

        /// <summary>
        ///     Gets all application functions asynchronous.
        /// </summary>
        public void GetAllApplicationFunctionsAsync()
        {
            MenuButton[] result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = GetAllApplicationFunctions(); };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (GetAllApplicationFunctionsCompleted != null)
                        GetAllApplicationFunctionsCompleted(result);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        ///     Gets all application functions asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
        public void GetAllApplicationFunctionsAsync(Action<MenuButton[]> action)
        {
            MenuButton[] result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = GetAllApplicationFunctions(); };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (action != null)
                        action(result);
                };
                wrk.RunWorkerAsync();
            }
        }

        #region IApplicationFunction Members

        /// <summary>
        ///     Gets the menu for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        public MenuButton[] GetMenuForUser(string userName)
        {
            IApplicationFunction clt = CreateClient();
            try
            {
                return clt.GetMenuForUser(userName);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        ///     Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return AuthorizationServiceConst.Namespace;
        }

        #endregion
    }
}