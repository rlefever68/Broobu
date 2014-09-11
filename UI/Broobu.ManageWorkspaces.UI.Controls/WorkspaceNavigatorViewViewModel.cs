using System.Collections.ObjectModel;
using Pms.WorkspaceBrowser.Contract.Domain;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class WorkspaceNavigatorViewViewModel:WorkspaceBrowserViewModelBase
    {
        public bool PopUp;

        public new class Property
        {
            public const string WorkspaceItems = "WorkspaceItems";
        }

        public WorkspaceNavigatorViewViewModel()
        {
            Initialize();
        }

        protected override void InitializeInternal(object[] parameters)
        {
            EventBroker.SetPopUpFlag -= EventBroker_SetPopUpFlag;
            EventBroker.SetPopUpFlag += EventBroker_SetPopUpFlag;
            EventBroker.LoadWorkspaceItem -= EventBroker_LoadWorkspaceItem;
            EventBroker.LoadWorkspaceItem += EventBroker_LoadWorkspaceItem;
        }

        private void EventBroker_LoadWorkspaceItem(object sender, ApplicationEventArgs.LoadWorkspaceItemEventArgs e)
        {
            if(PopUp) return;
            WorkspaceItems = e.WorkspaceItems;
        }

        public void LoadPage()
        {
            EventBroker.SetPopUpFlag -= EventBroker_SetPopUpFlag;
            EventBroker.SetPopUpFlag += EventBroker_SetPopUpFlag;
            EventBroker.LoadWorkspaceItem -= EventBroker_LoadWorkspaceItem;
            EventBroker.LoadWorkspaceItem += EventBroker_LoadWorkspaceItem;
        }

        private void EventBroker_SetPopUpFlag(object sender, ApplicationEventArgs.LoadWorkspaceItemEventArgs e)
        {
            PopUp = e.PopUp;
        }

        /// <summary>
        /// Gets or sets the workspace items.
        /// </summary>
        /// <value>The workspace items.</value>
        private ObservableCollection<WorkspaceItem> _workspaceItems;
        public ObservableCollection<WorkspaceItem> WorkspaceItems
        {
            get
            {
                return _workspaceItems;
            }
            set
            {
                _workspaceItems = value;
                RaisePropertyChanged(Property.WorkspaceItems);

            }
        }

        private WorkspaceItem _selectedItem;
        public WorkspaceItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
            }
        }

        /// <summary>
        /// Occurs when click the ok button
        /// </summary>
        public void RaiseEvent()
        {
            EventBroker.RaiseLoadSearchFolder(new LoadWorkspaceItemEventArgs{SelectedItem = SelectedItem});
        }
    }

}
