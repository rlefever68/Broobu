// ***********************************************************************
// Assembly         : Broobu.Media.Service
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="EnumerationService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Media.Business;
using Broobu.Media.Contract.Domain;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Media.Service
{
    /// <summary>
    /// Class EnumerationService.
    /// </summary>
    public class EnumerationService : BusinessServiceBase, IEnumeration
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            MediaProviderFactory
                .CreateEnumerationProvider()
                .RegisterRequiredDomainObjects();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EnumerationItem.</returns>
        public EnumerationItem GetById(string id)
        {
            return MediaProviderFactory
                .CreateEnumerationProvider()
                .GetById(id);
        }

        /// <summary>
        /// Saves the specified it.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>EnumerationItem.</returns>
        public EnumerationItem Save(EnumerationItem it)
        {
            return MediaProviderFactory
                .CreateEnumerationProvider()
                .Save(it);
        }

        /// <summary>
        /// Registers the type of the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>EnumerationItem.</returns>
        public EnumerationItem RegisterEnumerationType(EnumerationItem item)
        {
            item.TypeId = EnumerationConst.TypeEnum;
            return Save(item);
        }

        /// <summary>
        /// Gets the type of the enumeration items for.
        /// </summary>
        /// <param name="typeId">The base type media.</param>
        /// <returns>EnumerationItem[][].</returns>
        public EnumerationItem[] GetEnumerationItemsForType(string typeId)
        {
            return MediaProviderFactory
                .CreateEnumerationProvider()
                .GetEnumerationItemsForType(typeId);
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>EnumerationItem[][].</returns>
        public EnumerationItem[] SaveEnumerations(EnumerationItem[] enums)
        {
            return MediaProviderFactory
                .CreateEnumerationProvider()
                .SaveEnumerations(enums);
        }

        /// <summary>
        /// Deletes the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>EnumerationItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public EnumerationItem[] DeleteEnumerations(EnumerationItem[] enums)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the enumeration item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>EnumerationItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public EnumerationItem DeleteEnumerationItem(EnumerationItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}
