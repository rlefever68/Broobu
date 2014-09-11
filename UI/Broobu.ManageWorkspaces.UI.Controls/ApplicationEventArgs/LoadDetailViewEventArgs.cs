using System;
using System.Collections.Generic;
using Pms.ManageWorkspaces.Contract.Domain;

namespace Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs
{
    public class LoadDetailViewEventArgs : EventArgs
    {
        public IEnumerable<WorkspaceItem> ListItem { get; set; }
        public ListviewcontrolviewTypes CurrentViewType;
        public List<string> NewFolderString { get; set; }
        public bool BlnAddFolder { get; set; }
        public List<WorkspaceItem> ChildItems { get; set; }
        public int LisItemCount { get; set; }
        public int WorkspaceItemCount { get; set; }
        public bool IsRefresh { get; set; }

       public enum ListviewcontrolviewTypes
        {
            ListView,
            DetailView
        }
        

 
    }


}
