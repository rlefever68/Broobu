using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.Explorer.Contract.Domain
{
    [DataContract]
    public class EnumerationItem : DomainObject<EnumerationItem>
    {

        [DataMember]
        public string AdditionalInfoUri { get; set; }
        [DataMember]
        public int SortOrder { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String TypeId { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }

        public override string ToString()
        {
            string result = string.Empty;

            result += "Id = '" + Id + "'; ";
            result += "SortOrder = " + SortOrder + "; ";
            result += "Title = '" + Title + "'; ";
            result += "TypeId = '" + TypeId + "'; ";
            result += "Image = " + GetImageToString(Image) + "; ";
            result += "DateModified = #" + DateModified + "#; ";
            result += "AdditionalInfoUri = '" + AdditionalInfoUri + "'; ";

            return result;
        }

        private string GetImageToString(byte[] image)
        {
            if (image == null) return "<NULL>";
            if (image.Length == 0) return "<EMPTY>";
            return "<BINARY DATA>";
        }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<EnumerationItem>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<EnumerationItem>.Validate(this);
        }
    }
}