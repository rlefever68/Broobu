// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-20-2014
// ***********************************************************************
// <copyright file="AccountRoleLink.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.Authentication.Contract;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.EcoSpace.Contract.Interfaces;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    /// <summary>
    /// Class AccountRoleLink.
    /// </summary>
    [DataContract]
    public class RoleMembership : Link, IRoleMembership
    {



        /// <summary>
        /// Initializes a new instance of the <see cref="RoleMembership"/> class.
        /// </summary>
        /// <param name="membership">The account.</param>
        /// <param name="role">The role.</param>
        /// <exception cref="System.Exception">
        /// Account pointer is null.
        /// or
        /// Role pointer is null
        /// </exception>
        public RoleMembership(IEcoSpaceMembership membership, IRole role)
        {
            if(membership==null)
                throw new Exception("Membership pointer is null.");
            if (role == null)
                throw new Exception("Role pointer is null");
            RelationType = Relation;
        }


        public RoleMembership()
        {
            RelationType = Relation;
        }

        public const string Relation = "IsActedBy";


        public IAccount Account
        {
            get
            {
                return base.Target as IAccount;
            }
            set
            {
                base.Target = value;
            }
        }

        
        public IRole Role
        {
            get
            {
                return base.Source as IRole;
            }
            set
            {
                base.Source = value;
            }
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<RoleMembership>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<RoleMembership>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

       
    }
}
