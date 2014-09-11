using System.Runtime.Serialization;

using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class LogonResponse : DomainObject<LogonResponse>
    {

        [DataMember] 
        public bool IsAuthenticated;

        [DataMember]
        public WulkaSession Session;

        [DataMember]
        public int SessionTimeout;

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<LogonResponse>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override System.Collections.Generic.ICollection<string> Validate()
        {
            return DataErrorInfoValidator<LogonResponse>.Validate(this);
        }
    }
}