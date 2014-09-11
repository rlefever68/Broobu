// ***********************************************************************
// Assembly         : Broubu.Boutique.Contract
// Author           : Rafael Lefever
// Created          : 08-17-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-17-2014
// ***********************************************************************
// <copyright file="EcoSpaceMembership.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    /// <summary>
    /// Class EcoSpaceMembership.
    /// </summary>
    [DataContract]
    public class EcoSpaceMembership : Link, IEcoSpaceMembership
    {

        public EcoSpaceMembership()
        {
            RelationType = Relation;
        }
        
        
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<EcoSpaceMembership>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<EcoSpaceMembership>.Validate(this);
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
        /// Gets or sets the account.
        /// </summary>
        /// <value>The account.</value>
        public IAccount Account 
        {
            get { return base.Source as IAccount; }
            set { base.Source = value; } 
        }
        /// <summary>
        /// Gets or sets the eco space.
        /// </summary>
        /// <value>The eco space.</value>
        public IEcoSpaceDocument EcoSpace 
        {
            get { return base.Target as IEcoSpaceDocument; }
            set { base.Target = value; } 
        }

        public static string Relation = "AccountKnowsEcoSpace";


    }
}
