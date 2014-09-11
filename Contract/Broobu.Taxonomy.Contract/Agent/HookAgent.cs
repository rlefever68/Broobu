// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-26-2014
// ***********************************************************************
// <copyright file="EnumerationAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Exceptions;
using Wulka.Networking.Wcf;



namespace Broobu.Taxonomy.Contract.Agent
{
    /// <summary>
    /// Class EnumerationAgent.
    /// </summary>
    class HookAgent : DiscoProxy<IHookSentry>, IHookAgent
    {
        public HookAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Enumeration.</returns>
        public Hook GetById(string id)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetById(id);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Saves the specified it.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>Enumeration.</returns>
        public Hook Save(Hook it)
        {
            var clt = CreateClient();
            try
            {
                return clt.Save(it);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Registers the type of the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Enumeration.</returns>
        public Hook RegisterEnumerationType(Hook item)
        {
            var clt = CreateClient();
            try
            {
                return clt.RegisterEnumerationType(item);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the type of the TaxonomyHook items for.
        /// </summary>
        /// <param name="baseTypeMedia">The base type media.</param>
        /// <returns>TaxonomyHook[][].</returns>
        public Hook[] GetEnumerationsForType(string baseTypeMedia)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetEnumerationsForType(baseTypeMedia);
            }
            finally
            {
                CloseClient(clt);
            }
           
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="createRibbonTypeEnumeration">The create ribbon type enumeration.</param>
        /// <returns>TaxonomyHook[][].</returns>
        public Hook[] SaveEnumerations(Hook[] createRibbonTypeEnumeration)
        {
            var clt = CreateClient();
            try
            {
                return clt.SaveEnumerations(createRibbonTypeEnumeration);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Deletes the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>TaxonomyHook[][].</returns>
        public Hook[] DeleteEnumerations(Hook[] enums)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteEnumerations(enums);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Deletes the TaxonomyHook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Enumeration.</returns>
        public Hook DeleteEnumeration(Hook item)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteEnumeration(item);
            }
            finally
            {
                CloseClient(clt);
            }
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
        /// Gets the taxonomy hook.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="ecoSpace">The eco space.</param>
        /// <returns>Enumeration.</returns>
        public string GetTaxonomyHookId(string id, string displayName, string ecoSpace=null)
        {
            ecoSpace = HookConst.EcoSpaceRoot;
            var clt = CreateClient();
            try
            {
                return clt.GetTaxonomyHookId(id,displayName, ecoSpace);
            }
            finally
            {
                CloseClient(clt);
            }
        }



        ///// <summary>
        ///// Gets the children.
        ///// </summary>
        ///// <param name="root">The root.</param>
        ///// <param name="hydrate">if set to <c>true</c> [hydrate].</param>
        ///// <returns>Hook[].</returns>
        //public Hook[] GetChildren(Hook root, bool hydrate = false)
        //{
        //    var clt = CreateClient();
        //    try
        //    {
        //        return clt.GetChildren(root, hydrate);
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }

        //}

        /// <summary>
        /// Gets the hook.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="ecoSpace">The eco space.</param>
        /// <returns>Hook.</returns>
        public Hook GetHook(string id, string displayName, string ecoSpace)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetHook(id,displayName, ecoSpace);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the hook.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>IHook.</returns>
        public IHook GetHook(ITaxonomyObject source)
        {
            return GetHook(source.Id, source.DisplayName, source.MasterDocId);
        }

        
        public void GetHookAsync(ITaxonomyObject source, Action<IHook> act=null)
        {
            IHook res = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = GetHook(source);
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
