using System.Collections.Generic;
using System.Runtime.Serialization;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.Explorer.Contract.Domain
{
    [DataContract]
    public class PerspectiveItem : DomainObject<PerspectiveItem>
    {
        [DataMember]
        public string AdditionalInfoUri { get; set; }
        [DataMember]
        public string EnumerationId { get; set; }
        [DataMember]
        public string ParentId { get; set; }

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
            return DataErrorInfoValidator<PerspectiveItem>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<PerspectiveItem>.Validate(this);
        }
    }
}
