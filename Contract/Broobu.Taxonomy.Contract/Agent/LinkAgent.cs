// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="LinkAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;
using ILink = Wulka.Domain.Interfaces.ILink;

namespace Broobu.Taxonomy.Contract.Agent
{
    /// <summary>
    /// Class RelationAgent.
    /// </summary>
    internal class LinkAgent : DiscoProxy<ILinkSentry>, ILinkAgent
    {
        public LinkAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return TaxonomyConst.Namespace;
        }


        /// <summary>
        /// Activates the specified link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>ILink.</returns>
        public ILink Activate(ILink link)
        {
            var clt = CreateClient();
            try
            {
                return clt.Activate(link.Zip()).Unzip<Link>();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                link.AddError(ex.GetCombinedMessages());
                return link;
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Deactivates the specified link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>ILink.</returns>
        public ILink Deactivate(ILink link)
        {
            var clt = CreateClient();
            try
            {
                return clt.Deactivate(link.Zip()).Unzip<Link>();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                link.AddError(ex.GetCombinedMessages());
                return link;
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the targets.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <returns>IEnumerable&lt;ILink&gt;.</returns>
        public IEnumerable<ILink> GetTargets(ILink link, bool activeOnly = true)
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .GetTargets(link.Zip(),activeOnly)
                    .Unzip<Link>();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                link.AddError(ex.GetCombinedMessages());
                return new[] {link};
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the sources.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <returns>IEnumerable&lt;ILink&gt;.</returns>
        public IEnumerable<ILink> GetSources(ILink link, bool activeOnly = true)
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .GetSources(link.Zip(), activeOnly)
                    .Unzip<Link>();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                link.AddError(ex.GetCombinedMessages());
                return new[] { link };
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Activates the asynchronous.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="act">The act.</param>
        public void ActivateAsync(ILink link, Action<ILink> act = null)
        {
            ILink res = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = Activate(link);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());

                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(res);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Deactivates the asynchronous.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="act">The act.</param>
        public void DeactivateAsync(ILink link, Action<ILink> act = null)
        {
            ILink res = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = Deactivate(link);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());

                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(res);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the targets asynchronous.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <param name="act">The act.</param>
        public void GetTargetsAsync(ILink link, bool activeOnly = true, Action<IEnumerable<ILink>> act = null)
        {
            IEnumerable<ILink> res = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = GetTargets(link,activeOnly);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());

                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(res);
                };
                wrk.RunWorkerAsync();
            }

        }

        

        /// <summary>
        /// Gets the sources asycn.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <param name="act">The act.</param>
        public void GetSourcesAsync(ILink link, bool activeOnly = true, Action<IEnumerable<ILink>> act = null)
        {
            IEnumerable<ILink> res = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = GetTargets(link, activeOnly);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());

                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(res);
                };
                wrk.RunWorkerAsync();
            }
        }
    }
}
