// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="RelationItem.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.Media.Contract.Domain
{
    /// <summary>
    /// Class RelationItem.
    /// </summary>
    [DataContract]
    public class LinkItem : DomainObject<LinkItem>
    {

        /// <summary>
        /// Gets or sets the type of the relation.
        /// </summary>
        /// <value>The type of the relation.</value>
        [DataMember]
        public string RelationType {get; set;}

        /// <summary>
        /// Gets or sets the relation from.
        /// </summary>
        /// <value>The relation from.</value>
        [DataMember]
        public string RelationFrom { get; set; }

        /// <summary>
        /// Gets or sets the relation to.
        /// </summary>
        /// <value>The relation to.</value>
        [DataMember]
        public string RelationTo { get; set; }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<LinkItem>.Validate(this,columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection{System.String}.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<LinkItem>.Validate(this);
        }
    }
}
