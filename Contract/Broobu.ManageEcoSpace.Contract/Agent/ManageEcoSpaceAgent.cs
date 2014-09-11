// ***********************************************************************
// Assembly         : Broobu.ManageAuthorization.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-18-2014
// ***********************************************************************
// <copyright file="ManageEcoSpaceAgent.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.ManageEcoSpace.Contract.Interfaces;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;
using NLog;

namespace Broobu.ManageEcoSpace.Contract.Agent
{
    /// <summary>
    /// Class ManageAuthorizationAgent.
    /// </summary>
	partial class ManageEcoSpaceAgent: DiscoProxy<IManageEcoSpace>, IManageEcoSpaceAgent
	{

        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
		protected override string GetContractNamespace()		{
			return ManageEcoSpaceServiceConst.Namespace;
		}


        /// <summary>
        /// Gets the known eco spaces.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>IEnumerable&lt;IEcoSpaceMembership&gt;.</returns>
	    public IEnumerable<IEcoSpaceMembership> GetKnownEcoSpaces(string accountId)
	    {
            var clt = CreateClient();
	        try
	        {
                return clt
                    .GetKnownEcoSpaces(accountId)
                    .Unzip<EcoSpaceMembership>();
	        }
	        catch (Exception ex)
	        {
                Logger.Error(ex.GetCombinedMessages());
                return null;
	        }
            finally
            {
                CloseClient(clt);
            }
	    }


        /// <summary>
        /// The logger
        /// </summary>
        

        /// <summary>
        /// Registers the account for eco space.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>IEcoSpaceMembership.</returns>
	    public IEcoSpaceMembership RegisterAccountForEcoSpace(string accountId, string ecoSpaceId)
	    {
            var clt = CreateClient();
            try
            {
                return clt
                    .RegisterAccountForEcoSpace(accountId,ecoSpaceId)
                    .Unzip<EcoSpaceMembership>();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                return null;
            }
            finally
            {
                CloseClient(clt);
            }
	    }

        /// <summary>
        /// Gets the known eco spaces asynchronous.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="act">The act.</param>
	    public void GetKnownEcoSpacesAsync(string accountId, Action<IEnumerable<IEcoSpaceMembership>> act = null)
	    {
            using (var wrk = new System.ComponentModel.BackgroundWorker())
            {
                var res = (IEnumerable<IEcoSpaceMembership>)null;
                wrk.DoWork += (s, e) =>
                {
                    res = GetKnownEcoSpaces(accountId);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(res);
                    wrk.Dispose();
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
        /// <exception cref="System.NotImplementedException"></exception>
        public void RegisterAccountForEcoSpaceAsync(string accountId, string ecoSpaceId, Action<IEcoSpaceMembership> act = null)
	    {
            using (var wrk = new System.ComponentModel.BackgroundWorker())
            {
                var res = (IEcoSpaceMembership)null;
                wrk.DoWork += (s, e) =>
                {
                    res = RegisterAccountForEcoSpace(accountId, ecoSpaceId);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(res);
                    wrk.Dispose();
                };
                wrk.RunWorkerAsync();
            }
	    }
	}
}