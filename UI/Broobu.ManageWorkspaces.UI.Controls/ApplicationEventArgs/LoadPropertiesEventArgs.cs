using System;
using System.Collections.Generic;
using Pms.ManageWorkspaces.Contract.Domain;

namespace Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs
{
    public class LoadPropertiesEventArgs :EventArgs
    {
        public IEnumerable<WorkspaceItemProperty> WorkspaceItemProperties { get; set; }
        public string ItemId { get; set; }
    }
}
