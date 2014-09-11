// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Contract
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-01-2014
// ***********************************************************************
// <copyright file="DescriptionItem.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;


namespace Broobu.ManageTaxo.Contract.Domain
{


    /// <summary>
    /// Class DescriptionItem.
    /// </summary>
    [DataContract]
    public class DescriptionItem : ViewItem, IDescriptionFilter
    {
        /// <summary>
        /// Gets or sets the type of the description.
        /// </summary>
        /// <value>The type of the description.</value>
        [DataMember]
        public string DescriptionType { get; set; }
        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture.</value>
        [DataMember]
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        [DataMember]
        public string ObjectId { get; set; }
        /// <summary>
        /// Gets or sets the culture identifier.
        /// </summary>
        /// <value>The culture identifier.</value>
        [DataMember]
        public string CultureId { get; set; }
        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [DataMember]
        public string TypeId { get; set; }
    }
}
