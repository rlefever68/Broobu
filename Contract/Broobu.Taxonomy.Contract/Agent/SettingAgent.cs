// ***********************************************************************
// Assembly         : Broobu.Media.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="SettingAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.Taxonomy.Contract.Agent
{
    /// <summary>
    /// Class SettingAgent.
    /// </summary>
    class SettingAgent : DiscoProxy<ISetting>, ISettingAgent
    {


        #region ISettingAgent Members

        public SettingAgent(string discoUrl) 
            : base(discoUrl)
        {
        }

        /// <summary>
        /// Saves the settings async.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="action">The action.</param>
        public void SaveSettingsAsync(Setting item, Action<Setting> action)
        {
            using (var wrk = new BackgroundWorker())
            {
                var res = (Setting)null; 
                wrk.DoWork += (s, e) => 
                {
                    try
                    {
                        SaveSettings(item);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        throw ex;
                    }
                };
                wrk.RunWorkerCompleted += (s, e) => 
                {
                    if (action != null)
                        action(res);
                    wrk.Dispose();
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the settings async.
        /// </summary>
        /// <param name="req">The req.</param>
        /// <param name="action">The action.</param>
        public void GetSettingsAsync(Setting req, Action<Setting> action)
        {
            using (var wrk = new BackgroundWorker())
            {
                var res     = (Setting)null;
                wrk.DoWork += (s, e) =>
                {
                    try
                    {
                        res = GetSettings(req);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        throw ex;
                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (action != null)
                        action(res);
                    wrk.Dispose();
                };
                wrk.RunWorkerAsync();
            }
        }

        #endregion

        #region ISetting Members

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>SettingItem.</returns>
        public Setting SaveSettings(Setting item)
        {
            var clt = (ISetting)null;
            try
            {
                clt = CreateClient();
                return clt.SaveSettings(item);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="req">The req.</param>
        /// <returns>SettingItem.</returns>
        public Setting GetSettings(Setting req)
        {
            var clt = (ISetting)null;
            try
            {
                clt = CreateClient();
                return clt.GetSettings(req);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SettingItem.</returns>
        public Setting GetSetting(string id)
        {
            var clt = (ISetting)null;
            try
            {
                clt = CreateClient();
                return clt.GetSetting(id);
            }
            finally
            {
                CloseClient(clt);
            }
        }



        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return TaxonomyConst.Namespace;
        }

        #endregion
    }
}
