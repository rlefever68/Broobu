// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-15-2014
// ***********************************************************************
// <copyright file="MembershipContainer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    /// <summary>
    /// Class MembershipContainer.
    /// </summary>
    [DataContract]
    public class MembershipContainer : Folder
    {
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<MembershipContainer>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<MembershipContainer>.Validate(this);
        }


        /// <summary>
        /// The identifier
        /// </summary>
        public const string ID = "ACCOUNT_ROLE_LINK_CONTAINER";
        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipContainer"/> class.
        /// </summary>
        public MembershipContainer()
        {
            DisplayName = "Role Memberships";
            Id = ID;

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
        /// Gets the roles.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>RoleContainer.</returns>
        public RoleContainer GetRoles(string userName)
        {
            var res = new RoleContainer();
            
            return res;
        }

        /// <summary>
        /// Gets the account roles.
        /// </summary>
        /// <value>The account roles.</value>
        public IEnumerable<RoleMembership> Memberships {
            get 
            {
                return Parts.OfType<RoleMembership>();
            }
        }
    }
}
