// ***********************************************************************
// Assembly         : Broobu.Boutique.Business.Test
// Author           : Rafael Lefever
// Created          : 07-14-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-14-2014
// ***********************************************************************
// <copyright file="BoutiquesTestFixture.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
//using Broobu.Authorization.Contract.Domain;
using Broobu.Boutique.Business.Interfaces;
using Broobu.Boutique.Contract;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.Contract.Interfaces;
//using Broobu.Taxonomy.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Wulka.Core;
using Wulka.Domain;
using Wulka.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Boutique.Business.Test
{
    /// <summary>
    /// Class BoutiquesTestFixture.
    /// </summary>
    [TestClass]
    public class BoutiquesTestFixture : IBoutiques
    {
        /// <summary>
        /// Try_s the get boutique user information.
        /// </summary>
        [TestMethod]
        public void Try_GetUserEnvironmentInfo()
        {
            var res = GetUserEnvironmentInfo("raf@broobu.com");
            DomainSerializer<UserEnvironmentInfo>.SaveToJsonFile(@"c:\temp\ecospace\boutiqueinfo.json", res);
            var mnu = EcoSpaceFactory.MasterEcoSpace.Menu;
            DomainSerializer<MenuContainer>.SaveToJsonFile(@"c:\temp\ecospace\defaultmenu.json", mnu);
        }

        /// <summary>
        /// Gets the Boutique user info.
        /// </summary>
        /// <returns>UserEnvironmentInfo.</returns>
        public UserEnvironmentInfo GetUserEnvironmentInfo()
        {
            WulkaContext.Current.Add("UserName", "raf@broobu.com");
            return BoutiquePortal
                .Boutique
                .GetUserEnvironmentInfo();
        }

        ///// <summary>
        ///// Gets the descriptions for object.
        ///// </summary>
        ///// <param name="typeId">The type id.</param>
        ///// <param name="objectId">The object id.</param>
        ///// <param name="cultureId">The culture id.</param>
        ///// <returns>Description[].</returns>
        //public Description[] GetDescriptionsForObject(string typeId, string objectId, string cultureId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetDescriptionsForObject(typeId, objectId, cultureId);
        //}

        ///// <summary>
        ///// Gets the description types.
        ///// </summary>
        ///// <param name="cultrureId">The cultrure id.</param>
        ///// <returns>Hook[].</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Hook[] GetDescriptionTypes(string cultrureId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the personal settings.
        ///// </summary>
        ///// <returns>Setting.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Setting GetPersonalSettings()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the tag object.
        ///// </summary>
        ///// <param name="objectId">The object id.</param>
        ///// <returns>Hook.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Hook GetTagObject(string objectId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the applet menu.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns>BoutiqueMenuInfo.</returns>
        //public BoutiqueMenuInfo GetAppletMenu(string appletId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetAppletMenu(username,appletId)
        //}


        ///// <summary>
        ///// Gets the applet info.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns>ApplicationFunction.</returns>
        //public ApplicationFunction GetAppletInfo(string appletId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetAppletInfo(appletId);
        //}

        ///// <summary>
        ///// Registers the applet.
        ///// </summary>
        ///// <param name="applet">The applet.</param>
        ///// <returns>ApplicationFunction.</returns>
        //public ApplicationFunction RegisterApplet(ApplicationFunction applet)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .RegisterApplet(applet);
        //}

        ///// <summary>
        ///// Saves the tag object.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <returns>Hook.</returns>
        //public Hook SaveTagObject(Hook it)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .SaveTagObject(it);
        //}

        ///// <summary>
        ///// Saves the description.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>Description.</returns>
        //public Description SaveDescription(Description item)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .SaveDescription(item);
        //}

        ///// <summary>
        ///// Gets the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>Setting.</returns>
        //public Setting GetSettings(Setting item)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetSettings(item);
        //}

        ///// <summary>
        ///// Saves the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>Setting.</returns>
        //public Setting SaveSettings(Setting item)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .SaveSettings(item);
        //}

        

        /// <summary>
        /// Inflates the domain.
        /// </summary>
        public void InflateDomain()
        {
           BoutiqueProvider
                .Boutiques
                .InflateDomain();
        }

        public UserEnvironmentInfo GetUserEnvironmentInfo(string userName, string ecoSpaceId = null)
        {
            WulkaContext.Current = new WulkaContext();
            WulkaContext.Current.Add("UserName", userName);
            return BoutiquePortal
                .Boutique
                .GetUserEnvironmentInfo();
        }

        ///// <summary>
        ///// Gets the personal settings.
        ///// </summary>
        ///// <param name="userName">Name of the user.</param>
        ///// <returns>Setting.</returns>
        //public Setting GetPersonalSettings(string userName)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetPersonalSettings(userName);
        //}

        ///// <summary>
        ///// Gets the object.
        ///// </summary>
        ///// <param name="objectId">The object identifier.</param>
        ///// <returns>Hook.</returns>
        //public Hook GetObject(string objectId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetObject(objectId);
        //}

        /// <summary>
        /// Gets the applet menu.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="appletId">The applet identifier.</param>
        /// <returns>BoutiqueMenuInfo.</returns>
        public BoutiqueMenuInfo GetAppletMenu(string userName, string appletId)
        {
            return BoutiqueProvider
                .Boutiques
                .GetAppletMenu(userName, appletId);
        }

        ///// <summary>
        ///// Saves the object.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <returns>Hook.</returns>
        //public Hook SaveObject(Hook it)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .SaveObject(it);
        //}
    }
}
