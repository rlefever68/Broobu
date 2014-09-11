// ***********************************************************************
// Assembly         : Broubu.Boutique.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-18-2014
// ***********************************************************************
// <copyright file="BoutiqueAgent.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.Contract.Interfaces;
using Broobu.EcoSpace.Contract.Domain.Account;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;



namespace Broobu.Boutique.Contract.Agent
{
    /// <summary>
    /// Class BoutiqueAgent.
    /// </summary>
    class BoutiqueAgent : DiscoProxy<IBoutiqueSentry>, IBoutiqueAgent
    {
        public BoutiqueAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return BoutiqueServiceConst.Namespace;
        }


        /// <summary>
        /// Occurs when [get Boutique user info completed].
        /// </summary>
        public event Action<UserEnvironmentInfo> GetUserEnvironmentInfoCompleted;

        /// <summary>
        /// Gets the Boutique user info async.
        /// </summary>
        /// <param name="act">The act.</param>
        public void GetUserEnvironmentInfoAsync(Action<UserEnvironmentInfo> act = null)
        {
            //WithValidClient(() => 
            //{
                var res = (UserEnvironmentInfo)null;
                using (var wrk = new BackgroundWorker())
                {
                    wrk.DoWork += (s, e) => { res = GetUserEnvironmentInfo(); };
                    wrk.RunWorkerCompleted += (s, e) =>
                    {
                        wrk.Dispose();
                        if (act == null)
                        {
                            if (GetUserEnvironmentInfoCompleted != null)
                                GetUserEnvironmentInfoCompleted(res);
                        }
                        else
                        {
                            act(res);
                        }
                    };
                    wrk.RunWorkerAsync();
                }
        //    });
        }

     
    
    
        /// <summary>
        /// Gets the Boutique user info.
        /// </summary>
        /// <returns>UserEnvironmentInfo.</returns>
        public UserEnvironmentInfo GetUserEnvironmentInfo()
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .GetUserEnvironmentInfo()
                    .Unzip<UserEnvironmentInfo>();
            }
            finally
            {
                CloseClient(clt);
            }
        }

       










        ///// <summary>
        ///// Gets the object async.
        ///// </summary>
        ///// <param name="objectId">The object id.</param>
        ///// <param name="act">The act.</param>
        ///// <remarks></remarks>
        //public void GetTagObjectAsync(string objectId, Action<Hook> act)
        //{
        //    Hook res = null;
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            try
        //            {
        //                res = GetTagObject(objectId);
        //            }
        //            catch (Exception)
        //            {
        //                wrk.Dispose();
        //            }
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (act != null)
        //                act(res);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}

        ///// <summary>
        ///// Saves the object async.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <param name="act">The act.</param>
        ///// <remarks></remarks>
        //public void SaveTagObjectAsync(Hook it, Action<Hook> act)
        //{
        //    Hook res = null;
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            try
        //            {
        //                res = SaveTagObject(it);
        //            }
        //            catch (Exception)
        //            {
        //                wrk.Dispose();
        //            }
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (act != null)
        //                act(res);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}

        ///// <summary>
        ///// Gets the applet menu async.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <param name="act">The act.</param>
        ///// <remarks></remarks>
        //public void GetAppletMenuAsync(string appletId, Action<BoutiqueMenuInfo> act)
        //{
        //    BoutiqueMenuInfo res = null;
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            try
        //            {
        //                res = GetAppletMenu(appletId);
        //            }
        //            catch (Exception)
        //            {
        //                wrk.Dispose();
        //            }
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (act != null)
        //                act(res);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}

        ///// <summary>
        ///// Registers the applet async.
        ///// </summary>
        ///// <param name="info">The info.</param>
        ///// <param name="act">The act.</param>
        ///// <remarks></remarks>
        //public void RegisterAppletAsync(ApplicationFunction info, Action<ApplicationFunction> act)
        //{
        //    ApplicationFunction res = null;
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            try
        //            {
        //                res = RegisterApplet(info);
        //            }
        //            catch (Exception)
        //            {
        //                wrk.Dispose();
        //            }
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (act != null)
        //                act(res);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}

        ///// <summary>
        ///// Gets the tag object.
        ///// </summary>
        ///// <param name="objectId">The object id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Hook GetTagObject(string objectId)
        //{
        //    return Client.GetTagObject(objectId);
        //}

        ///// <summary>
        ///// Saves the tag object.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Hook SaveTagObject(Hook it)
        //{
        //    return Client.SaveTagObject(it);
        //}

        ///// <summary>
        ///// Gets the applet menu.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public BoutiqueMenuInfo GetAppletMenu(string appletId)
        //{
        //    return Client.GetAppletMenu(appletId);
        //}

        /// <summary>
        /// Registers the applet.
        /// </summary>
        /// <param name="applet">The applet.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        //public ApplicationFunction RegisterApplet(ApplicationFunction applet)
        //{
        //    return Client.RegisterApplet(applet);
        //}

     


        ///// <summary>
        ///// Saves the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Setting SaveSettings(Setting item)
        //{
        //    var clt = (IBoutique)null;
        //    try
        //    {
        //        clt = CreateClient();
        //        return clt.SaveSettings(item);
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }
        //}




     


        ///// <summary>
        ///// Saves the settings async.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <param name="action">The action.</param>
        ///// <remarks></remarks>
        //public void SaveSettingsAsync(Setting item, Action<Setting> action)
        //{
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        var res = (Setting)null;
        //        wrk.DoWork += (s, e) => 
        //        {
        //            try
        //            {
        //                res = SaveSettings(item);
        //            }
        //            catch(Exception ex)
        //            {
        //                wrk.Dispose();
        //                throw ex;
        //            }
        //        };
        //        wrk.RunWorkerCompleted += (s, e) => 
        //        {
        //            wrk.Dispose();
        //            if (action != null)
        //                action(res);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}


        ///// <summary>
        ///// Gets the settings async.
        ///// </summary>
        ///// <param name="req">The req.</param>
        ///// <param name="action">The action.</param>
        ///// <remarks></remarks>
        //public void GetSettingsAsync(Setting req, Action<Setting> action)
        //{
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        var res = (Setting)null;
        //        wrk.DoWork += (s, e) =>
        //        {
        //            try
        //            {
        //                res = GetSettings(req);
        //            }
        //            catch (Exception ex)
        //            {
        //                wrk.Dispose();
        //                throw ex;
        //            }
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            wrk.Dispose();
        //            if (action != null)
        //                action(res);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}

       

        ///// <summary>
        ///// Gets the settings.
        ///// </summary>
        ///// <param name="req">The req.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Setting GetSettings(Setting req)
        //{
        //    var clt = (IBoutique)null;
        //    try
        //    {
        //        clt = CreateClient();
        //        return clt.GetSettings(req);
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }
        //}

      


        ///// <summary>
        ///// Gets the descriptions for object.
        ///// </summary>
        ///// <param name="typeId">The type id.</param>
        ///// <param name="objectId">The object id.</param>
        ///// <param name="cultureId">The culture id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Description[] GetDescriptionsForObject(string typeId, string objectId, string cultureId)
        //{
        //    var clt = CreateClient();
        //    try
        //    {
        //        return clt.GetDescriptionsForObject(typeId, objectId, cultureId);
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }
        //}

        ///// <summary>
        ///// Saves the description.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Description SaveDescription(Description item)
        //{
        //    var clt = CreateClient();
        //    try
        //    {
        //        return clt.SaveDescription(item);
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }
        //}

       


        ///// <summary>
        ///// Gets the description types.
        ///// </summary>
        ///// <param name="cultureId">The culture id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Hook[] GetDescriptionTypes(string cultureId)
        //{
        //    var clt = CreateClient();
        //    try
        //    {
        //        return clt.GetDescriptionTypes(cultureId);
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }
        //}


        ///// <summary>
        ///// Gets the personal settings.
        ///// </summary>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Setting GetPersonalSettings()
        //{
        //    var clt = CreateClient();
        //    try
        //    {
        //        return clt.GetPersonalSettings();
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }
        //}

       


        //public ApplicationFunction GetAppletInfo(string appletId)
        //{
        //    return Client.GetAppletInfo(appletId);
        //}


       

    }
}
