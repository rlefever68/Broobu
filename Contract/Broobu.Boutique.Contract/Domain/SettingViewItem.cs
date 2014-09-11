using System;
using Pms.Framework.Domain;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Pms.Framework.Validation;

namespace Pms.Shell.Contract.Domain
{
    [DataContract]
    public class SettingViewItem : DomainObject<SettingViewItem>
    {
        [DataMember]
        public string ApplicationId { get; set; }
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public XElement Settings { get; set; }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<SettingViewItem>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override System.Collections.Generic.ICollection<string> Validate()
        {
            return DataErrorInfoValidator<SettingViewItem>.Validate(this);
        }
    }
}
