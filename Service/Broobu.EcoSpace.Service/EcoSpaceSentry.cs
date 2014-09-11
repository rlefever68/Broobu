// ***********************************************************************
// Assembly         : Broobu.Authorization.Service
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="AuthorizationService.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using Broobu.EcoSpace.Business;
using Broobu.EcoSpace.Contract;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Default;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.EcoSpace.Contract.Interfaces;
using Wulka.Extensions;
using Wulka.Networking.Wcf;

namespace Broobu.EcoSpace.Service
{

    /// <summary>
    /// Class AuthorizationService.
    /// </summary>
    public class EcoSpaceSentry : SentryBase, IEcoSpaceSentry
    {
        /// <summary>
        /// You MUST override this method, but you cannot use
        /// Initializing code in the constructor that references itself (since the object is not yet created) - Obsolete remark
        /// REMARK: since the code has been moved to the onOpen method of the servicehost; you can be certain now that
        /// the object has been created.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            EcoSpaceProvider
                .EcoSpaces
                .Inflate();
        }

        /// <summary>
        /// Gets the menu for user.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetMenuForUser()
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetMenuForUser(UserName, UserCulture)
                .Zip();
        }

        /// <summary>
        /// Gets the applets for user.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetAppletsForUser()
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetAppletsForUser(UserName)
                .Zip();
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="fullName">The full name.</param>
        /// <returns>System.String.</returns>
        public string GetUserInfo(string userId, string fullName)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetUserInfo(userId, fullName, MasterEcoSpace.ID)
                .Zip();
        }

        /// <summary>
        /// Gets the eco space.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        public string GetEcoSpace(string id)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetEcoSpace(id)
                .Zip();
        }

        /// <summary>
        /// Saves the eco space.
        /// </summary>
        /// <param name="ecoSpace">The eco space.</param>
        /// <returns>System.String.</returns>
        public string SaveEcoSpace(string ecoSpace)
        {
            var eo = ecoSpace.Unzip<EcoSpaceDocument>();
            return EcoSpaceProvider
                .EcoSpaces
                .SaveEcoSpace(eo)
                .Zip();
        }

        /// <summary>
        

        /// <summary>
        /// Gets the account pointers.
        /// </summary>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>System.String[].</returns>
        public string[] GetEcoSpaceMemberships(string ecoSpaceId = null)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetEcoSpaceMemberships(ecoSpaceId: ecoSpaceId)
                .Zip()
                .ToArray();
        }

        /// <summary>
        /// Gets the role memberships.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>System.String.</returns>
        public string GetRoleMembershipsForAccountId(string userId)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetRoleMemberships(userId)
                .Zip();
        }

        /// <summary>
        /// Gets the known eco spaces.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>System.String[].</returns>
        public string[] GetKnownEcoSpaces(string accountId)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetKnownEcoSpaces(accountId)
                .Zip()
                .ToArray();
        }

        /// <summary>
        /// Registers the account for eco space.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>System.String.</returns>
        public string RegisterAccountForEcoSpace(string accountId, string ecoSpaceId)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .RegisterAccountForEcoSpace(accountId, ecoSpaceId)
                .Zip();
        }

        public string[] GetRoleMembershipsForRole(string role, string ecoSpaceId=null)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetRoleMemberships(role.Unzip<Role>())
                .Zip()
                .ToArray();
        }

        public string GetRoleMembershipsForAccountId(string accountId, string ecoSpaceId = null)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .GetRoleMemberships(accountId, ecoSpaceId)
                .Zip();
                
           
        }

        public string RegisterRoleMembership(string role, string accountId)
        {
            return EcoSpaceProvider
                .EcoSpaces
                .RegisterRoleMembership(role.Unzip<Role>(), accountId)
                .Zip();
        }
    }
}
