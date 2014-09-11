using System;
using System.Collections.Generic;
using Pms.ManageWorkspaces.Contract.Domain;

namespace Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs
{
    public class LoadDescriptionEventArgs:EventArgs
    {
        public IEnumerable<WorkspaceItemDescription> DescriptionListItem { get; set; }
        public string ItemId { get; set;}
    }
}
