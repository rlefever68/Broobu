using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.Authentication.Contract.Domain
{
    public interface IAccount : ITaxonomyObject
    {


        /// <summary>
        ///     Gets or sets Account.Username, DbType: VarChar(50) NOT NULL.
        /// </summary>
        /// <value></value>
        [DataMember]
        [Required(ErrorMessage = "The value in column Username must not be NULL")]
        [StringLength(50, ErrorMessage = "The string length in column Username must not exceed 50")]
        string Username { get; set; }

        /// <summary>
        ///     Gets or sets Account.DtStart, DbType: DateTime.
        /// </summary>
        /// <value></value>
        [DataMember]
        DateTime? DtStart { get; set; }

        /// <summary>
        ///     Gets or sets Account.DtEnd, DbType: DateTime.
        /// </summary>
        /// <value></value>
        [DataMember]
        DateTime? DtEnd { get; set; }

        /// <summary>
        ///     Gets or sets Account.CardId, DbType: VarBinary(128).
        /// </summary>
        /// <value></value>
        [DataMember]
        byte[] CardId { get; set; }

        /// <summary>
        ///     Gets or sets Account.Active, DbType: TinyInt NOT NULL.
        /// </summary>
        /// <value></value>
        [DataMember]
        byte Active { get; set; }

        /// <summary>
        ///     Gets or sets Account.Email, DbType: VarChar(255).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(255, ErrorMessage = "The string length in column Email must not exceed 255")]
        string Email { get; set; }

        
    }
}