using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Result;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.Converters;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class WorkspaceListViewViewModel : WorkspaceBrowserViewModelBase
    {
        #region Class fields/members

        public bool PopUp;
        public Boolean BlnAddFolder;
        //public ICommand Newitem { get; set; }
        public ListView ListViewControl { get; set; }
        /// <summary>
        /// Declare Constants
        /// </summary>
        public new class Property
        {
            public const string ListItem = "ListItem";
            public const string NewFolderString = "NewFolderString";
            public const string SelectedItem = "SelectedItem";
            public const string PreviousListItem = "PreviousListItem";
            public const string SelectedIndex = "SelectedIndex";
            public const string DeletedListItems = "DeletedListItems";
            // public const string IsRefreshing = "IsRefreshing";
            // public const string IsEmpty = "IsEmpty";
        }

        #endregion

        # region ICommand Events

        /// <summary>
        /// Occurs when "New Item" is clicked
        /// </summary>
        private static void BtnnewitemClickEvent()
        {
            WindowManager.ShowAddItemScreen(null, null, null, Constants.ViewNames.AddItem);

            //AddItemViewModel AddItemVM = new AddItemViewModel();
            //AddItemVM.HandleIsEnableProperty(Constants.ViewNames.AddItem);
            //var addItem = new AddItem();
            //addItem.Initialize(AddItemVM);
            //addItem.ShowDialog();

            // var additem = new AddItem
            // {
            //     ApplicationName = Constants.ViewNames.AddItem,
            //     //ProcessFrom = Constants.ViewNames.AddItem,
            //     txtparentworkspace = { IsEnabled = false }
            // };
            //// additem.Vm.ProcessFrom = Constants.ViewNames.AddItem;
            // additem.ShowDialog();
        }

        /// <summary>
        ///  Calls the Asynchronous method to get Workspace Item  
        /// </summary>
        private void GetWorkspaceAsyncItem()
        {
            if ((SelectedItem.Children != null) && SelectedItem.Children.Length > 0)
            {
                NewFolderString = new List<string>();
                EventBroker.RaiseGetModifyItem(new LoadWorkspaceItemEventArgs { ModifyItem = SelectedItem });
                EventBroker.RaiseDoubleClickListView(new LoadWorkspaceItemEventArgs { ItemId = SelectedItem.Id });
            }

        }

        /// <summary>
        /// Occurs when Listview Item Selection is changed
        /// </summary>
        private void ListViewSelectionChanged()
        {
            if (NewFolderString == null)
                NewFolderString = new List<string>();
            if ((SelectedItem != null))
            {
                EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs
                {
                    ItemId = SelectedItem.ItemId,
                    SelectedItem = SelectedItem,
                    SelectedIndex = SelectedIndex
                });
                ConvertItemHelper.CurrentItemId = SelectedItem.ItemId;
            }
        }

        # endregion

        #region Properties



        /// <summary>
        /// Gets and Sets ListItem Data
        /// </summary>
        private IEnumerable<WorkspaceItem> _listItem;
        public IEnumerable<WorkspaceItem> ListItem
        {
            get
            {
                return _listItem;
            }
            set
            {
                _listItem = value;
                if (_listItem.Count() <= 0) return;
                CheckAndPutImage();
                var searchworkspace = new WorkspaceItem { Children = _listItem.ToArray() };
                PreviousListItem.Add(searchworkspace);
                if (PreviousListItem.Count > 1)
                    if (PreviousListItem[PreviousListItem.Count - 2].Children[0].Id == _listItem.ToList()[0].Id)
                        PreviousListItem.Remove(searchworkspace);
                EventBroker.RaiseGetPreviousListItem(new LoadWorkspaceItemEventArgs { PreviousListItem = PreviousListItem });
                EventBroker.RaiseGetListItem(new LoadDetailViewEventArgs { ListItem = value });
                RaisePropertyChanged(Property.ListItem);
            }
        }

        private void CheckAndPutImage()
        {
            if (_listItem == null) return;
            foreach (var item in _listItem.Where(item => item.ItemImage == null || item.ItemImage.Length == 0))
            {
                item.ItemImage = GetLocalItemImageForBreadCrumb();
            }
        }

        /// <summary>
        /// A Method that will be called when no item image is found
        /// </summary>
        /// <returns>A Byte array that contains Image data</returns>
        private static byte[] GetLocalItemImageForBreadCrumb()
        {
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource =
                new Uri(
                    "pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/DefaultFolder.png",
                    UriKind.RelativeOrAbsolute);
            bmp.EndInit();
            MemoryStream memStream = null;
            try
            {
                memStream = new MemoryStream();
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(memStream);
                return memStream.GetBuffer();
            }
            finally
            {
                if (memStream != null) memStream.Close();
            }
        }

        /// <summary>
        /// VisibilityListOrDetailView property
        /// </summary>
        public bool VisibilityListOrDetailView { get; set; }

        /// <summary>
        /// Gets or sets the selectedItem
        /// </summary>
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
                RaisePropertyChanged(Property.SelectedItem);

                // RenameListItem = value;
                // EventBroker.RaiseGetSearchString(new LoadWorkspaceItemEventArgs { SearchString = string.Empty });
                EventBroker.RaiseSelectedItemChange(new LoadWorkspaceItemEventArgs { SelectedItem = SelectedItem, SelectedIndex = SelectedIndex });
            }
        }



        /// <summary>
        /// Gets or Sets the PreviousListItem
        /// </summary>
        private List<WorkspaceItem> _perviouslistitem;
        public List<WorkspaceItem> PreviousListItem
        {
            get
            {
                return _perviouslistitem;
            }
            set
            {
                _perviouslistitem = value;
                RaisePropertyChanged(Property.PreviousListItem);
            }
        }

        /// <summary>
        /// Gets or sets the SelectedIndex.
        /// </summary>
        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged(Property.SelectedIndex);
            }
        }

        /// <summary>
        /// Gets and Sets the Folder Caption
        /// </summary>
        private List<string> _newFolderString;
        public List<string> NewFolderString
        {
            get
            {
                return _newFolderString;
            }
            set
            {
                _newFolderString = value;
                RaisePropertyChanged(Property.NewFolderString);
            }
        }


        /// <summary>
        /// Gets or sets the DeleteWorkspaceItem with callback
        /// </summary>
        private WorkspaceItem _deleteListItem;
        public WorkspaceItem DeleteListItem
        {
            get
            {
                return _deleteListItem;

            }
            set
            {
                _deleteListItem = value;
                Action<WorkspaceItemResult<WorkspaceItem>> action = OnDeleteWorkSpaceItemCompleted;
                CreateAgent().DeleteWorkSpaceItemAsync(DeleteListItem, action);
            }
        }
        /// <summary>
        /// Gets or sets the DeleteWorkspaceItem 
        /// </summary>
        private WorkspaceItem[] _deleteListItems;
        public WorkspaceItem[] DeleteListItems
        {
            get
            {
                return _deleteListItems;
            }
            set
            {
                _deleteListItems = value;
                Action<WorkspaceItemResult<WorkspaceItem>> action = OnDeleteWorkSpaceItemsCompleted;
                CreateAgent().DeleteWorkspaceItemsAsync(DeleteListItems, action);
                RaisePropertyChanged(Property.DeletedListItems);
            }
        }

        /// <summary>
        /// Gets or sets the RenameListItem Property with callback
        /// </summary>
        private WorkspaceItem _renameListItem;
        public WorkspaceItem RenameListItem
        {
            get
            {
                return _renameListItem;
            }
            set
            {
                _renameListItem = value;
                Action<WorkspaceItemResult<WorkspaceItem>> action = OnRenameWorkspaceItemCompleted;
                CreateAgent().RenameWorkspaceItemAsync(RenameListItem, action);//need to change in service
            }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceListViewViewModel()
        {
            Initialize();
            EventBroker.GetBlnFolderString += (snd, e) => BlnAddFolder = e.BlnAddFolder;
            PreviousListItem = new List<WorkspaceItem>();
            ItemSelectedCommand = new DelegateCommand(ListViewSelectionChanged);
            _doubleClickCommand = new DelegateCommand(GetWorkspaceAsyncItem);
            SelectedIndex = -1;
        }
        #endregion

        #region "Command"

        /// <summary>
        /// Gets the Listview ItemSelectedCommand 
        /// </summary>
        public ICommand ItemSelectedCommand { get; set; }

        /// <summary>
        /// Gets the Listview DoubleClickCommand 
        /// </summary> 
        private readonly ICommand _doubleClickCommand;
        public ICommand DoubleClickCommand
        {
            get
            {
                return _doubleClickCommand;
            }
        }

        /// <summary>
        /// Click event to Handle the ListViewCommand 
        /// </summary>
        public ICommand ListViewCommand
        {
            get
            {
                return new DelegateCommand<string>(HandleListViewCommand);
            }
        }

        /// <summary>
        /// Handle the ListViewCommand
        /// </summary>
        /// <param name="cmdparm"></param>
        private void HandleListViewCommand(Object cmdparm)
        {
            switch ((string)cmdparm)
            {
                case Constants.CommandParameter.NewItem:
                    BtnnewitemClickEvent();
                    break;
                case Constants.CommandParameter.Refresh:
                    RefreshListViewItem();
                    break;
                case Constants.CommandParameter.NewFolder:
                    //Adds a New Folder
                    BlnAddFolder = true;
                    AddFolder();
                    break;

            }
        }
        #endregion

        # region Public Methods

        /// <summary>
        /// Creates a new folder with callback
        /// </summary>
        public void AddFolder()
        {
            Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetNewFolderCompleted;
            CreateAgent().GetFolderTitleAsync(action); //need to change in service
        }


        /// <summary>
        /// Deletes the ListViewItems 
        /// </summary>
        public void DeleteWorkspaceItems()
        {
            if (SelectedItem == null) return;
            var result = MessageBox.Show((string.Format("Are you sure you want to delete the item {0} with his children, properties and descriptions ?", SelectedItem.ItemTitle)), Constants.ProjectTitle, MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    if (ListViewControl.SelectedItems.Count > 1)
                    {
                        WorkspaceItem[] workspaceItems = new WorkspaceItem[ListViewControl.SelectedItems.Count];
                        ListViewControl.SelectedItems.CopyTo(workspaceItems, 0);
                        DeleteListItems = workspaceItems;
                        MessageBox.Show("ListItems Deleted Successfully.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        DeleteListItem = (WorkspaceItem)ListViewControl.SelectedItem;
                        // RefreshListViewItem();
                    }

                    break;
                case MessageBoxResult.No:
                    break;
            }
        }


        # endregion

        # region Protected Methods


        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            EventBroker.LoadDetailView += EventBroker_LoadDetailView;
            EventBroker.GetFolderString += (snd, e) => NewFolderString = e.NewFolderString;
            EventBroker.SetPopUpFlag += (snd, e) => PopUp = e.PopUp;
            //   Newitem = new DelegateCommand(BtnnewitemClickEvent);
        }
        # endregion

        #region Private Methods
        /// <summary>
        /// Refreshes the ListView Item
        /// </summary>
        private void RefreshListViewItem()
        {
            if (ListItem == null) return;
            EventBroker.RaiseGetWorkspaceId(new LoadWorkspaceItemEventArgs
                                                {
                                                    WorkspaceId = ListItem.ToList()[0].ParentId,
                                                    ItemId = ListItem.ToList()[0].ParentId
                                                });
        }

        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        private IWorkspaceBrowserAgent CreateAgent()
        {
            var agt = WorkspaceBrowserAgentFactory.CreateAgent(Constants.CreateAgentKey.Key);
            return agt;
        }
        /// <summary>
        /// Occurs when new folder creation is completed
        /// </summary>
        /// <param name="action"></param>
        private void OnGetNewFolderCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            if (action.Item == null) return;
            var workspace = action.Item;
            var workspacelist = ListItem.ToList();
            workspacelist.Add(workspace);
            workspace.IsFolder = true;
            workspace.DateModified = DateTime.Now.Date;
            //Due to error in service
            // CreateAgent().RegisterWorkspaceAsync(workspace);
            ListItem = workspacelist;
            NewFolderString.Add(workspace.ItemTitle);
            EventBroker.RaiseGetFolderString(new LoadDetailViewEventArgs { NewFolderString = NewFolderString });
        }

        /// <summary>
        ///  Call for refresh the Listview(Once the rename completed)
        /// </summary>
        /// <param name="action"></param>
        private void OnRenameWorkspaceItemCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            //Partial implementation-Need to implement in service
            //    if (ListItem.Count() > 0)
            //        CreateAgent().GetWorkspaceAsync(ListItem.ToList()[0].ParentId);
        }

        /// <summary>
        /// call for referesh the list view - need to check in service
        /// </summary>
        /// <param name="obj"></param>
        private void OnDeleteWorkSpaceItemsCompleted(WorkspaceItemResult<WorkspaceItem> obj)
        {
            RefreshListViewItem();
        }

        /// <summary>
        ///  Call for refresh the list View - need to check in service
        /// </summary>
        /// <param name="action">Collection of workspace Item</param>
        private void OnDeleteWorkSpaceItemCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            RefreshListViewItem();
            MessageBox.Show("ListItem Deleted Successfully.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
            // Partial work completed- need to implement
            //CreateAgent().GetWorkspaceAsync(ListItem.ToList()[0].ParentId) need to check
        }

        /// <summary>
        /// Load the List view Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">LoadDetailViewEventArgs</param>
        private void EventBroker_LoadDetailView(object sender, LoadDetailViewEventArgs e)
        {
            if (PopUp) return;
            ListItem = e.ListItem;
        }
        #endregion

        #region "Unused Methods"
        /// <summary>
        /// Gets or sets the DeleteListItem with callback 
        /// </summary>
        //private string _deleteListItem;
        //public string DeleteListItem
        //{
        //    get
        //    {
        //        return _deleteListItem;
        //    }
        //    set
        //    {
        //        _deleteListItem = value;
        //       // Action<WorkspaceItemResult<WorkspaceItem>> action = OnDeleteWorkSpaceItemCompleted;
        //     //   CreateAgent().DeleteWorkSpaceItemAsync(DeleteListItem, action); // need to change in service
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        //private void FinishRefreshState()
        //{
        //    IsRefreshing = false;
        //    RaisePropertyChanged(Property.IsEmpty);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void EventBroker_LoadListItemCount(object sender, LoadDetailViewEventArgs e)
        //{
        //    if (e.LisItemCount == 0)
        //    {
        //       FinishRefreshState();
        //    }
        //}


        #endregion
        
        protected override void StartAuthenticatedSession()
        {
            throw new NotImplementedException();
        }

        public override void TerminateAuthenticatedSession(Action onSessionTerminated = null)
        {
            throw new NotImplementedException();
        }
    }
}
