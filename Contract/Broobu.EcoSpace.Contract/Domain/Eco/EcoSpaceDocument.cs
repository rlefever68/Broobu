// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-12-2014
// ***********************************************************************
// <copyright file="EcoSpace.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.EcoSpace.Contract.Interfaces;
using Broobu.EcoSpace.Contract.Properties;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Eco
{
    /// <summary>
    /// Class EcoSpace.
    /// </summary>
    [DataContract]
    public class EcoSpaceDocument : TaxonomyObject<IDomainObject>,  IEcoSpaceDocument
    {

        /// <summary>
        /// The identifier
        /// </summary>
        public static string ID = WulkaContextDefault.EcoSpace;
        /// <summary>
        /// The guest eco space identifier
        /// </summary>
        public static string GuestEcoSpaceId = "GUEST_ECOSPACE";
        /// <summary>
        /// The _applets
        /// </summary>
        private AppletContainer _applets;
        /// <summary>
        /// The _roles
        /// </summary>
        private RoleContainer _roles;
        /// <summary>
        /// The _menu
        /// </summary>
        private MenuContainer _menu;
        /// <summary>
        /// The _menu applet links
        /// </summary>
        private MenuAppletLinkContainer _menuAppletLinks;
        /// <summary>
        /// The _role menu links
        /// </summary>
        private RoleMenuLinkContainer _roleMenuLinks;
        /// <summary>
        /// The _account role links
        /// </summary>
        private MembershipContainer _memberships;

        private IRole _selectedRole;

        

        

        /// <summary>
        /// Initializes a new instance of the <see cref="EcoSpaceDocument" /> class.
        /// </summary>
        public EcoSpaceDocument()
        {
           Icon = Resources.EcoSpace;
           ObjectIndex.Clear();
        }



        /// <summary>
        /// Gets or sets the applets.
        /// </summary>
        /// <value>The applets.</value>
        [DataMember]
        public AppletContainer Applets
        {
            get { return _applets; }
            set 
            { 
                _applets = value;
                _applets.Owner = this;
            }
        }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [DataMember]
        public RoleContainer Roles
        {
            get { return _roles; }
            set 
            { 
                _roles = value;
                _roles.Owner = this;
            }
        }

        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>The menu.</value>
        [DataMember]
        public MenuContainer Menu
        {
            get { return _menu; }
            set 
            { 
                _menu = value;
                _menu.Owner = this;
            }
        }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>The links.</value>
        [DataMember]
        public MenuAppletLinkContainer MenuAppletLinks
        {
            get { return _menuAppletLinks; }
            set 
            { 
                _menuAppletLinks = value;
                _menuAppletLinks.Owner = this;
            }
        }

        /// <summary>
        /// Gets or sets the role menu links.
        /// </summary>
        /// <value>The role menu links.</value>
        [DataMember]
        public RoleMenuLinkContainer RoleMenuLinks
        {
            get { return _roleMenuLinks; }
            set 
            { 
                _roleMenuLinks = value;
                _roleMenuLinks.Owner = this;
            }
        }

        




        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<EcoSpaceDocument>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<EcoSpaceDocument>.Validate(this);
        }

        /// <summary>
        /// Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        /// <summary>
        /// Gets the menu for user.
        /// </summary>
        /// <param name="userId">Name of the user.</param>
        /// <param name="userCulture">The user culture.</param>
        /// <returns>MenuContainer.</returns>
        public MenuContainer GetMenuForUser(string userId, string userCulture=null)
        {
            if (String.IsNullOrWhiteSpace(userCulture))
                userCulture = "en-US";
            // first, get all te roles where this user belongs to
            var lnk = new RoleMembership() { 
                SourceId=userId
            };
            var roleMemberships = EcoSpacePortal
                .EcoSpace
                .GetRoleMemberships(userId);
            var men = RoleMenuLinks.GetMenu(roleMemberships, userCulture);
            return Menu.Filter(men);
        }

        
        public IRole SelectedRole
        {
            get { return SelectedItem as IRole; }
            set { SelectedItem=value; RaisePropertyChanged("SelectedRole");}
        }
    }
}