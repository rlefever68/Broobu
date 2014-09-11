// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Contract
// Author           : Rafael Lefever
// Created          : 05-04-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-05-2014
// ***********************************************************************
// <copyright file="HookItem.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;

using Broobu.Taxonomy.Contract.Domain;


namespace Broobu.ManageTaxo.Contract.Domain
{
    /// <summary>
    /// Class HookItem.
    /// </summary>
    [DataContract]
    public class HookItem : ViewItem
    {

        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [DataMember]
        public string TypeId { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        [DataMember]
        public HookItem[] Children { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        [DataMember]
        public string ObjectId { get; set; }

    }
}
