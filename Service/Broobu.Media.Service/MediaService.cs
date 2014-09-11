// ***********************************************************************
// Assembly         : Broobu.Media.Service
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="MediaService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ServiceModel;
using Broobu.Media.Business;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Media.Service
{
    /// <summary>
    /// Class MediaService.
    /// </summary>
    public class MediaService :  BusinessServiceBase, IDescription
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            MediaProviderFactory
                .CreateMediaProvider()
                .RegisterDomainObjects();

        }

        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem GetDescriptionItem(string id)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItem(id);
        }


        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObject(string objectId)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsForObject(objectId);
        }

        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForType(string typeId)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsForType(typeId);
        }

        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForCulture(string cultureId)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsForCulture(cultureId);
        }

        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectAndCulture(string objectId, string cultureId)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsForObjectAndCulture(objectId, cultureId);
        }

        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectAndType(string objectId, string typeId)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsForObjectAndType(objectId, typeId);
        }

        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectCultureAndType(string objectId, string cultureId, string typeId)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsForObjectCultureAndType(objectId, cultureId, typeId);
        }

        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForCultureAndType(string cultureId, string typeId)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsForCultureAndType(cultureId, typeId);
        }

        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsLikeTitle(string title)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .GetDescriptionItemsLikeTitle(title);
        }

        /// <summary>
        /// Saves the description item.
        /// </summary>
        /// <param name="descriptionItem">The description item.</param>
        /// <returns>DescriptionItem.</returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public DescriptionItem SaveDescription(DescriptionItem descriptionItem)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .SaveDescription(descriptionItem);
        }

        /// <summary>
        /// Deletes the description item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>DescriptionItem.</returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public DescriptionItem DeleteDescription(DescriptionItem item)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .DeleteDescription(item);
        }

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] SaveDescriptions(DescriptionItem[] descriptions)
        {
            return MediaProviderFactory
                .CreateMediaProvider()
                .SaveDescriptions(descriptions);
        }
    }
}
