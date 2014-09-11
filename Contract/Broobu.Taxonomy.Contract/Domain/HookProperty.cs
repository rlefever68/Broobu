// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-12-2014
// ***********************************************************************
// <copyright file="HookProperty.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;


namespace Broobu.Taxonomy.Contract.Domain
{
    /// <summary>
    /// Class HookProperty.
    /// </summary>
    [DataContract]
    public abstract class HookProperty: DomainObject<HookProperty>, IHookProperty
    {
       
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the type identifier for the DataType of this property.
        /// </summary>
        /// <value>The type identifier.</value>
        [DataMember]
        public string TypeId { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [DataMember]
        public string Value { get; set; }

    }
}
