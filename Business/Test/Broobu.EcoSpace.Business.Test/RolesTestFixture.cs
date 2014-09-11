// ***********************************************************************
// Assembly         : Broobu.Authorization.Business.Test
// Author           : Rafael Lefever
// Created          : 05-04-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-25-2014
// ***********************************************************************
// <copyright file="RolesTestFixture.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.Authorization.Business.Interfaces;
using Broobu.Authorization.Contract.Domain;
using Broobu.Taxonomy.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authorization.Business.Test
{
    /// <summary>
    /// Summary description for RoleAgentTestFixture
    /// </summary>
    [TestClass]
    public class RolesTestFixture : IRoles
    {




        [TestMethod]
        public void Try_RegisterBroobuCloud()
        {
            var role = new Role()
            {
                DisplayName = "Broobu Cloud"
            };
            role = RegisterPrivateCloud(role);
            Console.WriteLine(role.ToString());
            var hook = TaxonomyProvider
                .Hooks
                .GetById(role.Id);
            Console.WriteLine(hook.ToString());
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RolesTestFixture"/> class.
        /// </summary>
        public RolesTestFixture()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>RoleItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Role[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Role[] SaveRoles(Role[] roles)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the roles.
        /// </summary>
        /// <param name="roleViewItem">The role view item.</param>
        /// <returns>RoleItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Role[] DeleteRoles(Role[] roleViewItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function identifier.</param>
        /// <returns>RoleItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Role[] GetRolesForApplicationFunction(string applicationFunctionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleXApplicationFunction[] LinkRolesToApplicationFunction(string applicationFunctionId, Role[] roles)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the roles for application function.
        /// </summary>
        /// <param name="apllicationFunctionId">The apllication function identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleXApplicationFunction[] UnlinkRolesFromApplicationFunction(string apllicationFunctionId, Role[] roles)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers the private cloud.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Role.</returns>
        public Role RegisterPrivateCloud(Role role)
        {
            return AuthorizationProvider
                .Roles
                .RegisterPrivateCloud(role);
        }

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RegisterRequiredDomainObjects()
        {
            throw new NotImplementedException();
        }
    }
}
