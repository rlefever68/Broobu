// ***********************************************************************
// Assembly         : Broobu.Boutique.Contract.Test
// Author           : ON8RL
// Created          : 12-03-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-03-2013
// ***********************************************************************
// <copyright file="BoutiqueTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.Contract.Interfaces;
using Broobu.EcoSpace.Contract.Domain.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Domain.Authentication;
using Wulka.Test;

namespace Broobu.Boutique.Contract.Test
{
    /// <summary>
    /// Class BoutiqueTestFixture.
    /// </summary>
    [TestClass]
    public class BoutiqueTestFixture : ServiceTestFixtureBase, IBoutiqueAgent
    {


        /// <summary>
        /// Occurs when [get Boutique user info completed].
        /// </summary>
        public event Action<UserEnvironmentInfo> GetUserEnvironmentInfoCompleted;

        /// <summary>
        /// Gets the Boutique user info async.
        /// </summary>
        /// <param name="act">The act.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void GetUserEnvironmentInfoAsync(Action<UserEnvironmentInfo> act = null)
        {
            BoutiquePortal
                .Boutique
                .GetUserEnvironmentInfoAsync(act);
        }

        ///// <summary>
        ///// Saves the settings async.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <param name="action">The action.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public void SaveSettingsAsync(Setting item, Action<Setting> action)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the settings async.
        ///// </summary>
        ///// <param name="req">The req.</param>
        ///// <param name="action">The action.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public void GetSettingsAsync(Setting req, Action<Setting> action)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the tag object async.
        ///// </summary>
        ///// <param name="objectId">The object id.</param>
        ///// <param name="act">The act.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public void GetTagObjectAsync(string objectId, Action<Hook> act = null)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Saves the tag object async.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <param name="act">The act.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public void SaveTagObjectAsync(Hook it, Action<Hook> act = null)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the applet menu async.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <param name="act">The act.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public void GetAppletMenuAsync(string appletId, Action<Domain.BoutiqueMenuInfo> act = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RegisterAppletAsync(ApplicationFunction info, Action onAppletRegistered)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Registers the applet async.
        ///// </summary>
        ///// <param name="info">The info.</param>
        ///// <param name="onAppletRegistered">The on applet registered.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public void RegisterAppletAsync(ApplicationFunction info, Action<ApplicationFunction> onAppletRegistered)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Gets the Boutique user info.
        /// </summary>
        /// <returns>Domain.UserEnvironmentInfo.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public UserEnvironmentInfo GetUserEnvironmentInfo()
        {
            return BoutiquePortal
                .Boutique
                .GetUserEnvironmentInfo();
        }


        ///// <summary>
        ///// Saves the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>SettingItem.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Setting SaveSettings(Setting item)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>SettingItem.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Setting GetSettings(Setting item)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the descriptions for object.
        ///// </summary>
        ///// <param name="typeId">The type id.</param>
        ///// <param name="objectId">The object id.</param>
        ///// <param name="cultureId">The culture id.</param>
        ///// <returns>Description[][].</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Description[] GetDescriptionsForObject(string typeId, string objectId, string cultureId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Saves the description.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>Description.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Description SaveDescription(Description item)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the description types.
        ///// </summary>
        ///// <param name="cultrureId">The cultrure id.</param>
        ///// <returns>Enumeration[][].</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Hook[] GetDescriptionTypes(string cultrureId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the personal settings.
        ///// </summary>
        ///// <returns>SettingItem.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Setting GetPersonalSettings()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets the tag object.
        ///// </summary>
        ///// <param name="objectId">The object id.</param>
        ///// <returns>Enumeration.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Hook GetTagObject(string objectId)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Saves the tag object.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <returns>Enumeration.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public Hook SaveTagObject(Hook it)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Gets the applet menu.
        /// </summary>
        /// <param name="appletId">The applet id.</param>
        /// <returns>Domain.BoutiqueMenuInfo.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Domain.BoutiqueMenuInfo GetAppletMenu(string appletId)
        {
            throw new NotImplementedException();
        }


        //public ApplicationFunction RegisterApplet(ApplicationFunction applet)
        //{
        //    throw new NotImplementedException();
        //}

       

        ///// <summary>
        ///// Gets the applet info.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns>ApplicationFunctionItem.</returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public ApplicationFunction GetAppletInfo(string appletId)
        //{
        //    throw new NotImplementedException();
        //}



        [TestMethod]
        public void Try_GetBoutiqueGuestUserMenu()
        {
            WulkaSession.Current = SessionFactory.CreateDefaultWulkaSession();
            var res = GetUserEnvironmentInfo();
            Console.WriteLine(res);
        }


        protected override string GetContractType()
        {
            return String.Format("{0}:IBoutiqueSentry", BoutiqueServiceConst.Namespace);
        }


        [TestMethod]
        public override void Try_GetServiceEndpoints()
        {
            base.Try_GetServiceEndpoints();
        }



    }

}
