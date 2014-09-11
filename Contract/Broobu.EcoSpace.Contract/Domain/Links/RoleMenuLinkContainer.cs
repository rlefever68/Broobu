// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-11-2014
// ***********************************************************************
// <copyright file="RoleMenuLinkContainer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    /// <summary>
    /// Class RoleMenuLinkContainer.
    /// </summary>
    [DataContract]
    public class RoleMenuLinkContainer : Folder
    {

        /// <summary>
        /// Gets the role menus.
        /// </summary>
        /// <value>The role menus.</value>
        public IEnumerable<IRoleMenuLink> RoleMenus
        {
            get { return Parts.OfType<IRoleMenuLink>(); }
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
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<RoleMenuLinkContainer>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<RoleMenuLinkContainer>.Validate(this);
        }


        /// <summary>
        /// The identifier
        /// </summary>
        public const string ID = "ROLE_MENU_LINK_CONTAINER";
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleMenuLinkContainer"/> class.
        /// </summary>
        public RoleMenuLinkContainer()
        {
            Id = ID;
            DisplayName = "Role Permissions";
        }


        /// <summary>
        /// Gets the menu.
        /// </summary>
        /// <param name="userRoles">The user roles.</param>
        /// <param name="userCulture">The user culture.</param>
        /// <returns>MenuContainer.</returns>
        public MenuContainer GetMenu(RoleContainer userRoles, string userCulture)
        {
            var res = new MenuContainer();
            foreach (var roleMenuLink in RoleMenus
                .Where(x => userRoles.ContainsRole(x.Role)))
            {
                res.AddMenuButton(roleMenuLink.Button);
            }
            return res;
        }
    }
}