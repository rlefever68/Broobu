using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.ManageWorkspaces.Contract.Domain
{
    public class WorkspaceItemDescription : DomainObject<WorkspaceItemDescription>
    {
        public string ItemId { get; set; }
        public string CultureId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string TypeId { get; set; }
        public string AdditionalInfoUri { get; set; }

        public override string ToString()
        {
            string result = " ";

            result += "Id = '" + Id + "'; ";
            result += "ItemId = '" + ItemId + "'; ";
            result += "CultureId = '" + CultureId + "'; ";
            result += "Title = '" + Title + "'; ";
            result += "TypeId = '" + TypeId + "'; ";
            result += "AdditionalInfoUri = '" + AdditionalInfoUri + "'; ";

            return result;
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<WorkspaceItemDescription>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<WorkspaceItemDescription>.Validate(this);
        }
    }
}
