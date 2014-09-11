// ***********************************************************************
// Assembly         : Broobu.Media.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="MediaProviderFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Media.Business.Interfaces;
using Broobu.Media.Business.Providers;

namespace Broobu.Media.Business
{
    /// <summary>
    /// Class MediaProviderFactory.
    /// </summary>
    public class MediaProviderFactory
    {
        

        /// <summary>
        /// Creates the provider.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>IMediaProvider.</returns>
        public static IDescriptionProvider CreateMediaProvider()
        {
            return new DescriptionProvider();
        }


        /// <summary>
        /// Creates the setting provider.
        /// </summary>
        /// <returns>ISettingProvider.</returns>
        public static ISettingProvider CreateSettingProvider()
        {
            return new SettingProvider();
        }

        /// <summary>
        /// Creates the enumeration provider.
        /// </summary>
        /// <returns>IEnumerationProvider.</returns>
        public static IEnumerationProvider CreateEnumerationProvider()
        {
            return new EnumerationProvider();
        }



        /// <summary>
        /// Creates the relation provider.
        /// </summary>
        /// <returns>IRelationProvider.</returns>
        public static ILinkProvider CreateRelationProvider()
        {
            return new LinkProvider();
        }






    }
}
