// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Business
// Author           : Rafael Lefever
// Created          : 12-25-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="TaxonomyProvider.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections;
using System.Collections.Generic;
using Broobu.Taxonomy.Business.Interfaces;
using Broobu.Taxonomy.Business.Workers;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.Taxonomy.Business
{
    /// <summary>
    /// Class TaxonomyProviderFactory.
    /// </summary>
    public static class TaxonomyProvider
    {
        /// <summary>
        /// Gets the descriptions.
        /// </summary>
        /// <value>The descriptions.</value>
        public static IDescriptions Translations 
        {
            get 
            { 
                return new Descriptions();
            }
        }


        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public static ISettings Settings
        {
            get
            {
                return new Settings();
            }
        }


        /// <summary>
        /// Gets the enumerations.
        /// </summary>
        /// <value>The enumerations.</value>
        public static IHooks Hooks
        {
            get
            {
                return new Hooks();
            }
        }


        /// <summary>
        /// Gets the links.
        /// </summary>
        /// <value>The links.</value>
        public static ILinks Links
        {
            get
            {
                return new Links();
            }
        }

        ///// <summary>
        ///// Gets the description types.
        ///// </summary>
        ///// <value>The description types.</value>
        //public static IEnumerable<Hook> DescriptionTypes {
        //    get 
        //    {
        //        var res = Hooks
        //            .GetChildren(new Hook() {Id = HookConst.DescriptionTypeEnum });
        //        return res.Length == 0 ? TaxonomyDomainGenerator.DescriptionTypes : res;
        //    }
        //}

        ///// <summary>
        ///// Gets the data cultures.
        ///// </summary>
        ///// <value>The data cultures.</value>
        //public static IEnumerable<Hook> DataCultures {
        //    get {
        //        var res = Hooks
        //            .GetChildren(new Hook() { Id = HookConst.DataCultureEnum });
        //        return res.Length==0 ? TaxonomyDomainGenerator.DefaultDataCultures : res;
        //    }
        //}


    }
}
