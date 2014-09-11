// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : ON8RL
// Created          : 12-24-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-24-2013
// ***********************************************************************
// <copyright file="Description.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;

namespace Broobu.Taxonomy.Contract.Domain
{
    /// <summary>
    /// Class Description.
    /// </summary>
    [DataContract]
    public class Description : ComposedObject<Description>, IDescriptionFilter, IDescription
    {
        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [DataMember]
        public string TypeId { get; set; }


        [DataMember]
        public Description Type { get;set; }
    
        /// <summary>
        /// Gets or sets the culture identifier.
        /// </summary>
        /// <value>The culture identifier.</value>
        [DataMember]
        public string CultureId { get; set; }
        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        [DataMember]
        public string ObjectId { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [DataMember]
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the BLOB.
        /// </summary>
        /// <value>The BLOB.</value>
        [DataMember]
        public byte[] Blob { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string Title { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var result = string.Empty;

            result += "Id = '" + Id + "'; ";
            result += "TypeId = '" + TypeId + "'; ";
            result += "CultureId = '" + CultureId + "'; ";
            result += "ObjectId = '" + ObjectId + "'; ";
            result += "Url = '" + Url + "'; ";
            result += "BLOB = " + GetImageToString(Blob) + "; ";
            result += "Title = '" + Title + "'; ";
            result += "AdditionalInfoUri = '" + AdditionalInfoUri + "'; ";

            return result;
        }

        /// <summary>
        /// Gets the image to string.
        /// </summary>
        /// <param name="blob">The BLOB.</param>
        /// <returns>System.String.</returns>
        private static string GetImageToString(byte[] blob)
        {
            if (blob == null) return "<NULL>";
            return blob.Length == 0 ? "<EMPTY>" : "<BINARY DATA>";
        }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Description>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection{System.String}.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Description>.Validate(this);
        }

    }
}
