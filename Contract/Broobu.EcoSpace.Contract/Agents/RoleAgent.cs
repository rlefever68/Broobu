// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 05-25-2014
// ***********************************************************************
// <copyright file="RoleAgent.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.EcoSpace.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.EcoSpace.Contract.Agents
{
    /// <summary>
    ///     Class RoleAgent.
    /// </summary>
    internal class RoleAgent : DiscoProxy<IRoleSentry>, IRoleAgent
    {
        public RoleAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        ///     Gets all roles.
        /// </summary>
        /// <returns>RoleItem[][].</returns>
        public Role[] GetAllRoles()
        {
            IRoleSentry clt = CreateClient();
            try
            {
                return clt.GetAllRoles();
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Saves the roles.
        /// </summary>
        /// <param name="roleViewItems">The role view items.</param>
        /// <returns>RoleItem[][].</returns>
        public Role[] SaveRoles(Role[] roleViewItems)
        {
            IRoleSentry clt = CreateClient();
            try
            {
                return clt.SaveRoles(roleViewItems);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Deletes the roles.
        /// </summary>
        /// <param name="roleViewItems">The role view items.</param>
        /// <returns>Domain.RoleItem[][].</returns>
        public Role[] DeleteRoles(Role[] roleViewItems)
        {
            IRoleSentry clt = CreateClient();
            try
            {
                return clt.DeleteRoles(roleViewItems);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Gets the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function identifier.</param>
        /// <returns>RoleItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Role[] GetRolesForApplicationFunction(string applicationFunctionId)
        {
            IRoleSentry clt = CreateClient();
            try
            {
                return clt.GetRolesForApplicationFunction(applicationFunctionId);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        ///     Registers the private cloud.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Role.</returns>
        public Role RegisterPrivateCloud(Role role)
        {
            IRoleSentry clt = CreateClient();
            try
            {
                return clt.RegisterPrivateCloud(role);
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
    }
}