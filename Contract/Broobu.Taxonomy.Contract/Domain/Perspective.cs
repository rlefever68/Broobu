using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Taxonomy.Contract.Domain
{
    [DataContract]
    public class Perspective : DomainObject<Perspective>
    {
        [DataMember]
        public string EnumerationId { get; set; }

        public override string ToString()
        {
            string result = string.Empty;
            result += "Id = '" + Id + "'; ";
            result += "ParentId = '" + ParentId + "'; ";
            result += "EnumerationId = '" + EnumerationId + "'; ";
            result += "AdditionalInfoUri = '" + AdditionalInfoUri + "'; ";

            return result;
        }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Perspective>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Perspective>.Validate(this);
        }
    }
}
