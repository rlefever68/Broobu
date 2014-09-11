// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 08-11-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-15-2014
// ***********************************************************************
// <copyright file="EcoSpaceFactory.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Default;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.EcoSpace.Contract.Properties;
using Wulka.Domain.Interfaces;


namespace Broobu.EcoSpace.Contract.Domain
{
    /// <summary>
    /// Class EcoSpaceGenerator.
    /// </summary>
    public class EcoSpaceFactory
    {

        /// <summary>
        /// Gets the default eco space.
        /// </summary>
        /// <value>The default eco space.</value>
        public static EcoSpaceDocument MasterEcoSpace
        {
            get { return CreateMasterEcoSpace(); }
        }

        /// <summary>
        /// Gets the guest eco space.
        /// </summary>
        /// <value>The guest eco space.</value>
        public static EcoSpaceDocument GuestEcoSpace 
        {
            get { return CreateGuestEcoSpace(); }
        }

        /// <summary>
        /// Creates the guest eco space.
        /// </summary>
        /// <returns>EcoSpaceDocument.</returns>
        private static EcoSpaceDocument CreateGuestEcoSpace()
        {
            var res = new EcoSpaceDocument
            {
                Id = EcoSpaceDocument.GuestEcoSpaceId,
                DisplayName = "Guest Cloudscape",
                Applets = new AppletContainer(),
                Roles = new RoleContainer(),
                Menu = CreateGuestMenuContainer(),
                MenuAppletLinks = new MenuAppletLinkContainer(),
                RoleMenuLinks = new RoleMenuLinkContainer()
            };
            return res;
        }

        /// <summary>
        /// Creates the guest menu container.
        /// </summary>
        /// <returns>MenuContainer.</returns>
        private static MenuContainer CreateGuestMenuContainer()
        {
            var res = new MenuContainer();
            {
                res.AddPart(new MonitorCloudMenuButton());
                res.AddPart(new LearnMoreMenuButton());
                res.AddPart(new BrowseWebMenuButton());
            }
            return res;
        }

        /// <summary>
        /// Creates the default eco space.
        /// </summary>
        /// <returns>EcoSpaceDocument.</returns>
        private static EcoSpaceDocument CreateMasterEcoSpace()
        {
            return new MasterEcoSpace();
        }

        /// <summary>
        /// Creates the menu container.
        /// </summary>
        /// <returns>MenuContainer.</returns>
        /*  private static MenuContainer CreateMenuContainer()
        {
            var res = new MenuContainer();
            {
                var platformPgCat = new PlatformPageCategory();
                {
                    var dptp = new DefaultPlatformToolsPage();
                    {
                        dptp.AddDefaultPageGroupButton(new ManageCloudSpaceMenuButton());
                        dptp.AddDefaultPageGroupButton(new MonitorCloudMenuButton());
                    }
                    platformPgCat.AddPart(dptp);
                }
                res.AddPart(platformPgCat);
                var cloudPgCat = new PageCategory() { DisplayName = "Business Applications", Id = "CAT_CLOUD" };
                {
                    var pg = new Page() { DisplayName = "Insoft", Id = "PG_INSOFT" };
                    {
                        pg.AddDefaultPageGroupButton(new MenuButton() { DisplayName = "Your Cloud App Here!" });
                    }
                    cloudPgCat.AddPart(pg);
                    var pg1 = new Page() { DisplayName = "CC4ID", Id = "PG_CC4ID" };
                    {
                        pg1.AddDefaultPageGroupButton(new MenuButton() { Id = "MB_TEMA_COST_CALCULATION", AppletId = CC4IDConst.TemaCostCalculator.AppletId });
                    }
                    cloudPgCat.AddPart(pg1);
                }
                res.AddPart(cloudPgCat);
            }

            

            
            return res;
        } */

    

        /// <summary>
        /// Creates the roles container.
        /// </summary>
        /// <returns>RoleContainer.</returns>
  

    
    }
}