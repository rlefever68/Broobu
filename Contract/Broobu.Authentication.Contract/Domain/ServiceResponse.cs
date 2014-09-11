using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class ServiceResponse : DomainObject<ServiceResponse>
    {
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<ServiceResponse>.Validate(this, columnName);
        }

        protected override System.Collections.Generic.ICollection<string> Validate()
        {
            return DataErrorInfoValidator<ServiceResponse>.Validate(this);
        }
    }
}
