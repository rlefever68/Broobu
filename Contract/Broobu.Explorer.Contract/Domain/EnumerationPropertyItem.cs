using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.Explorer.Contract.Domain
{
    [DataContract]
    public class EnumerationPropertyItem: DomainObject<EnumerationPropertyItem>
    {
        [DataMember]
        public String EnumerationId { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String TypeId { get; set; }
        [DataMember]
        public String Value { get; set; }
        [DataMember]
        public string AdditionalInfoUri { get; set; }

        public override string ToString()
        {
            string result = string.Empty;

            result += "Id = '" + Id + "'; ";
            result += "EnumerationId = '" + EnumerationId + "'; ";
            result += "Title = '" + Title + "'; ";
            result += "TypeId = '" + TypeId + "'; ";
            result += "Value = '" + Value + "'; ";
            result += "AdditionalInfoUri = '" + AdditionalInfoUri + "'; ";

            return result;
        }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<EnumerationPropertyItem>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<EnumerationPropertyItem>.Validate(this);
        }

    }
}
