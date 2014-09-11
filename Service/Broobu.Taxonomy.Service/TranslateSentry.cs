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
using Broobu.Taxonomy.Business;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.Taxonomy.Service
{
    
    public class TranslateSentry :  SentryBase, ITranslate
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            Business.TaxonomyProvider
                .Translations
                .RegisterDomainObjects();

        }

        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Description.</returns>
        public Description GetDescription(string id)
        {
            return TaxonomyProvider
                .Translations
                .GetDescription(id);
        }


        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="displayName">The default displayName in English for this object</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObject(string objectId, string displayName)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsForObject(objectId, displayName);
        }

        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForType(string typeId)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsForType(typeId);
        }

        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForCulture(string cultureId)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsForCulture(cultureId);
        }

        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObjectAndCulture(string objectId, string cultureId)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsForObjectAndCulture(objectId, cultureId);
        }

        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObjectAndType(string objectId, string typeId)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsForObjectAndType(objectId, typeId);
        }

        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObjectCultureAndType(string objectId, string cultureId, string typeId)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsForObjectCultureAndType(objectId, cultureId, typeId);
        }

        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForCultureAndType(string cultureId, string typeId)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsForCultureAndType(cultureId, typeId);
        }

        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsLikeTitle(string title)
        {
            return TaxonomyProvider
                .Translations
                .GetDescriptionsLikeTitle(title);
        }

        /// <summary>
        /// Saves the description item.
        /// </summary>
        /// <param name="Description">The description item.</param>
        /// <returns>Description.</returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public Description SaveDescription(Description Description)
        {
            return TaxonomyProvider
                .Translations
                .SaveDescription(Description);
        }

        /// <summary>
        /// Deletes the description item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Description.</returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public Description DeleteDescription(Description item)
        {
            return TaxonomyProvider
                .Translations
                .DeleteDescription(item);
        }

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>Description[][].</returns>
        public Description[] SaveDescriptions(Description[] descriptions)
        {
            return TaxonomyProvider
                .Translations
                .SaveDescriptions(descriptions);
        }
    }
}
