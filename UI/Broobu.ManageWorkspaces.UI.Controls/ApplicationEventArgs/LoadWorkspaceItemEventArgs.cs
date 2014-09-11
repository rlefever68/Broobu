using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Controls;
using Pms.ManageWorkspaces.Contract.Domain;

namespace Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs
{
    public class LoadWorkspaceItemEventArgs:EventArgs
    {
        public ObservableCollection<WorkspaceItem> WorkspaceItems { get; set; }
        public string WorkspaceId { get; set; }
        public string ItemId { get; set; }
        public string SearchString { get; set; }
        public List<WorkspaceItem> PreviousListItem { get; set; }
        public bool PopUp { get; set; }
        public bool BlnLoad { get; set; }
        public WorkspaceItem SelectedItem { get; set; }
        public int SelectedIndex { get; set; }
        public WorkspaceItem BreadCrumbItem { get; set; }
        public TreeViewItem BreadCrumbtreeviewitem { get; set; }
        public TreeView Treeview { get; set; }
        public WorkspaceItem ModifyItem { get; set; }
        public bool TreeViewDropEnable { get; set; }
         
        public string ApplicationName { get; set; }
    }
}
