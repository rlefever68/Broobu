using System.Collections.Generic;
using System.Runtime.Serialization;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.Explorer.Contract.Domain
{
    [DataContract]
    public class EnumerationLinkItem : DomainObject<EnumerationLinkItem>
    {
        [DataMember]
        public string AdditionalInfoUri { get; set; }
        [DataMember]
        public string SourceId { get; set; }
        [DataMember]
        public string TargetId { get; set; }
        [DataMember]
        public string TypeId { get; set; }

        public override string ToString()
        {
            string result = string.Empty;

            result += "Id = '" + Id + "'; ";
            result += "SourceId = '" + SourceId + "'; ";
            result += "TargetId = '" + TargetId + "'; ";
            result += "TypeId = '" + TypeId + "'; ";
            result += "AdditionalInfoUri = '" + AdditionalInfoUri + "'; ";

            return result;
        }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<EnumerationLinkItem>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<EnumerationLinkItem>.Validate(this);
        }
    }
}
