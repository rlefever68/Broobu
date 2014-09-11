using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using Broobu.Taxonomy.Contract;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class Account : TaxonomyObject<Account>, IAccount
    {
        public Account()
        {
            Active = 0;
            Image = Properties.Resources.male.ToByteArray();
        }







        /// <summary>
        ///     Gets or sets Account.Username, DbType: VarChar(50) NOT NULL.
        /// </summary>
        /// <value></value>
        [DataMember]
        [Required(ErrorMessage = "The value in column Username must not be NULL")]
        [StringLength(50, ErrorMessage = "The string length in column Username must not exceed 50")]
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets Account.Pwd, DbType: VarChar(255).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(255, ErrorMessage = "The string length in column Pwd must not exceed 255")]
        public string Pwd { get; set; }

        /// <summary>
        ///     Gets or sets Account.DtStart, DbType: DateTime.
        /// </summary>
        /// <value></value>
        [DataMember]
        public DateTime? DtStart { get; set; }

        /// <summary>
        ///     Gets or sets Account.DtEnd, DbType: DateTime.
        /// </summary>
        /// <value></value>
        [DataMember]
        public DateTime? DtEnd { get; set; }

        /// <summary>
        ///     Gets or sets Account.CardId, DbType: VarBinary(128).
        /// </summary>
        /// <value></value>
        [DataMember]
        public byte[] CardId { get; set; }

        /// <summary>
        ///     Gets or sets Account.Active, DbType: TinyInt NOT NULL.
        /// </summary>
        /// <value></value>
        [DataMember]
        public byte Active { get; set; }

        /// <summary>
        ///     Gets or sets Account.AuthModeId, DbType: VarChar(50).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(50, ErrorMessage = "The string length in column AuthModeId must not exceed 50")]
        public string AuthModeId { get; set; }

        /// <summary>
        ///     Gets or sets Account.FirstName, DbType: VarChar(50).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(50, ErrorMessage = "The string length in column FirstName must not exceed 50")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets Account.LastName, DbType: VarChar(50).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(50, ErrorMessage = "The string length in column LastName must not exceed 50")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets Account.MiddleName, DbType: VarChar(50).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(50, ErrorMessage = "The string length in column MiddleName must not exceed 50")]
        public string MiddleName { get; set; }

        /// <summary>
        ///     Gets or sets Account.Telephone1, DbType: VarChar(50).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(50, ErrorMessage = "The string length in column Telephone1 must not exceed 50")]
        public string Telephone1 { get; set; }

        /// <summary>
        ///     Gets or sets Account.Telephone2, DbType: VarChar(50).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(50, ErrorMessage = "The string length in column Telephone2 must not exceed 50")]
        public string Telephone2 { get; set; }

        /// <summary>
        ///     Gets or sets Account.Email, DbType: VarChar(255).
        /// </summary>
        /// <value></value>
        [DataMember]
        [StringLength(255, ErrorMessage = "The string length in column Email must not exceed 255")]
        public string Email { get; set; }

        /// <summary>
        ///     Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Account>.Validate(this, columnName);
        }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Account>.Validate(this);
        }

        /// <summary>
        ///     Gets or sets Account.SessionId, DbType: VarChar(50) NOT NULL.
        /// </summary>
        /// <value></value>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var target = (Account) obj;
            return
                ((Id == target.Id)
                 && (Username == target.Username)
                 && (Pwd == target.Pwd)
                 && (DtStart == target.DtStart)
                 && (DtEnd == target.DtEnd)
                 && (Active == target.Active)
                 && (AuthModeId == target.AuthModeId)
                 && (FirstName == target.FirstName)
                 && (LastName == target.LastName)
                 && (MiddleName == target.MiddleName)
                 && (Telephone1 == target.Telephone1)
                 && (Telephone2 == target.Telephone2)
                 && (Email == target.Email)
                 && (SessionId == target.SessionId)
                    );
        }

        public override int GetHashCode()
        {
            return
                (((Id == null) ? 0 : Id.GetHashCode())
                 ^ ((Username == null) ? 0 : Username.GetHashCode())
                 ^ ((Pwd == null) ? 0 : Pwd.GetHashCode())
                 ^ ((DtStart == null) ? 0 : DtStart.Value.GetHashCode())
                 ^ ((DtEnd == null) ? 0 : DtEnd.Value.GetHashCode())
                 ^ Active.GetHashCode()
                 ^ ((AuthModeId == null) ? 0 : AuthModeId.GetHashCode())
                 ^ ((FirstName == null) ? 0 : FirstName.GetHashCode())
                 ^ ((LastName == null) ? 0 : LastName.GetHashCode())
                 ^ ((MiddleName == null) ? 0 : MiddleName.GetHashCode())
                 ^ ((Telephone1 == null) ? 0 : Telephone1.GetHashCode())
                 ^ ((Telephone2 == null) ? 0 : Telephone2.GetHashCode())
                 ^ ((Email == null) ? 0 : Email.GetHashCode())
                 ^ ((SessionId == null) ? 0 : SessionId.GetHashCode())
                    );
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }


        protected override string GetDisplayName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}