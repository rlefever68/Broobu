// ***********************************************************************
// Assembly         : Iris.Fx.Test
// Author           : Rafael Lefever
// Created          : 02-03-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 02-03-2014
// ***********************************************************************
// <copyright file="DiningRoom.cs" company="Broobu">
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
    /// Class DiningRoom.
    /// </summary>
    [DataContract]
    public class DiningRoom : ComposedObject<DiningRoom>
    {

        public DiningRoom()
        {
            Tables = new Table[] { };
            Sideboards = new Sideboard[] { };
        }

        /// <summary>
        /// Gets or sets the tables.
        /// </summary>
        /// <value>The tables.</value>
        [DataMember]
        public Table[] Tables { get; set; }

        /// <summary>
        /// Gets or sets the sideboards.
        /// </summary>
        /// <value>The sideboards.</value>
        [DataMember]
        public Sideboard[] Sideboards { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        //public override string ToString()
        //{
        //    var s =  base.ToString();
        //    var sb = new StringBuilder(s);
        //    sb.AppendFormat("*************************************************\n");
        //    sb.AppendFormat("Tables for Dining Room : {0}\n", DisplayName);
        //    sb.AppendFormat("*************************************************\n");
        //    foreach (var table in Tables)
        //    {
        //        sb.AppendFormat("\n");
        //        sb.AppendFormat(table.ToString());
        //        sb.AppendFormat("\n");
        //    }
        //    sb.AppendFormat("*************************************************\n");
        //    sb.AppendFormat("Sideboards for Dining Room : {0}\n", DisplayName);
        //    sb.AppendFormat("*************************************************\n");
        //    foreach (var board in Sideboards)
        //    {
        //        sb.AppendFormat("\n");
        //        sb.AppendFormat(board.ToString());
        //        sb.AppendFormat("\n");
        //    }
        //    sb.AppendFormat("==============================================================\n\n");
        //    return sb.ToString();
        //}
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<DiningRoom>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<DiningRoom>.Validate(this);
        }
    }
}
