// ***********************************************************************
// Assembly         : Broobu.LATI.Contract
// Author           : Rafael Lefever
// Created          : 01-14-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-14-2014
// ***********************************************************************
// <copyright file="CultureAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Broobu.LATI.Contract.Domain;
using Broobu.LATI.Contract.Interfaces;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;


namespace Broobu.LATI.Contract.Agent
{
    /// <summary>
    /// Class CultureAgent.
    /// </summary>
    class CultureAgent : DiscoProxy<ICultureSentry>, ICultureAgent
    {
        public CultureAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Culture.</returns>
        public ICultureDocument GetById(string id)
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .GetById(id)
                    .Unzip<CultureDocument>();
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the culture document asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="act">The act.</param>
        public void GetCultureDocumentAsync(string id, Action<ICultureDocument> act = null)
        {
            var res = (ICultureDocument)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    try
                    {
                        res = GetById(id);
                    }
                    catch (Exception ex)
                    {
                        if (wrk != null)
                            wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());
                        throw ex;
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
        /// Gets the regions asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="act">The act.</param>
        public void GetRegionsAsync(string id, Action<IEnumerable<IRegion>> act = null)
        {
            var res = (IEnumerable<IRegion>)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    try
                    {
                        res = GetRegions(id);
                    }
                    catch (Exception ex)
                    {
                        if (wrk != null)
                            wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());
                        throw ex;
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
        /// Gets the regions.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IEnumerable&lt;IRegion&gt;.</returns>
        private IEnumerable<IRegion> GetRegions(string id)
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .GetRegions(id)
                    .Unzip<Region>();
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Gets the cultures.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IEnumerable&lt;ICulture&gt;.</returns>
        private IEnumerable<ICulture> GetCultures(string id)
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .GetCultures(id)
                    .Unzip<Culture>();
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Gets the cultures asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="act">The act.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void GetCulturesAsync(string id, Action<IEnumerable<ICulture>> act = null)
        {
            var res = (IEnumerable<ICulture>)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    try
                    {
                        res = GetCultures(id);
                    }
                    catch (Exception ex)
                    {
                        if (wrk != null)
                            wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());
                        throw ex;
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
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return LatiServiceConst.Namespace;
        }


        
    }
}
