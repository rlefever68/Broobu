// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-10-2014
// ***********************************************************************
// <copyright file="TaxonomyPortal.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using Broobu.Taxonomy.Contract.Agent;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Utils;

namespace Broobu.Taxonomy.Contract
{
    /// <summary>
    /// Class TaxonomyAgentFactory.
    /// </summary>
    public static class TaxonomyPortal
    {

        /// <summary>
        /// Gets the descriptions.
        /// </summary>
        /// <value>The descriptions.</value>
        public static ITranslateAgent Descriptions 
        {
            get { return new DescriptionAgent(null); }
        }


        /// <summary>
        /// Gets the enumerations.
        /// </summary>
        /// <value>The enumerations.</value>
        public static IHookAgent Hooks
        {
            get { return new HookAgent(null);}
        }



        public static ILinkAgent Links
        {
            get { return new LinkAgent(null); }
        }





       
        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public static ISettingAgent Settings
        {
            get { return new SettingAgent(null);}
        }


        /// <summary>
        /// Decorates the taxonomy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="dataCulture">The data culture.</param>
        public static void HydrateTranslations<T>(this T item, string dataCulture = null)
            where T : ITranslatable
        {
            item.DataCulture = dataCulture;
            if (dataCulture == null)
                item.DataCulture = CurrentWindowsUser.Culture.TwoLetterISOLanguageName;
            item.Description = Descriptions
                .GetDescriptionsForObjectAndCulture(item.Id, item.DataCulture)
                .FirstOrDefault();
        }


        /// <summary>
        /// Saves the translations.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public static void SaveTranslations<T>(this T item)
            where T: ITranslatable
        {
            try
            {
                if (item.Description != null)
                {
                    item.Description = Descriptions.SaveDescription((Description)item.Description);
                }
            }
            catch (Exception exception)
            {
                item.AddError(exception.Message);
            }
        }


        /// <summary>
        /// Saves the links.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public static void SaveLinks<T>(this T item)
            where T:ILinkable
        {
            //try
            //{
            //    if (item.Targets != null)
            //    {
            //        item.Targets = Links.SaveRelations(item.Targets);
            //    }
            //}
            //catch (Exception exception)
            //{
            //    item.AddError(exception.Message);
            //}
        }




        /// <summary>
        /// Gets the links.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="relationType">Type of the relation.</param>
        public static void HydrateLinks<T>(this T item, string relationType = null)
            where T : ILinkable
        {
            item.HookId = Hooks.GetTaxonomyHookId(item.Id, item.DisplayName, item.ParentId);
            if (relationType == null) return;
            //item.Actors = Links.GetRelationsTo(item.HookId, relationType);
            //item.Targets = Links.GetRelationsFrom(item.HookId, relationType);
        }

    }
}
