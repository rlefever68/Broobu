using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.ManageWorkspaces.Contract.Domain
{
    [DataContract]
    public class WorkspaceItem : DomainObject<WorkspaceItem>
    {
        [DataMember]
        public string ParentId { get; set; }
        [DataMember]
        public string ParentTitle { get; set; }
        [DataMember]
        public string ItemId { get; set; }
        [DataMember]
        public string ItemTitle { get; set; }
        [DataMember]
        public byte[] ItemImage { get; set; }
        [DataMember]
        public string TypeId { get; set; }
        [DataMember]
        public string TypeTitle { get; set; }
        [DataMember]
        public byte[] TypeImage { get; set; }
        [DataMember]
        public int SortOrder { get; set; }
        [DataMember]
        public WorkspaceItemDescription[] Descriptions { get; set; }
        [DataMember]
        public WorkspaceItemProperty[] Properties { get; set; }
        [DataMember]
        public bool IsFolder { get; set; }
        [DataMember]
        public WorkspaceItem[] Children { get; set; }
        [DataMember]
        public string AdditionalInfoUri { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }

        public override string ToString()
        {
            string result = " ";

            result += "Id = '" + Id + "'; ";
            result += "ParentId = '" + ParentId + "'; ";
            result += "ItemId = '" + ItemId + "'; ";
            result += "ItemTitle = '" + ItemTitle + "'; ";
            result += "TypeId = '" + TypeId + "'; ";
            result += "TypeTitle = '" + TypeTitle + "'; ";
            result += "SortOrder = " + SortOrder + "; ";
            result += "IsFolder = " + IsFolder + "; ";
            result += "DateModified = #" + DateModified + "#; ";

            return result;
        }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<WorkspaceItem>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<WorkspaceItem>.Validate(this);
        }

    }
}
