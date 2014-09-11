// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-12-2014
// ***********************************************************************
// <copyright file="TaxonomyHookService.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Broobu.Taxonomy.Business;
using Broobu.Taxonomy.Business.Workers;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Networking.Wcf;
using Wulka.Networking.Wcf.Interfaces;

namespace Broobu.Taxonomy.Service
{
    /// <summary>
    /// Class EnumerationService.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class HookSentry : SentryBase, IHookSentry
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            TaxonomyProvider
                .Hooks
                .InflateDomain();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Enumeration.</returns>
        public Hook GetById(string id)
        {
            return TaxonomyProvider
                .Hooks
                .GetById(id);
        }

        /// <summary>
        /// Saves the specified it.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>Enumeration.</returns>
        public Hook Save(Hook it)
        {
            return TaxonomyProvider
                .Hooks
                .Save(it);
        }

        /// <summary>
        /// Registers the type of the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Enumeration.</returns>
        public Hook RegisterEnumerationType(Hook item)
        {
            item.TypeId = HookConst.EnumRoot;
            return Save(item);
        }

        /// <summary>
        /// Gets the type of the enumeration items for.
        /// </summary>
        /// <param name="typeId">The base type media.</param>
        /// <returns>Enumeration[][].</returns>
        public Hook[] GetEnumerationsForType(string typeId)
        {
            return TaxonomyProvider
                .Hooks
                .GetEnumerationsForType(typeId);
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>Enumeration[][].</returns>
        public Hook[] SaveEnumerations(Hook[] enums)
        {
            return TaxonomyProvider
                .Hooks
                .SaveEnumerations(enums);
        }

        /// <summary>
        /// Deletes the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>Enumeration[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook[] DeleteEnumerations(Hook[] enums)
        {
            return TaxonomyProvider
                .Hooks
                .DeleteEnumerations(enums);
        }

        /// <summary>
        /// Deletes the enumeration item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Enumeration.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook DeleteEnumeration(Hook item)
        {
            return TaxonomyProvider
                .Hooks
                .DeleteEnumeration(item);
        }

        /// <summary>
        /// Gets the taxonomy hook.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName"></param>
        /// <returns>TaxonomyHook.</returns>
        public string GetTaxonomyHookId(string id, string displayName, string ecoSpace)
        {
            return TaxonomyProvider
                .Hooks
                .GetTaxonomyHookId(id, displayName, ecoSpace);
        }

        ///// <summary>
        ///// Gets the children.
        ///// </summary>
        ///// <param name="root">The root.</param>
        ///// <param name="hydrate"></param>
        ///// <returns>Hook[].</returns>
        //public Hook[] GetChildren(Hook root, bool hydrate = false)
        //{
        //    return TaxonomyProvider
        //        .Hooks
        //        .GetChildren(root, hydrate);
        //}

        public Hook GetHook(string id, string displayName, string ecoSpace)
        {
            return TaxonomyProvider
                .Hooks
                .GetHook(id, displayName, ecoSpace);
        }
    }
}
