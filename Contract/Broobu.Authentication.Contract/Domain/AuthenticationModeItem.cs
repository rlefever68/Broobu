using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class AuthenticationModeItem : DomainObject<AuthenticationModeItem>
    {
        [DataMember]
        public string Title { get; set; }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AuthenticationModeItem>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AuthenticationModeItem>.Validate(this);
        }
    }
}
