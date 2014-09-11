// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Business
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-24-2014
// ***********************************************************************
// <copyright file="EnumerationProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Broobu.Taxonomy.Business.Interfaces;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Exceptions;
using NLog;


namespace Broobu.Taxonomy.Business.Workers
{
    /// <summary>
    /// Class EnumerationProvider.
    /// </summary>
    public class Hooks :  IHooks
    {
        /// <summary>
        /// Registers the taxonomy object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns>TaxonomyHook.</returns>
        public Hook RegisterTaxonomyObject<T>(TaxonomyObject<T> item) where T : TaxonomyObject<T>
        {
            var hook = new Hook() 
            {
                ObjectId = item.Id, 
                TypeId = HookConst.EcoSpaceRoot,
                DisplayName = item.DisplayName
            };
            return Save(hook);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TaxonomyHook.</returns>
        public Hook GetById(string id)
        {
            return Provider<Hook>.GetById(id);
        }

        /// <summary>
        /// Saves the specified it.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>TaxonomyHook.</returns>
        public Hook Save(Hook it)
        {
            var res = it;
            try
            {
                res = Provider<Hook>.Save(it);
                _logger.Info("Added Hook '{0}' for Object [{1}]. Revision [{2}]", res.Id,res.ObjectId,res.Rev);
            }
            catch (Exception exception)
            {
                _logger.Error("-> {0}", exception.GetCombinedMessages());
                res.AddError(exception.Message);
            }
            return res;
        }

        /// <summary>
        /// Registers the type of the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>TaxonomyHook.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook RegisterEnumerationType(Hook item)
        {
            item.TypeId = HookConst.EnumRoot;
            return Provider<Hook>.Save(item);
        }

        /// <summary>
        /// Gets the type of the enumeration items for.
        /// </summary>
        /// <param name="enumType">The base type media.</param>
        /// <returns>Enumeration[][].</returns>
        public Hook[] GetEnumerationsForType(string enumType)
        {
            var req = new WhereRequest()
            {
                KeyField = "Id",
                Field = "TypeId",
                Value = enumType
            };
            return Provider<Hook>.Query(req);
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>Enumeration[][].</returns>
        public Hook[] SaveEnumerations(Hook[] enums)
        {
            return Provider<Hook>.Save(enums);
        }

        /// <summary>
        /// Deletes the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>TaxonomyHook[][].</returns>
        public Hook[] DeleteEnumerations(Hook[] enums)
        {
            return Provider<Hook>.Delete(enums);
        }

        /// <summary>
        /// Deletes the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>TaxonomyHook.</returns>
        public Hook DeleteEnumeration(Hook item)
        {
            return Provider<Hook>.Delete(item);
        }

        /// <summary>
        /// Gets the taxonomy hook identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="ecoSpace">The eco space.</param>
        /// <returns>System.String.</returns>
        public string GetTaxonomyHookId(string id, string displayName, string ecoSpace)
        {
            return GetHook(id, displayName, ecoSpace).Id;
        }

        
        
        
        public Hook GetHook(string id, string displayName, string ecoSpace)
        {
            var req = new WhereRequest()
            {
                KeyField = "Id",
                Field = "ObjectId",
                Value = id
            };
            if (Provider<Hook>.Query(req).Any())
                return Provider<Hook>.Query(req).First();
            var res = CreateEcoObject(id, displayName, ecoSpace);
            res = Provider<Hook>.Save(res);
            return res;
        }

        /// <summary>
        /// Creates the eco object.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="ecoSpace">The eco space.</param>
        /// <returns>Hook.</returns>
        private static Hook CreateEcoObject(string id, string displayName, string ecoSpace)
        {
            return new Hook()
            {
                ObjectId = id,
                EcoSpaceId = ecoSpace,
                DisplayName = displayName
            };
        }


        /// <summary>
        /// Gets the descriptions.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <returns>Description[].</returns>
        private static Description[] GetDescriptions(string id, string displayName)
        {
            //return TaxonomyProvider
            //    .Translations
            //    .GetDescriptionsForObject(id, displayName);
            return TaxonomyDomainGenerator.InflateDefaultDescriptions(id, displayName);
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="hydrate">if set to <c>true</c> [hydrate].</param>
        /// <returns>Hook[].</returns>
        public Hook[] GetChildren(Hook root, bool hydrate = false)
        {
            var req = new WhereRequest() 
            { 
                Field = "ParentId",
                Value = root.Id
            };
            var res = Provider<Hook>
                .Query(req);
            return res!=null ? res.ToArray() : new Hook[]{};
        }

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public Hook[] InflateDomain()
        {
            return null;
        }



        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    }
}