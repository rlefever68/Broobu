// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="Role.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Properties;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    /// <summary>
    /// Class Role.
    /// </summary>
    [DataContract]
    public class Role : EcoObject<Role>, IRole
    {



        public new IEcoSpaceDocument MasterDoc
        {
            get { return base.MasterDoc as IEcoSpaceDocument; }
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
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        public Role()
        {
            Icon = Resources.Role;
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Role>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Role>.Validate(this);
        }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <value>The permissions.</value>
        public IEnumerable<ILink> Permissions {
            get {
                return Parts.OfType<PermissionLink>();
            }
        }
        /// <summary>
        /// Adds the permission.
        /// </summary>
        /// <param name="applet">The applet.</param>
        /// <returns>ILink.</returns>
        public ILink AddPermission(ICloudApplet applet)
        {
            return AddPart(new PermissionLink(applet,this)) as ILink;
        }

        /// <summary>
        /// Removes the permission.
        /// </summary>
        /// <param name="applet">The applet.</param>
        public void RemovePermission(ICloudApplet applet)
        {
            if (Permissions.All(x => x.TargetId != applet.Id)) return;
            var p = Permissions.First(x => x.TargetId == applet.Id);
            RemovePart(p);
        }

        /// <summary>
        /// Gets the memberships.
        /// </summary>
        /// <value>The memberships.</value>
        public IEnumerable<ILink> Memberships {
            get {
                return Parts.OfType<RoleMembership>();
            }
        }


        /// <summary>
        /// Adds the membership.
        /// </summary>
        /// <param name="membership">The account.</param>
        /// <returns>ILink.</returns>
        public IRoleMembership AddMembership(IRoleMembership membership)
        {
            membership.Source = this;
            var res = AddPart(membership) as IRoleMembership;
            return res;
        }

        /// <summary>
        /// Removes the membership.
        /// </summary>
        /// <param name="account">The account.</param>
        public void RemoveMembership(IAccount account)
        {
            if (Memberships.All(x => x.TargetId != account.Id)) return;
            var p = Permissions.First(x => x.TargetId == account.Id);
            RemovePart(p);
        }



        protected override Wulka.Domain.Interfaces.IDomainObject CreateChild()
        {
            return new Role() { DisplayName = "New Role" };
        }

    }
}