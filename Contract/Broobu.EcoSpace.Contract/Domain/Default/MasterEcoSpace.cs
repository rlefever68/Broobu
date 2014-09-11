// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="DefaultEcoSpace.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Wulka.Validation;


namespace Broobu.EcoSpace.Contract.Domain.Default
{
    /// <summary>
    /// Class DefaultEcoSpace.
    /// </summary>
    [DataContract]
    public class MasterEcoSpace : EcoSpaceDocument
    {
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<MasterEcoSpace>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<MasterEcoSpace>.Validate(this);
        }


        public new static string ID = "MASTER_ECOSPACE";

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterEcoSpace"/> class.
        /// </summary>
        public MasterEcoSpace()
        {
            Id = ID;
            DisplayName = "Master EcoSpace";
            Applets = CreateMasterAppletContainer();
            Roles = CreateMasterRolesContainer();
            Menu = CreateMasterMenuContainer();
            MenuAppletLinks = new MenuAppletLinkContainer();
            RoleMenuLinks = new RoleMenuLinkContainer();
        }


        private static MenuContainer CreateMasterMenuContainer()
        {
            var res = new MenuContainer();
            {
                res.AddPart(new ManageCloudSpaceMenuButton());
                res.AddPart(new MonitorCloudMenuButton());
                res.AddPart(new LearnMoreMenuButton());
            }
            return res;
        }


        private static RoleContainer CreateMasterRolesContainer()
        {
            var res = new RoleContainer();
            {
                var sf = new SystemRolesFolder();
                {
                    var ar = new RootRole();
                    sf.AddPart(ar);
                    var gr = new GuestRole();
                    sf.AddPart(gr);
                    var rr = new RegisteredRole();
                    sf.AddPart(rr);
                }
                res.AddPart(sf);
                var cf = new OrganizationRoleFolder();
                {
                    var of = new Organization() { DisplayName = "Broobu" };
                    {}
                    cf.AddPart(of);
                }
                res.AddPart(cf);
            }
            return res;
        }
        
        
        private static AppletContainer CreateMasterAppletContainer()
        {
            var res = new AppletContainer();
            {
                var systemAppletFolder = new SystemAppletFolder();
                {
                    systemAppletFolder.AddPart(new MonitorCloudApplet());
                    systemAppletFolder.AddPart(new ManageCloudApplet());
                    systemAppletFolder.AddPart(new BrowseWebApplet());

                }
                res.AddPart(systemAppletFolder);
            }
            return res;
        }

    }
}
