// ***********************************************************************
// Assembly         : Broobu.LATI.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="LocationLog.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.LATI.Contract.Domain
{
    /// <summary>
    /// Class LocationLog.
    /// </summary>
    [DataContract]
    public class LocationLog : DomainObject<LocationLog>
    {
        /// <summary>
        /// Gets or sets the po i identifier.
        /// </summary>
        /// <value>The po i identifier.</value>
        [DataMember]
        public string PoIId { get; set; }
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        [DataMember]
        public double Latitude { get; set; }
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        [DataMember]
        public double Longitude { get; set; }
        /// <summary>
        /// Gets or sets the accuracy.
        /// </summary>
        /// <value>The accuracy.</value>
        [DataMember]
        public float Accuracy { get; set; }
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// <value>The altitude.</value>
        [DataMember]
        public double Altitude { get; set; }
        /// <summary>
        /// Gets or sets the bearing.
        /// </summary>
        /// <value>The bearing.</value>
        [DataMember]
        public float Bearing { get; set; }
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        [DataMember]
        public float Speed { get; set; }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<LocationLog>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<LocationLog>.Validate(this);
        }
    }
}
