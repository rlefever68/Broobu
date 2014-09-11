// ***********************************************************************
// Assembly         : Iris.Fx.Business
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="SettingProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Media.Business.Interfaces;
using Broobu.Media.Contract.Domain;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using log4net;

namespace Broobu.Media.Business.Providers
{
    /// <summary>
    /// Class SettingProvider.
    /// </summary>
    class SettingProvider : ProviderBase<SettingItem>, ISettingProvider 
    {
        #region ISetting Members

        /// <summary>
        /// The _logger
        /// </summary>
        ILog _logger = LogManager.GetLogger(typeof(SettingProvider));


        /// <summary>
        /// Finds the by resource.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>SettingItem.</returns>
        private SettingItem FindByResource(SettingItem it)
        {
            try
            {
                _logger.DebugFormat("Trying to find {0}", it.ToString());
                 var res = Query("doc.AccountId=='{0}' && " +
                                          "doc.RoleId=='{1}' && " +
                                          "doc.ObjectId=='{2}' && " +
                                          "doc.ApplicationFunctionId=='{3}'",
                                          it.AccountId, it.RoleId,it.ObjectId, it.ApplicationFunctionId);
                if (res.Length != 0) return res[0];
                _logger.DebugFormat("Not Found.");
                return null;
            }
            catch (Exception exp)
            {
                _logger.ErrorFormat("Not Found. {0}", exp.Message);
                return null;
            }
        }


        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>SettingItem.</returns>
        public SettingItem SaveSettings(SettingItem item)
        {
            return Save(item);
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SettingItem.</returns>
        public SettingItem GetSettings(SettingItem request)
        {
            return FindByResource(request);
        }

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SettingItem.</returns>
        public SettingItem GetSetting(string id)
        {
            return GetById(id);
        }

        #endregion

        #region ISettingProvider Members

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
            Save(MediaDomainGenerator.CreateDefaultSetting());
        }

        #endregion
    }
}
