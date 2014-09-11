// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Service
// Author           : ON8RL
// Created          : 12-24-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-24-2013
// ***********************************************************************
// <copyright file="SettingService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Taxonomy.Business;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.Taxonomy.Service
{
    /// <summary>
    /// Class SettingService.
    /// </summary>
    public class SettingSentry : SentryBase, ISetting
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
             TaxonomyProvider
                 .Settings
                .RegisterRequiredDomainObjects();
        }

        #region ISetting Members

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>SettingItem.</returns>
        public Setting SaveSettings(Setting item)
        {
            return Business.TaxonomyProvider
                .Settings
                .SaveSettings(item);
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SettingItem.</returns>
        public Setting GetSettings(Setting request)
        {
            return Business.TaxonomyProvider
                .Settings
                .GetSettings(request);
        }

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SettingItem.</returns>
        public Setting GetSetting(string id)
        {
            return Business.TaxonomyProvider
                .Settings
                .GetSetting(id);
        }

        #endregion
    }
}
