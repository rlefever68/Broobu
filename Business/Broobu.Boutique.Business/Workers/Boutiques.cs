// ***********************************************************************
// Assembly         : Broobu.Boutique.Business
// Author           : Rafael Lefever
// Created          : 01-15-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-18-2014
// ***********************************************************************
// <copyright file="Boutiques.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Broobu.Authentication.Contract;
using Broobu.Authentication.Contract.Domain;
using Broobu.Boutique.Business.Interfaces;
using Broobu.Boutique.Contract.Domain;
using Broobu.EcoSpace.Contract;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Default;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Wulka.Authentication;
using Wulka.Configuration;
using Wulka.Core;
using Wulka.Data;
using Wulka.Domain;
using NLog;
using Wulka.Domain.Authentication;

namespace Broobu.Boutique.Business.Workers
{
    /// <summary>
    /// Class Boutiques.
    /// </summary>
    class Boutiques :  IBoutiques
    {


        /// <summary>
        /// The _logger
        /// </summary>
        /// <value>The _logger.</value>
        private static Logger Logger 
        {
            get 
            {
                return LogManager.GetLogger("Boutiques");
            }
        }




        ///// <summary>
        ///// Gets the Boutique user info.
        ///// </summary>
        ///// <param name="userName">Name of the user.</param>
        ///// <returns>UserEnvironmentInfo.</returns>
        //public UserEnvironmentInfo GetUserEnvironmentInfo(string userName)
        //{
        //    Logger.Info("Getting Boutique Menu Info for user {0}", userName);
        //    UserEnvironmentInfo userInfo = GetDefaultUserEnvironmentInfo();
        //    ApplicationFunction[] afi = GetUserMenu(userName);
        //    if (afi.Any())
        //    {
        //        var nfo = afi.ToBoutiqueMenuInfos();
        //        Logger.Info("{0} Items remain after mapping for user: {1}", nfo.Count(), userName);
        //        if ((nfo != null))
        //        {
        //            if (nfo.Length > 0)
        //            {
        //                var items = userInfo.Menu.Items != null ? userInfo.Menu.Items.ToList() : new List<BoutiqueMenuInfo>();
        //                items.AddRange(nfo);
        //                Logger.Info("{0} Items added to UserInfo for user: {1}", items.Count, userName);
        //                userInfo.Menu.Items = items.ToArray();
        //                Logger.Info("{0} Items in UserInfo for user: {1}", userInfo.Menu.Items.Count(), userName);
        //            }
        //        }
        //    }
        //    var acc = GetAccountForUser(userName);
        //    userInfo.UserId = acc.Id;
        //    userInfo.Greeting = String.Format("User [{0}] is validated. - Welcome, {1} {2}.", userName, acc.FirstName, acc.LastName);
        //    Logger.Info(userInfo.Greeting);
        //    return userInfo;
        //}

        /// <summary>
        /// Gets the account for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Account.</returns>
        private static Account GetAccountForUser(string userName)
        {
            var it = AuthenticationPortal
                .Accounts
                .GetAccountForUser(userName);
            if(it!=null)
                Logger.Info("Found account {0}", it.Id);
            return it;
        }

        ///// <summary>
        ///// Gets the user menu.
        ///// </summary>
        ///// <param name="userName">Name of the user.</param>
        ///// <returns>ApplicationFunction[].</returns>
        //private ApplicationFunction[] GetUserMenu(string userName)
        //{
        //    Logger.Info("----- ----- GetUserMenu -------------");
        //    Logger.Info("Retrieving User Menu for user: {0}", userName);
        //    Logger.Info("------- --------------- -------------");
        //    var res = AuthorizationPortal
        //        .ApplicationFunctions
        //        .GetMenuForUser(userName);
        //    if (res != null)
        //    {
        //        Logger.Info("Found {0} ApplicationFunctions for {1}", res.Length, userName);
        //    }
        //    else
        //    {
        //        Logger.Info("Found NO ApplicationFunctions for {0}", userName);
        //    }
        //    return res;
        //}

        /// <summary>
        /// Gets the default Boutique user info.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>UserEnvironmentInfo.</returns>
        private UserEnvironmentInfo GetDefaultUserEnvironmentInfo(string userName)
        {
            UserEnvironmentInfo res;
            try
            {
                res = userName == AuthenticationDefaults.GuestUserName 
                    ? BoutiqueDomainGenerator.CreateDefaultGuestUserInfo() 
                    : BoutiqueDomainGenerator.CreateDefaultUserEnvironmentInfo();
            }
            catch
            {
                res =  null;
            }
            return res ?? new UserEnvironmentInfo();
        }

        //#region IBoutiqueProvider Members










        ///// <summary>
        ///// Saves the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>Setting.</returns>
        //public Setting SaveSettings(Setting item)
        //{
        //    return TaxonomyPortal
        //        .Settings
        //        .SaveSettings(item);

        //}



        ///// <summary>
        ///// Gets the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>Setting.</returns>
        //public Setting GetSettings(Setting item)
        //{
        //    return TaxonomyPortal
        //        .Settings
        //        .GetSettings(item);
        //}

        //#endregion

        //#region IBoutique Members

        /// <summary>
        /// Gets the Boutique user info.
        /// </summary>
        /// <returns>UserEnvironmentInfo.</returns>
        public UserEnvironmentInfo GetUserEnvironmentInfo()
        {
            return GetUserEnvironmentInfo(WulkaContext.Current[WulkaContextKey.UserName]);
        }


        ///// <summary>
        ///// Gets the descriptions for object.
        ///// </summary>
        ///// <param name="typeId">The type id.</param>
        ///// <param name="objectId">The object id.</param>
        ///// <param name="cultureId">The culture id.</param>
        ///// <returns>Description[][].</returns>
        //public Description[] GetDescriptionsForObject(string typeId, string objectId, string cultureId)
        //{
        //    return TaxonomyPortal
        //        .Descriptions
        //        .GetDescriptionsForObjectCultureAndType(objectId, cultureId, typeId);
        //}

        ///// <summary>
        ///// Gets the object.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns>Hook.</returns>
        //public Hook GetObject(string id)
        //{
        //    return TaxonomyPortal
        //        .Hooks
        //        .GetById(id);
        //}

        ///// <summary>
        ///// Saves the object.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <returns>Hook.</returns>
        //public Hook SaveObject(Hook it)
        //{
        //    return TaxonomyPortal
        //        .Hooks
        //        .Save(it);
        //}

        ///// <summary>
        ///// Gets the applet menu.
        ///// </summary>
        ///// <param name="UserName">Name of the user.</param>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns>BoutiqueMenuInfo.</returns>
        //public BoutiqueMenuInfo GetAppletMenu(string UserName, string appletId)
        //{
        //    var res = new BoutiqueMenuInfo() {};
        //    res.AddError("Under Construction");
        //    return res;
        //}

        ///// <summary>
        ///// Gets the applet menu.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns>BoutiqueMenuInfo.</returns>
        ///// <exception cref="NotImplementedException"></exception>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public BoutiqueMenuInfo GetAppletMenu(string appletId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Registers the applet.
        ///// </summary>
        ///// <param name="applet">The applet.</param>
        ///// <returns>ApplicationFunction.</returns>
        //public ApplicationFunction RegisterApplet(ApplicationFunction applet)
        //{
        //    Logger.Info("Registering applet:{0}", applet);
        //    applet.ParentId = AuthorizationDomainGenerator.ApplicationFunctionFolder.Unregistered;
        //    var req = new[] {applet};
        //    var res = AuthorizationPortal
        //        .ApplicationFunctions
        //        .SaveApplicationFunctions(req);
           
        //    return res.Length>=0 ? res[0] : null;
        //}

        ///// <summary>
        ///// Saves the description.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>Description.</returns>
        //public Description SaveDescription(Description item)
        //{
        //    using (var scp = new TransactionScope())
        //    {
        //        try
        //        {
        //            var res = TaxonomyPortal
        //                .Descriptions
        //                .SaveDescription(item);
        //            scp.Complete();
        //            return res;
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.Error(ex.GetCombinedMessages());
        //            item.AddError(ex.Message);
        //            return item;
        //        }
        //    }
        //}

        //#endregion

        //#region IBoutiqueProvider Members


        /// <summary>
        /// Gets the boutique user information.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="ecoSpaceId">The eco space identifier.</param>
        /// <returns>UserEnvironmentInfo.</returns>
        public UserEnvironmentInfo GetUserEnvironmentInfo(string userName, string ecoSpaceId=null)
        {
            if (String.IsNullOrWhiteSpace(ecoSpaceId)) 
                ecoSpaceId = ConfigurationHelper.DiscoEndpoint;
            Logger.Info("Getting Boutique Menu Info for user '{0}' from EcoSpace '{1}'", userName, ecoSpaceId);
            var acc = GetAccountForUser(userName);
            var userInfo = EcoSpacePortal
                .GetEcoSpace(ecoSpaceId)
                .GetUserInfo(acc.Id, String.Format("{0} {1}",acc.FirstName,acc.LastName));
            Logger.Info(userInfo.Greeting);
            return userInfo;
        }



        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void InflateDomain()
        {
        }

        /// <summary>
        /// Gets the applet menu.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="appletId">The applet identifier.</param>
        /// <returns>BoutiqueMenuInfo.</returns>
        public BoutiqueMenuInfo GetAppletMenu(string userName, string appletId)
        {
            return null;
        }

        


//// <summary>
        ///// Registers the description type enumeration.
        ///// </summary>
        //private void RegisterDescriptionTypeEnumeration()
        //{
        //    Hook[] res = BoutiqueDomainGenerator.CreateDescriptionTypeEnumeration();
        //    if(res!=null)
        //    {
        //        Logger.Info("** Creating default DescriptionType Enumeration **");
        //        using (var scp = new TransactionScope())
        //        {
        //            try
        //            {
        //                foreach (var it in res)
        //                {
        //                    Logger.Info("Registering {0}", it);
        //                    TaxonomyPortal
        //                        .Hooks
        //                        .Save(it);
        //                }
        //                scp.Complete();
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex.GetCombinedMessages);
        //            }
        //        }
        //    }
        //}

        //#endregion

        //#region IBoutique Members


        ///// <summary>
        ///// Gets the description types.
        ///// </summary>
        ///// <param name="cultrureId">The cultrure id.</param>
        ///// <returns>Hook[][].</returns>
        //public Hook[] GetDescriptionTypes(string cultrureId)
        //{
        //    var descrTypes = TaxonomyPortal
        //        .Hooks
        //        .GetEnumerationsForType(MediaType.Root);
        //    foreach (var it in descrTypes)
        //    {
        //        Description[] texts = TaxonomyPortal
        //            .Descriptions
        //            .GetDescriptionsForObjectCultureAndType(it.Id, cultrureId, MediaType.Text);
        //        if (texts != null)
        //        {
        //            if (texts.Length > 0)
        //                it.Title = texts[0].Title;
        //        }
        //    }
        //    return descrTypes;
        //}

        //#endregion

        //#region IBoutiqueProvider Members


        ///// <summary>
        ///// Gets the personal settings.
        ///// </summary>
        ///// <param name="userName">Name of the user.</param>
        ///// <returns>Setting.</returns>
        //public Setting GetPersonalSettings(string userName)
        //{
        //    var acc = AuthorizationPortal
        //                    .Accounts
        //                    .GetAccountForUser(userName);
        //    var req = new Setting
        //                {
        //                    AccountId = acc.Id
        //                };
        //    return TaxonomyPortal
        //        .Settings
        //        .GetSettings(req);
        //}

        //#endregion

        //#region IBoutique Members


        ///// <summary>
        ///// Gets the personal settings.
        ///// </summary>
        ///// <returns>Setting.</returns>
        //public Setting GetPersonalSettings()
        //{
        //    return GetPersonalSettings(WulkaContext.Current[WulkaContextKey.UserName]);
        //}

        ///// <summary>
        ///// Gets the tag object.
        ///// </summary>
        ///// <param name="objectId">The object id.</param>
        ///// <returns>Hook.</returns>
        ///// <exception cref="NotImplementedException"></exception>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Hook GetTagObject(string objectId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Saves the tag object.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <returns>Hook.</returns>
        ///// <exception cref="NotImplementedException"></exception>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Hook SaveTagObject(Hook it)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion


        ///// <summary>
        ///// Gets the applet info.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns>ApplicationFunction.</returns>
        //public ApplicationFunction GetAppletInfo(string appletId)
        //{
        //    return AuthorizationPortal
        //        .ApplicationFunctions
        //        .GetAppletInfo(appletId);
        //}


    }
}
