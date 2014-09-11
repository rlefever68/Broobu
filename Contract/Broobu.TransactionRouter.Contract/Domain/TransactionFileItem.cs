using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.TransactionRouter.Contract.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [DataContract]
    public class TransactionFileItem : DomainObject<TransactionFileItem>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is zip.
        /// </summary>
        /// <value><c>true</c> if this instance is zip; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        [DataMember]
        public bool IsZip { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        /// <remarks></remarks>
        [DataMember]
        public byte[] File { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        /// <remarks></remarks>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<TransactionFileItem>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<TransactionFileItem>.Validate(this);
        }
    }
}
