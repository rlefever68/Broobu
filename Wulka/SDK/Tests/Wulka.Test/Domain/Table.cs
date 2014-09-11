// ***********************************************************************
// Assembly         : Iris.Fx.Test
// Author           : Rafael Lefever
// Created          : 02-03-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-24-2014
// ***********************************************************************
// <copyright file="Table.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Iris.Fx.Domain;
using Iris.Fx.Domain.Base;
using Iris.Fx.Validation;

namespace Iris.Fx.Test.Domain
{
    /// <summary>
    /// Class Table.
    /// </summary>
    public class Table : DomainObject<Table>
    {
        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        /// <value>The material.</value>
        [DataMember]
        public string Material { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [DataMember]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the chairs.
        /// </summary>
        /// <value>The chairs.</value>
        [DataMember]
        public Chair[] Chairs { get; set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        public Table()
        {
            Chairs = new Chair[] { };
        }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Table>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Table>.Validate(this);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendFormat("Chairs:\n");
            foreach (var chair in Chairs)
            {
                sb.AppendFormat(chair.ToString());
                sb.AppendFormat("\n");
            }
            return sb.ToString();
        }
    }
}