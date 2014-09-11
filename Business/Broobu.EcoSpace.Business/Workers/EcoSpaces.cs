// ***********************************************************************
// Assembly         : Broobu.Authorization.Business
// Author           : Rafael Lefever
// Created          : 08-11-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="EcoSpaces.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Broobu.Authentication.Contract;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Business.Interfaces;
using Broobu.EcoSpace.Contract;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Default;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Exceptions;
using Wulka.Extensions;
using NLog;

namespace Broobu.EcoSpace.Business.Workers
{
    /// <summary>
    /// Class EcoSpaces.
    /// </summary>
    class EcoSpaces : IEcoSpaces
    {
        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Inflates this instance.
        /// </summary>
        public void Inflate()
        {
            var de = Provider<EcoSpaceDocument>.GetById(MasterEcoSpace.ID);
            if(de==null)
                Provider<EcoSpaceDocument>.Save(EcoSpaceFactory.MasterEcoSpace);
        }

        /// <summary>
        /// Gets the menu for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userCulture">The user culture.</param>
        /// <returns>MenuContainer.</returns>
        public MenuContainer GetMenuForUser(string userName, string userCulture)
        {
            var de = Provider<EcoSpaceDocument>.GetById(MasterEcoSpace.ID);
            return de.GetMenuForUser(userName, userCulture);
        }

        /// <summary>
        /// Gets the applets for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>AppletContainer.</returns>
        public AppletContainer GetAppletsForUser(string userName)
        {
            var de = Provider<EcoSpaceDocument>.GetById(MasterEcoSpace.ID);
            return de.Applets;
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>UserEnvironmentInfo.</returns>
        public UserEnvironmentInfo GetUserInfo(string userId, string fullName, string ecoSpaceId=null)
        {
            if (String.IsNullOrWhiteSpace(ecoSpaceId))
                ecoSpaceId = MasterEcoSpace.ID;
            var ed = Provider<EcoSpaceDocument>.GetById(ecoSpaceId);
            return new UserEnvironmentInfo()
             {
                 Menu = ed.GetMenuForUser(userId),
                 Applets = ed.Applets,
                 Greeting = fullName,
                 UserId = userId
             };
        }



        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EcoSpaceDocument.</returns>
        public EcoSpaceDocument GetEcoSpace(string id)
        {
            return Provider<EcoSpaceDocument>.GetById(id);
        }

        /// <summary>
        /// Saves the eco space.
        /// </summary>
        /// <param name="ecoSpaceDocument">The eco space document.</param>
        /// <returns>EcoSpaceDocument.</returns>
        public EcoSpaceDocument SaveEcoSpace(EcoSpaceDocument ecoSpaceDocument)
        {
            return Provider<EcoSpaceDocument>.Save(ecoSpaceDocument);
        }


        /// <summary>
        /// Gets the eco space memberships.
        /// </summary>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEnumerable&lt;IEcoSpaceMembership&gt;.</returns>
        public IEnumerable<IEcoSpaceMembership> GetEcoSpaceMemberships(string ecoSpaceId = null)
        {
            if (String.IsNullOrWhiteSpace(ecoSpaceId))
                ecoSpaceId = MasterEcoSpace.ID;
            var req = new RequestBase
            {
                Function = String.Format("if(doc.TargetId=='{0}' && " +
                                         "doc.RelationType=='{1}') emit(doc.Id,doc)", ecoSpaceId, EcoSpaceMembership.Relation)
            };
            return Provider<EcoSpaceMembership>.Query(req);
        }

        /// <summary>
        /// Gets the role memberships.
        /// </summary>
        /// <param name="accountId">The user identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>MembershipContainer.</returns>
        public MembershipContainer GetRoleMemberships(string accountId, string ecoSpaceId = null)
        {
            if (String.IsNullOrWhiteSpace(ecoSpaceId))
                ecoSpaceId = MasterEcoSpace.ID;
            var res = new MembershipContainer();
            try
            {
                var req = new RequestBase()
                {
                    Function = String.Format("if( doc.TargetId=='{0}' " +
                                             "&& doc.RelationType=='{1}' " +
                                             "&& doc.EcoSpaceId=='{2}' ) emit(doc.Id,doc)",
                                             accountId,
                                             RoleMembership.Relation,
                                             ecoSpaceId)
                };
                var links = Provider<RoleMembership>.Query(req);
                foreach (var roleMembership in links)
                {
                    res.AddPart(roleMembership);
                }
            }
            catch (Exception ex)
            {

                _logger.Error(ex.GetCombinedMessages());
                res.AddError(ex.GetCombinedMessages());
            }
            return res;
        }

        /// <summary>
        /// Gets the known eco spaces.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>IEnumerable&lt;IEcoSpaceMembership&gt;.</returns>
        public IEnumerable<IEcoSpaceMembership> GetKnownEcoSpaces(string accountId)
        {
            var req = new RequestBase 
            { 
                Function = String.Format("if(doc.SourceId=='{0}' && " +
                                         "doc.RelationType=='{1}') emit(doc.Id,doc)", accountId, EcoSpaceMembership.Relation) 
            };
            return Provider<EcoSpaceMembership>.Query(req);
        }

        /// <summary>
        /// Gets the role memberships.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEnumerable&lt;IRoleMembership&gt;.</returns>
        public IEnumerable<IRoleMembership> GetRoleMemberships(IRole role, string ecoSpaceId = null)
        {
            if (String.IsNullOrWhiteSpace(ecoSpaceId))
                ecoSpaceId = role.EcoSpaceId;
            if (String.IsNullOrWhiteSpace(ecoSpaceId))
                ecoSpaceId = MasterEcoSpace.ID;
            var req = new RequestBase { 
                Function = String.Format("if(doc.SourceId=='{0}' " +
                                         "&& doc.EcoSpaceId=='{1}' " +
                                         "&& doc.RelationType=='{2}') " +
                                         "emit(doc.Id,doc)",
                                         role.Id, 
                                         ecoSpaceId, 
                                         RoleMembership.Relation)
            };
            var res = Provider<RoleMembership>.Query(req);
            if (!res.Any()) return null;
            return res.ToArray();
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>IDomainObject.</returns>
        private IDomainObject GetAccount(string accountId)
        {
            return AuthenticationPortal
                .Accounts
                .GetAccountById(accountId);
        }


        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IRole.</returns>
        private IRole GetRole(string roleId, string ecoSpaceId)
        {
            var ed = Provider<EcoSpaceDocument>.GetById(ecoSpaceId);
            return ed == null 
                ? null 
                : ed.Roles.Find<IRole>(roleId);
        }

        /// <summary>
        /// Gets the membership.
        /// </summary>
        /// <param name="membershipId">The membership identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEcoSpaceMembership.</returns>
        private IEcoSpaceMembership GetMembership(string membershipId, string ecoSpaceId)
        {
            return GetEcoSpaceMemberShip(membershipId, ecoSpaceId);
        }

        /// <summary>
        /// Gets the eco space member ship.
        /// </summary>
        /// <param name="membershipId">The membership identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEcoSpaceMembership.</returns>
        private IEcoSpaceMembership GetEcoSpaceMemberShip(string membershipId, string ecoSpaceId)
        {
            var req = new RequestBase {
                Function = String.Format("if(doc.Id='{0}' " +
                                         "&& doc.EcoSpaceId='{1}') " +
                                         "emit(doc.Id,doc)", membershipId, ecoSpaceId)
            };
            return Provider<EcoSpaceMembership>.Query(req).FirstOrDefault();
        }

        /// <summary>
        /// Registers the role membership.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>IRoleMembership.</returns>
        public IRoleMembership RegisterRoleMembership(IRole role, string accountId)
        {
            var m = FindRoleMembership(role, accountId) 
                ?? new RoleMembership() 
                {
                    SourceId = role.Id, 
                    TargetId = accountId,
                    Source = GetRole(role.Id, role.EcoSpaceId),
                    Target =GetAccount(accountId)
                };
            m.IsActive = true;
            var s = m.Zip();
            RegisterAccountForEcoSpace(accountId, role.EcoSpaceId);
            return Provider<RoleMembership>.Save(s.Unzip<RoleMembership>());
        }

        /// <summary>
        /// Finds the role membership.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>IRoleMembership.</returns>
        private IRoleMembership FindRoleMembership(IRole role, string accountId)
        {
            var req = new RequestBase
            {
                Function = String.Format("if(doc.TargetId=='{0}' " +
                                         "&& doc.SourceId=='{1}' " +
                                         "&& doc.EcoSpaceId=='{2}' " +
                                         "&& doc.RelationType=='{3}') " +
                                         "emit(doc.Id,doc)",
                                         accountId,
                                         role.Id,
                                         role.EcoSpaceId,
                                         RoleMembership.Relation)
            };
            return Provider<RoleMembership>.Query(req).FirstOrDefault();
        }


        /// <summary>
        /// Registers the account for eco space.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEcoSpaceMembership.</returns>
        public IEcoSpaceMembership RegisterAccountForEcoSpace(string accountId, string ecoSpaceId)
        {
            if (String.IsNullOrWhiteSpace(ecoSpaceId))
                ecoSpaceId = MasterEcoSpace.ID;
            var req = new RequestBase
            {
                Function = String.Format("if(doc.SourceId=='{0}' && " +
                                         "doc.TargetId=='{1}'" +
                                         "doc.RelationType=='{2}') emit(doc.Id,doc)", accountId, ecoSpaceId, EcoSpaceMembership.Relation)
            };
            var acc = AuthenticationPortal
                .Accounts
                .GetAccountById(accountId);
            var res = Provider<EcoSpaceMembership>.Query(req).FirstOrDefault() 
                ?? new EcoSpaceMembership() 
                { 
                    SourceId=accountId,
                    TargetId=ecoSpaceId
                };
            res.IsActive = true;
            return Provider<EcoSpaceMembership>.Save(res);
        }


       





    }
}