// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="IRole.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.EcoSpace.Contract.Interfaces
{
    /// <summary>
    ///     Interface IRole
    /// </summary>
    [ServiceKnownType(typeof (Result))]
    [ServiceKnownType(typeof (Role))]
    [ServiceContract(Namespace = AuthorizationServiceConst.Namespace)]
    public interface IRoleSentry
    {
        /// <summary>
        ///     Gets all roles.
        /// </summary>
        /// <returns>RoleItem[][].</returns>
        [OperationContract]
        Role[] GetAllRoles();

        /// <summary>
        ///     Saves the roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleItem[][].</returns>
        [OperationContract]
        Role[] SaveRoles(Role[] roles);

        /// <summary>
        ///     Deletes the roles.
        /// </summary>
        /// <param name="roleViewItem">The role view item.</param>
        /// <returns>RoleItem[][].</returns>
        [OperationContract]
        Role[] DeleteRoles(Role[] roleViewItem);

        /// <summary>
        ///     Gets the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function identifier.</param>
        /// <returns>RoleItem[][].</returns>
        [OperationContract]
        Role[] GetRolesForApplicationFunction(string applicationFunctionId);

       
        /// <summary>
        ///     Registers the private cloud.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Role.</returns>
        [OperationContract]
        Role RegisterPrivateCloud(Role role);
    }
}