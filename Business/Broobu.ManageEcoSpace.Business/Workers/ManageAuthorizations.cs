// ***********************************************************************
// Assembly         : Iris.ManageAuthorization.Business
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="ManageAuthorizationProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Authorization.Contract;
using Broobu.ManageAuthorization.Business.Interfaces;
using Broobu.ManageAuthorization.Business.Mappers;
using Broobu.ManageAuthorization.Contract.Domain;
using Broobu.Taxonomy.Contract;
using Iris.Fx.Domain;

namespace Broobu.ManageAuthorization.Business.Workers
{
    /// <summary>
    /// Class ManageAuthorizationProvider.
    /// </summary>
    internal class ManageAuthorizations : IManageAuthorizations
    {
        /// <summary>
        /// Gets all application functions.
        /// </summary>
        /// <returns>ApplicationFunctionViewItem[][].</returns>
        public ApplicationFunctionInfo[] GetAllApplicationFunctions()
        {
            return AuthorizationPortal
                .ApplicationFunctions
                .GetAllApplicationFunctions()
                .ToApplicationFunctionViewItem();
        }

        /// <summary>
        /// Saves the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionViewItem[][].</returns>
        public ApplicationFunctionInfo[] SaveApplicationFunctions(ApplicationFunctionInfo[] applicationFunctionViewItems)
        {
            return AuthorizationPortal
                .ApplicationFunctions
                .SaveApplicationFunctions(applicationFunctionViewItems.ToApplicationFunctionItem())
                .ToApplicationFunctionViewItem();
        }

        /// <summary>
        /// Deletes the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionViewItem[][].</returns>
        public ApplicationFunctionInfo[] DeleteApplicationFunctions(ApplicationFunctionInfo[] applicationFunctionViewItems)
        {
            return AuthorizationPortal
                .ApplicationFunctions
                .DeleteApplicationFunctions(applicationFunctionViewItems.ToApplicationFunctionItem())
                .ToApplicationFunctionViewItem();
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>RoleViewItem[][].</returns>
        public RoleInfo[] GetAllRoles()
        {
            return AuthorizationPortal
                .Roles
                .GetAllRoles()
                .ToRoleViewItem();
        }

        /// <summary>
        /// Saves the roles.
        /// </summary>
        /// <param name="roleInfos">The role view items.</param>
        /// <returns>RoleViewItem[][].</returns>
        public RoleInfo[] SaveRoles(RoleInfo[] roleInfos)
        {
            return AuthorizationPortal
                .Roles
                .SaveRoles(roleInfos.ToRoleItem())
                .ToRoleViewItem();
        }

        /// <summary>
        /// Deletes the roles.
        /// </summary>
        /// <param name="roleInfos">The role view items.</param>
        /// <returns>RoleViewItem[][].</returns>
        public RoleInfo[] DeleteRoles(RoleInfo[] roleInfos)
        {
            return AuthorizationPortal
                .Roles
                .DeleteRoles(roleInfos.ToRoleItem())
                .ToRoleViewItem();
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>AccountViewItem[][].</returns>
        public AccountInfo[] GetAllAccounts()
        {
            return  AuthorizationPortal
                .Accounts
                .GetAllAccounts()
                .ToAccountViewItem();
        }


        /// <summary>
        /// Gets the accounts for role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns>AccountViewItem[][].</returns>
        public AccountInfo[] GetAccountsForRole(string roleId)
        {
            return AuthorizationPortal
                .Accounts
                .GetAccountsForRole(roleId)
                .ToAccountViewItem();
        }

        /// <summary>
        /// Saves the accounts for role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountViewItem[][].</returns>
        public Result[] LinkAccountsToRole(string roleId, AccountInfo[] accounts)
        {
            return AuthorizationPortal
                .Accounts
                .LinkAccountsToRole(roleId, accounts.ToAccountItem());
        }

        /// <summary>
        /// Deletes the accounts for role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountViewItem[][].</returns>
        public Result[] UnlinkAccountsFromRole(string roleId, AccountInfo[] accounts)
        {
            return AuthorizationPortal
                .Accounts
                .UnlinkAccountsFromRole(roleId, accounts.ToAccountItem());
        }

        /// <summary>
        /// Gets the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function id.</param>
        /// <returns>RoleViewItem[][].</returns>
        public RoleInfo[] GetRolesForApplicationFunction(string applicationFunctionId)
        {
            return AuthorizationPortal
                .Roles
                .GetRolesForApplicationFunction(applicationFunctionId)
                .ToRoleViewItem();
        }

        /// <summary>
        /// Saves the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function id.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleViewItem[][].</returns>
        public Result[] LinkRolesToApplicationFunction(string applicationFunctionId, RoleInfo[] roles)
        {
            return AuthorizationPortal
                .Roles
                .LinkRolesToApplicationFunction(applicationFunctionId, roles.ToRoleItem());
        }

        /// <summary>
        /// Deletes the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function id.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleViewItem[][].</returns>
        public Result[] UnlinkRolesFromApplicationFunction(string applicationFunctionId, RoleInfo[] roles)
        {
            return AuthorizationPortal
                .Roles
                .UnlinkRolesFromApplicationFunction(applicationFunctionId, roles.ToRoleItem());
        }

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
            TaxonomyPortal
                .Hooks
                .SaveEnumerations(ManageAuthorizationDomainGenerator
                .CreateRibbonTypeEnumeration());
        }


        /// <summary>
        /// Gets the ribbon types.
        /// </summary>
        /// <returns>System.String[][].</returns>
        public string[] GetRibbonTypes()
        {
            //var items = TaxonomyPortal
            //    .Enumerations
            //    .GetEnumerationsForType(ManageAuthorizationDomainGenerator.RibbonType.Type);
            //return (from EnumerationProperty enumerationPropertyItem in items 
            //        select enumerationPropertyItem.Value)
            //        .ToArray();
            return new string[] {};
        }
    }
}
