// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 08-11-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="EcoSpaceAgent.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Default;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.EcoSpace.Contract.Interfaces;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;
using NLog;


namespace Broobu.EcoSpace.Contract.Agents
{
    /// <summary>
    /// Class EcoSpaceAgent.
    /// </summary>
    class EcoSpaceAgent : DiscoProxy<IEcoSpaceSentry>, IEcoSpaceAgent
    {

        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public EcoSpaceAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        /// Gets the menu for user.
        /// </summary>
        /// <returns>MenuContainer.</returns>
        public MenuContainer GetMenuForUser()
        {
            var res = new MenuContainer();
            try
            {
                res = Client
                    .GetMenuForUser()
                    .Unzip<MenuContainer>();

            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
            }
            return res;
        }

        /// <summary>
        /// Gets the applets for user.
        /// </summary>
        /// <returns>AppletContainer.</returns>
        public AppletContainer GetAppletsForUser()
        {
            var res = new AppletContainer();
            try
            {
                res = Client
                    .GetAppletsForUser()
                    .Unzip<AppletContainer>();

            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
            }
            return res;
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="fullName">The full name.</param>
        /// <returns>UserEnvironmentInfo.</returns>
        public UserEnvironmentInfo GetUserInfo(string userId, string fullName)
        {
            var res = new UserEnvironmentInfo();
            var clt = CreateClient();
            try
            {
                res = clt
                    .GetUserInfo(userId,fullName)
                    .Unzip<UserEnvironmentInfo>();

            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(clt);
            }
            return res;
        }

        /// <summary>
        /// Gets the eco space.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EcoSpaceDocument.</returns>
        public EcoSpaceDocument GetEcoSpace(string id)
        {
            var res = new EcoSpaceDocument();
            try
            {
                res = Client
                    .GetEcoSpace(id)
                    .Unzip<EcoSpaceDocument>();

            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
            }
            return res;
        }

        /// <summary>
        /// Saves the eco space.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <returns>EcoSpaceDocument.</returns>
        public EcoSpaceDocument SaveEcoSpace(EcoSpaceDocument doc)
        {
            var res = new EcoSpaceDocument();
            try
            {
                res = Client
                    .SaveEcoSpace(doc.Zip())
                    .Unzip<EcoSpaceDocument>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
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
            var res = (IEnumerable<IEcoSpaceMembership>)null;
            try
            {
                res = Client
                    .GetKnownEcoSpaces(accountId)
                    .Unzip<EcoSpaceMembership>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
            }
            return res;
        }

        /// <summary>
        /// Registers the account for eco space.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEcoSpaceMembership.</returns>
        public IEcoSpaceMembership RegisterAccountForEcoSpace(string accountId, string ecoSpaceId=null)
        {
            if (String.IsNullOrEmpty(ecoSpaceId))
                ecoSpaceId = MasterEcoSpace.ID;
            var res = (IEcoSpaceMembership)null;
            try
            {
                res = Client
                    .RegisterAccountForEcoSpace(accountId, ecoSpaceId)
                    .Unzip<EcoSpaceMembership>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
            }
            return res;
        }

        public IEnumerable<IRoleMembership> GetRoleMemberships(IRole role)
        {
            var res = (IEnumerable<IRoleMembership>)null;
            try
            {
                res = Client
                    .GetRoleMembershipsForRole(role.Zip())
                    .Unzip<RoleMembership>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
            }
            return res;
            
        }

        public IRoleMembership RegisterRoleMembership(IRole role, string accountId)
        {
            var res = (IRoleMembership)null;
            try
            {
                res = Client
                    .RegisterRoleMembership(role.Zip(),accountId)
                    .Unzip<RoleMembership>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(Client);
            }
            return res;
           
        }

        /// <summary>
        /// Gets the account pointers.
        /// </summary>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEnumerable&lt;IAccountPointer&gt;.</returns>
        public IEnumerable<IEcoSpaceMembership> GetEcoSpaceMemberships(string ecoSpaceId = null)
        {
            var res = new List<IEcoSpaceMembership>();
            var clt = CreateClient();
            try
            {
                return clt
                    .GetEcoSpaceMemberships(ecoSpaceId)
                    .Unzip<EcoSpaceMembership>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(clt);
            }
            return res;
        }

        /// <summary>
        /// Gets the account pointers asynchronous.
        /// </summary>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <param name="act">The act.</param>
        public void GetEcoSpaceMembershipsAsync(string ecoSpaceId = null, Action<IEnumerable<IEcoSpaceMembership>> act = null)
        {
            IEnumerable<IEcoSpaceMembership> result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = GetEcoSpaceMemberships(ecoSpaceId); };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the known eco spaces asynchronous.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="act">The act.</param>
        public void GetKnownEcoSpacesAsync(string accountId, Action<IEnumerable<IEcoSpaceMembership>> act = null)
        {
            var result = (IEnumerable<IEcoSpaceMembership>)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = GetKnownEcoSpaces(accountId); };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Registers the account for eco space asynchronous.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <param name="act">The act.</param>
        public void RegisterAccountForEcoSpaceAsync(string accountId, string ecoSpaceId, Action<IEcoSpaceMembership> act = null)
        {
            var result = (IEcoSpaceMembership)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = RegisterAccountForEcoSpace(accountId, ecoSpaceId); };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            }
        }

        public void GetRoleMembershipsAsync(IRole role, Action<IEnumerable<IRoleMembership>> act=null)
        {
            var result = (IEnumerable<IRoleMembership>)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = this.GetRoleMemberships(role); };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            }
           
        }

        public void RegisterRoleMembershipAsync(IRole role, string accountId, Action<IRoleMembership> act = null)
        {
            var result = (IRoleMembership)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = RegisterRoleMembership(role, accountId); };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            }
            
        }

        /// <summary>
        /// Gets the eco space asynchronous.
        /// </summary>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <param name="act">The act.</param>
        public void GetEcoSpaceAsync(string ecoSpaceId, Action<IEcoSpaceDocument> act = null)
        {
            var result = (IEcoSpaceDocument)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) => { result = GetEcoSpace(ecoSpaceId); };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            }
           
        }


        /// <summary>
        /// Gets the role memberships.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>RoleContainer.</returns>
        public RoleContainer GetRoleMemberships(string userId)
        {
            var res = new RoleContainer();
            var clt = CreateClient();
            try
            {
                return clt
                    .GetRoleMembershipsForAccountId(userId)
                    .Unzip<RoleContainer>();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                res.AddError(ex.GetCombinedMessages());
            }
            finally
            {
                CloseClient(clt);
            }
            return res;
        }






        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return EcoSpaceConst.Namespace;
        }
    }
}