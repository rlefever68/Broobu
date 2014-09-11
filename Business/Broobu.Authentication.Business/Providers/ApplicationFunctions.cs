// ***********************************************************************
// Assembly         : Broobu.Authorization.Business
// Author           : Rafael Lefever
// Created          : 01-12-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-25-2014
// ***********************************************************************
// <copyright file="ApplicationFunctions.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Authorization.Business.Interfaces;
using Broobu.Authorization.Contract.Domain;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using Iris.Fx.Exceptions;
using NLog;


namespace Broobu.Authorization.Business.Workers
{
    /// <summary>
    /// Class ApplicationFunctions.
    /// </summary>
    class ApplicationFunctions :  IApplicationFunctions
    {
        #region IApplicationFunctionProvider Members


        /// <summary>
        /// The _logger
        /// </summary>
        private Logger _logger = LogManager.GetLogger("ApplicationFunctions");



        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
            try
            {
                ApplicationFunction rootItem = AuthorizationProvider.ApplicationFunctions.RootFolder;
                Provider<ApplicationFunction>.Save(rootItem);
                ApplicationFunction unregisteredItem = AuthorizationProvider.ApplicationFunctions.UnRegisteredFolder;
                Provider<ApplicationFunction>.Save(unregisteredItem);
                ApplicationFunction communityItem = AuthorizationProvider.ApplicationFunctions.CommunityFolder;
                Provider<ApplicationFunction>.Save(communityItem);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.GetCombinedMessages());
            }
        }




        /// <summary>
        /// Gets the root folder.
        /// </summary>
        /// <value>The root folder.</value>
        public ApplicationFunction RootFolder 
        {
            get 
            { 
                return new ApplicationFunction() {Id=ApplicationFunctionConst.RootId, ParentId = SysConst.NullGuid};
            }
        }

        /// <summary>
        /// Gets the un registered folder.
        /// </summary>
        /// <value>The un registered folder.</value>
        public ApplicationFunction UnRegisteredFolder 
        {
            get 
            {
                return new ApplicationFunction() { Id = ApplicationFunctionConst.UnregisteredId, ParentId = ApplicationFunctionConst.RootId, Title = "Unregistered Applications" };
            }
        }
        /// <summary>
        /// Gets the community folder.
        /// </summary>
        /// <value>The community folder.</value>
        public ApplicationFunction CommunityFolder 
        {
            get
            {
                return new ApplicationFunction() { Id = ApplicationFunctionConst.CommunityFolderId, ParentId = ApplicationFunctionConst.RootId, Title = "Community Applications" };
            }
        }

        /// <summary>
        /// Gets the applet information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ApplicationFunction.</returns>
        public ApplicationFunction GetAppletInfo(string id)
        {
            return Provider<ApplicationFunction>.GetById(id);
        }

        /// <summary>
        /// Gets all application functions.
        /// </summary>
        /// <returns>ApplicationFunctionItem[][].</returns>
        public ApplicationFunction[] GetAllApplicationFunctions()
        {
            return Provider<ApplicationFunction>.GetAll();
        }

        /// <summary>
        /// Saves the application functions.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>ApplicationFunction[][].</returns>
        public ApplicationFunction[] SaveApplicationFunctions(ApplicationFunction[] items)
        {
            return Provider<ApplicationFunction>.Save(items);
        }


        /// <summary>
        /// Deletes the application functions.
        /// </summary>
        /// <param name="applicationFunctionsWorker">The application functions.</param>
        /// <returns>ApplicationFunction[][].</returns>
        public ApplicationFunction[] DeleteApplicationFunctions(ApplicationFunction[] applicationFunctionsWorker)
        {
            return Provider<ApplicationFunction>.Delete(applicationFunctionsWorker);
        }




        /// <summary>
        /// Gets the menu for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        public ApplicationFunction[] GetMenuForUser(string userName)
        {
            return new ApplicationFunction[] {};
        }

        #endregion
    }
}
