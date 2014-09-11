// ***********************************************************************
// Assembly         : Wulka.Business
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
using Broobu.Taxonomy.Business.Interfaces;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Exceptions;
using NLog;


namespace Broobu.Taxonomy.Business.Workers
{
    /// <summary>
    /// Class SettingProvider.
    /// </summary>
    class Settings :  ISettings 
    {
        #region ISetting Members


        /// <summary>
        /// Finds the by resource.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>SettingItem.</returns>
        private Setting FindByResource(Setting it)
        {
            try
            {
                _logger.Info("Trying to find {0}", it.ToString());
                var req = new RequestBase()
                {
                    Function = String.Format("if(doc.AccountId=='{0}' && " +
                                          "doc.RoleId=='{1}' && " +
                                          "doc.ObjectId=='{2}' && " +
                                          "doc.ApplicationFunctionId=='{3}') emit(doc.Id,doc)",
                                          it.AccountId, it.RoleId, it.ObjectId, it.ApplicationFunctionId)
                };
                var res = Provider<Setting>.Query(req);
                if (res.Length != 0) return res[0];
                _logger.Info("Not Found.");
                return null;
            }
            catch (Exception exp)
            {
                it.AddError(exp.GetCombinedMessages());
                _logger.Error(exp.GetCombinedMessages());
                return null;
            }
        }


        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>SettingItem.</returns>
        public Setting SaveSettings(Setting item)
        {
            return Provider<Setting>.Save(item);
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SettingItem.</returns>
        public Setting GetSettings(Setting request)
        {
            return FindByResource(request);
        }

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SettingItem.</returns>
        public Setting GetSetting(string id)
        {
            return Provider<Setting>.GetById(id);
        }

        #endregion

        #region ISettingProvider Members

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
            Provider<Setting>.Save(TaxonomyDomainGenerator.CreateDefaultSetting());
        }


        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        #endregion
    }
}
