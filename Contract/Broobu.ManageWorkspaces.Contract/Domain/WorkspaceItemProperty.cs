using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.ManageWorkspaces.Contract.Domain
{
    public class WorkspaceItemProperty : DomainObject<WorkspaceItemProperty>
    {
        public string ItemId { get; set; }
        public string PropertyTypeId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string AdditionalInfoUri { get; set; }
        public string PropertyTypeDescription { get; set; }

        public override string ToString()
        {
            string result = " ";

            result += "Id = '" + Id + "'; ";
            result += "ItemId = '" + ItemId + "'; ";
            result += "PropertyTypeId = '" + PropertyTypeId + "'; ";
            result += "PropertyName = '" + PropertyName + "'; ";
            result += "PropertyValue = '" + PropertyValue + "'; ";
            result += "AdditionalInfoUri = '" + AdditionalInfoUri + "'; ";
            result += "PropertyTypeDescription = '" + PropertyTypeDescription + "'; ";

            return result;
        }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<WorkspaceItemProperty>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<WorkspaceItemProperty>.Validate(this);
        }

    }
}
