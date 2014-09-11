using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ActiproSoftware.Windows.Controls.Docking;
using Pms.WorkspaceBrowser.Contract.Agent;
using Pms.WorkspaceBrowser.Contract.Domain;
using Pms.WorkspaceBrowser.Contract.Constants;
using Pms.WorkspaceBrowser.Contract.Interfaces;
using Pms.WorkspaceBrowser.Resources;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;
using Pms.WorkspaceBrowser.UI.Controls.ViewModel;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class WorkspaceBrowserMainViewViewModel : WorkspaceBrowserViewModelBase
    {
        public bool PopUp; 

        #region Property

    /// <summary>
    /// Constant Declaration
    /// </summary>
    public new class Property
    {
        public const string WorkspaceId = "WorkspaceId";
        public const string WorkspaceMainView = "WorkspaceMainView";
        public const string AddWorkspace = "AddWorkspace";
        public const string ParentItem = "ParentItem";
        public const string ItemId = "ItemId";
        public const string AddItem = "AddItem";
        public const string DetailViewVisibility = "DetailViewVisibility";
        public const string ListViewVisibility = "ListViewVisibility";
        public const string WorkspaceItemProperties = "WorkspaceItemProperties";
        public const string WorkspaceListItem = "WorkspaceListItem";
        public const string WorkspaceSearch = "WorkspaceSearch";
        public const string WorkspaceItemSearchString = "WorkspaceItemSearchString";
        public const string PreviousListItem = "PreviousListItem";
        public const string DescriptionListItem = "DescriptionListItem";
    }

        #endregion

        #region Constructor Declaration
        /// <summary>
        /// Constructor Declarations
        /// </summary>
        public WorkspaceBrowserMainViewViewModel()
        {
            Initialize();
            EventBroker.LoadProperties += EventBroker_LoadProperties;
            EventBroker.GetListItem += (snd, e) => WorkspaceListItem = e.ListItem;
            EventBroker.GetSearchString += (snd, e) => WorkspaceItemSearchString = e.SearchString;
            EventBroker.GetPreviousListItem += (snd, e) => PreviousListItem = e.PreviousListItem;
            EventBroker.LoadDescription += (snd, e) => DescriptionListItem = e.DescriptionListItem;
            EventBroker.SetPopUpFlag += (snd, e) => PopUp = e.PopUp;
            EventBroker.SelectedItemChange += EventBroker_SelectedItemChange;
            EventBroker.LoadDetailView += (snd, e) => WorkspaceListItem = e.ListItem;
        }

        private void EventBroker_SelectedItemChange(object sender, LoadWorkspaceItemEventArgs e)
        {
            SelectedItem = e.SelectedItem;
            SelectedIndex = e.SelectedIndex;
        }

        private void EventBroker_LoadProperties(object sender, LoadPropertiesEventArgs e)
        {
            if (PopUp) return;
            WorkspaceItemProperties = e.WorkspaceItemProperties;
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            WorkspaceId = WorkspaceRoot.Top;
        }

        #endregion

        /// <summary>
        /// Gets the selected Listview Item Index 
        /// </summary>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Gets the selectedItem
        /// </summary>
        public WorkspaceItem SelectedItem { get; set; }
        #region properties

        /// <summary>
        /// Gets or Sets the AddItem window
        /// </summary>
        /// <value>The Item Add window</value>

        private AddItem _addItem;
        public AddItem AddItem
        {
            get
            {
                return _addItem;
            }
            set
            {
                _addItem = value;
                RaisePropertyChanged(Property.AddItem);
            }
        }


        /// <summary>
        /// Gets the agent.
        /// </summary>
        /// <value>The agent.</value>
        private IWorkspaceBrowserAgent _agent;
        private IWorkspaceBrowserAgent Agent
        {
            get { return _agent ?? (_agent = CreateAgent()); }
        }

        /// <summary>
        /// Gets or sets the workspace id.
        /// </summary>
        /// <value>The workspace id.</value>
        private string _workspaceId;
        public string WorkspaceId
        {
            get { return _workspaceId; }
            set
            {
                if (_workspaceId == value) return;
                _workspaceId = value;
                RaisePropertyChanged(Property.WorkspaceId);
            }
        }
        ///// <summary>
        ///// Gets or sets the listview control visibility.
        ///// </summary>
        ///// <value>The workspace id.</value>
        //private Visibility _listViewVisibility;
        //public Visibility ListViewVisibility
        //{
        //    get { return _listViewVisibility; }
        //    set
        //    {

        //        _listViewVisibility = value;
        //        RaisePropertyChanged(Property.ListViewVisibility);
        //    }
        //}

        //  /// <summary>
        ///// Gets or sets the listview control visibility.
        ///// </summary>
        ///// <value>The workspace id.</value>
        //private Visibility _detailViewVisibility;
        //public Visibility DetailViewVisibility
        //{
        //    get { return _detailViewVisibility; }
        //    set
        //    {

        //        _detailViewVisibility = value;
        //        RaisePropertyChanged(Property.DetailViewVisibility);
        //    }
        //}
        /// <summary>
        /// Gets and Sets the WorkspaceMainView
        /// </summary>
        //private WorkspaceBrowserMainView _workspaceMainView;
        //public WorkspaceBrowserMainView WorkspaceMainView
        //{
        //    get
        //    {
        //        return _workspaceMainView;
        //    }
        //    set
        //    {
        //        _workspaceMainView = value;
        //        if (value != null) _workspaceMainView.wsNavigator.wsTreeView.WorkspaceMainView = value;
        //        RaisePropertyChanged(Property.WorkspaceMainView);
        //    }
        //}

        /// <summary>
        /// Gets or Sets the AddItem window
        /// </summary>
        /// <value>The Item Add window</value>

        //private AddWorkspace _addWorkspace;
        //public AddWorkspace AddWorkspace
        //{
        //    get
        //    {
        //        return _addWorkspace;
        //    }
        //    set
        //    {
        //        _addWorkspace = value;
        //        RaisePropertyChanged(Property.AddWorkspace);
        //    }
        //}

        /// <summary>
        /// Gets and Sets NewFolderString Data
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
            }
        }

        /// <summary>
        /// Gets and Sets NewFolderString Data
        /// </summary>
        private List<string> _parentItem;
        public List<string> ParentItem
        {
            get
            {
                return _parentItem;
            }
            set
            {
                _parentItem = value;
                RaisePropertyChanged(Property.ParentItem);
            }
        }

        private WorkspaceItem _selectedid;
        public WorkspaceItem selectedID
        {
            get
            {
                return _selectedid;
            }
            set
            {
                _selectedid = value;
            }

        }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        private string _itemId;
        public string ItemId
        {
            get { return _itemId; }
            set
            {
                if (_itemId == value) return;
                _itemId = value;

                RaisePropertyChanged(Property.ItemId);
            }
        }
        /// <summary>
        /// Gets and Sets the DataGridCollectionView Property
        /// </summary>
        private IEnumerable<WorkspaceItemProperty> _workspaceItemProperties;
        public IEnumerable<WorkspaceItemProperty> WorkspaceItemProperties
        {
            get
            {
                return _workspaceItemProperties;
            }
            set
            {
                _workspaceItemProperties = value;
                RaisePropertyChanged(Property.WorkspaceItemProperties);
            }
        }




        /// <summary>
        /// Gets and Sets ListItem Data
        /// </summary>
        private IEnumerable<WorkspaceItem> _workspacelistItem;
        public IEnumerable<WorkspaceItem> WorkspaceListItem
        {
            get
            {
                return _workspacelistItem;
            }
            set
            {
                _workspacelistItem = value;
                RaisePropertyChanged(Property.WorkspaceListItem);
            }
        }


        /// <summary>
        /// Gets or Sets the Search item
        /// </summary>
        /// <value>The Item Add window</value>

        private WorkspaceSearchControl _workspacesearch;
        public WorkspaceSearchControl WorkspaceSearch
        {
            get
            {
                return _workspacesearch;
            }
            set
            {
                _workspacesearch = value;
                RaisePropertyChanged(Property.WorkspaceSearch);
            }
        }

        /// <summary>
        /// Gets or Sets the Workspaceitemsearchstring
        /// </summary>
        /// <value>The WorkspaceTypeId</value>
        private string _workspaceitemsearchstring;
        public string WorkspaceItemSearchString
        {
            get
            {
                return _workspaceitemsearchstring;
            }
            set
            {
                _workspaceitemsearchstring = value;
                Agent.GetWorkspaceItemsBySearchStringAsync(_workspaceitemsearchstring);
                RaisePropertyChanged(Property.WorkspaceItemSearchString);
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
                if (_perviouslistitem.Count > 1)
                {
                    CurrentListItem = _perviouslistitem[_perviouslistitem.Count-2];
                }
                RaisePropertyChanged(Property.PreviousListItem);
            }
        }

        private static WorkspaceItem _currentListitem;
        public static WorkspaceItem CurrentListItem
        {
            get { return _currentListitem; }
            set { _currentListitem = value; }
        }

        #endregion

        #region " Private Methods "

        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        private IWorkspaceBrowserAgent CreateAgent()
        {
            //var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Mock);
             var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Instance);

            //agt.OnGetWorkspaceCompleted += AgtOnGetWorkspaceCompleted;
            //agt.OnGetFoldersCompleted += AgtOnGetFoldersCompleted;
            //agt.OnGetFullWorkspaceItemCompleted += AgtOnGetFullWorkspaceItemCompleted;
            //agt.OnGetDescriptionsCompleted += AgtOnGetDescriptionsCompleted;
            //agt.OnGetPropertiesCompleted += AgtOnGetPropertiesCompleted;
            agt.GetWorkspaceItemsBySearchStringCompleted += (r) => AgtOnGetWorkspaceItemsBySearchStringCompleted(r.Items);
            //agt.OnSaveWorkSpaceItemDescCompleted += AgtOnWorkspaceCompleted;

            agt.AddFolderCompleted += (r) => agtOnAddFolderCompleted(r.Item);//agtAddFolderCompleted();

            return agt;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void agtOnAddFolderCompleted(WorkspaceItem item)//private void agtAddFolderCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            var workspace = new WorkspaceItem();
            workspace = item;
            var workspacelist = new List<WorkspaceItem>();
            workspacelist = WorkspaceListItem.ToList();
            workspacelist.Add(workspace);
            WorkspaceListItem = workspacelist;
            NewFolderString.Add(workspace.ItemTitle);
            EventBroker.RaiseGetFolderString(new LoadDetailViewEventArgs() { NewFolderString = NewFolderString });
            EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs() { ListItem = WorkspaceListItem });

        }

        /// <summary>
        /// Gets the embedded file.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Byte[]</returns>
        private static Byte[] GetEmbeddedFile(string assemblyName, string fileName)
        {
            var r = new WorkspaceBrowserResource();
            return r.GetEmbeddedFile(assemblyName, fileName);
        }

        /// <summary>
        /// Event Handler for Assigning the searched WorkspaceItem to ListItem Property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgtOnGetWorkspaceItemsBySearchStringCompleted(IEnumerable<WorkspaceItem> items)//private void AgtOnGetWorkspaceItemsBySearchStringCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            // WorkspaceMainView = WorkspaceSearch.WorkspaceMainView;
            var list = items;
            var data = new ObservableCollection<WorkspaceItem>();
            foreach (var item in list)
            {
                var info = new WorkspaceItem
                {
                    AdditionalInfoUri = item.AdditionalInfoUri,
                    Children = item.Children,
                    DateModified = item.DateModified,
                    Descriptions = item.Descriptions,
                    Id = item.Id,
                    IsFolder = item.IsFolder,
                    ItemId = item.ItemId,
                    ItemImage = item.ItemImage,
                    ItemTitle = item.ItemTitle,
                    ParentId = item.ParentId,
                    Properties = item.Properties,
                    SortOrder = item.SortOrder,
                    TypeId = item.TypeId,
                    TypeImage = item.TypeImage,
                    TypeTitle = item.TypeTitle
                };
                info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0 ? GetEmbeddedFile("Pms.WorkspaceBrowser.Resources", "CloseFolder.png") : item.ItemImage;
                data.Add(info);
            }
            EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs() { ListItem = data });
            //var searchworkspace = new WorkspaceItem { Children = data.ToArray() };
            //PreviousListItem.Add(searchworkspace);

            // ChildrenListItem = e.Item;
            //if (View == List || View == null)
            //  BindListViewData();
            // else
            //  BindDetailViewData();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Calls the Asynchronous Method to get Workspace Item
        /// </summary>
        public void GetFoldersAsync()
        {
            Agent.GetFoldersAsync(WorkspaceId);
        }

        /// <summary>
        /// Calls the Asynchronous Method to get Workspace Item
        /// </summary>
        public void GetWorkspaceAsync()
        {
            //if (WorkspaceMainView != null)
            //    WorkspaceMainView.wsNavigator.wsTreeView.ucLoad.Visibility = Visibility.Visible;

            Agent.GetWorkspaceAsync(WorkspaceId);
            // if (AddWorkspace != null) AddWorkspace.wsTreeView.Cursor = Cursors.Arrow;

        }

        /// <summary>
        /// Calls the Asynchronous method to get Workspace Item 
        /// </summary>

        public void GetWorkspaceAsyncItem()
        {
            NewFolderString = new List<string>();
            if ((selectedID.Children != null) && (selectedID.Children.Length > 0))
            {
                Agent.GetWorkspaceAsync(selectedID.Id);
            }
        }

        /// <summary>
        /// Calls the Asynchronous Method to get Full Workspace Item
        /// </summary>
        public void GetFullWorkspaceItemAsync()
        {
            CreateAgent().GetFullWorkspaceItemAsync(ItemId);
        }

        /// <summary>
        /// Calls the Asynchronous Method to get Descriptions
        /// </summary>
        public void GetDescriptionsAsync()
        {
            CreateAgent().GetDescriptionsAsync(ItemId);
        }

        /// <summary>
        /// Calls the Asynchronous Method to get Properties
        /// </summary>
        public void GetPropertiesAsync()
        {
            CreateAgent().GetPropertiesAsync(ItemId);
        }

        /// <summary>
        /// Calls the asynchronous Method to save the Dragged Data
        /// </summary>
        public void SaveDraggedDataAsync()
        {
            //CreateAgent().RegisterDraggedDataAsync(SourceWorkspace, Targetworkspace); command by arun
        }

        /// <summary>
        /// Calls the asynchronous Method to add the Workspace
        /// </summary>
        public void AddWorkspaceAsync()
        {
            //  CreateAgent().AddWorkspaceAync(new WorkspaceItem { ParentId = ParentWorkspaceId, TypeId = WorkspaceTypeId, Id = Workspace });
        }

        /// <summary>
        /// Calls the asynchronous Method to add the WorkspaceItem
        /// </summary>
        public void AddItemAsync()
        {
            // Agent.AddItemAsync(new WorkspaceItem { ParentId = ParentWorkspaceId, TypeId = WorkspaceTypeId, Id = Workspace }); //Command by arun
        }

        /// <summary>
        /// Calls the asynchronous Method to add the WorkspaceItem
        /// </summary>
        public void SearchWorkspaceItemAsync(string workspaceItemSearchString)
        {
            //Agent.GetSearchWorkspaceItemsAsync(workspaceItemSearchString);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddFolder()
        {
            Agent.AddFolderAsync(NewFolderString);


            //commond by arun
            //string name = string.Empty;
            //if (WorkspaceMainView.wsListView.NewFolderString.Count == 0)
            //{
            //    name = "New Folder";
            //}
            //else
            //{
            //    name = "New Folder " + "(" + (WorkspaceMainView.wsListView.NewFolderString.Count + 1) + ")";
            //}
            //var workspace = new WorkspaceItem
            //                    {
            //                        ItemTitle = name,
            //                        ItemImage = GetEmbeddedFile("Pms.WorkspaceBrowser.Resources", "CloseFolder.png")
            //                    };


        }

        #endregion

        #region "RelayCommand"

        /// <summary>
        /// Get the Button Add Workspace
        /// </summary>
        /// <value>The Button AddWorkspace Click</value>
        private RelayCommand _btnAddFolderClick;
        public ICommand BtnAddFolderClick
        {
            get
            {
                _btnAddFolderClick = new RelayCommand(param => BtnAddFolderClickEvent());
                return _btnAddFolderClick;
            }
        }

        /// <summary>
        /// Get the Button ShowinNewTab
        /// </summary>
        /// <value>The Button ShowinNewTab Click</value>
        private RelayCommand _btnShowinNewTabClick;
        public ICommand BtnShowinNewTabClick
        {
            get
            {
                _btnShowinNewTabClick = new RelayCommand(param => BtnShowinNewTabClickEvent());
                return _btnShowinNewTabClick;
            }
        }

        /// <summary>
        /// Get the Button AddtoFavorites
        /// </summary>
        /// <value>The Button AddtoFavorites Click</value>
        private RelayCommand _btnAddtoFavoritesClick;
        public ICommand BtnAddtoFavoritesClick
        {
            get
            {
                _btnAddtoFavoritesClick = new RelayCommand(param => BtnAddtoFavoritesClickEvent());
                return _btnAddtoFavoritesClick;
            }
        }


        /// <summary>
        /// Get the Button AddtoItem
        /// </summary>
        /// <value>The Button AddtoItem Click</value>
        private RelayCommand _btnAddItemClick;
        public ICommand BtnAddItemClick
        {
            get
            {
                _btnAddItemClick = new RelayCommand(param => BtnAddItemClickEvent());
                return _btnAddItemClick;
            }
        }


        /// <summary>
        /// Gets the Button List View Click
        /// </summary>
        ///<value>The Button List View Click</value>
        private RelayCommand _btnListViewClick;
        public ICommand BtnListViewClick
        {
            get
            {
                _btnListViewClick = new RelayCommand(param => BtnListViewclickEvent());
                return _btnListViewClick;
            }
        }


        //code by SP-10Dec2010

        /// <summary>
        /// Gets the New Description Click
        /// </summary>
        ///<value>The Contex menu Click</value>
        private RelayCommand _showAddDescriptionPopUp;
        public ICommand ShowAddDescriptionPopUp
        {
            get
            {
                _showAddDescriptionPopUp = new RelayCommand(param => ShowAddDescriptionPopUpEvent());
                return _showAddDescriptionPopUp;
            }
        }

        //code by SP-20Dec2010

        /// <summary>
        /// Gets the New Property Click
        /// </summary>
        ///<value>The Contex menu Click</value>
        private RelayCommand _showAddPropertyPopUp;
        public ICommand ShowAddPropertyPopUp
        {
            get
            {
                _showAddPropertyPopUp = new RelayCommand(param => ShowAddPropertyPopUpEvent());
                return _showAddPropertyPopUp;
            }
        }


        /// <summary>
        /// Gets the Button Detail View Click
        /// </summary>
        ///<value>The Button List View Click</value>
        private RelayCommand _btnDetailViewClick;
        public ICommand BtnDetailViewClick
        {
            get
            {
                _btnDetailViewClick = new RelayCommand(param => BtnDetailViewClickEvent());
                return _btnDetailViewClick;
            }
        }


        /// <summary>
        /// Gets the Back Button Click
        /// </summary>
        ///<value>The Button List View Click</value>
        private RelayCommand _btnBackClick;
        public ICommand BtnBackClick
        {
            get
            {
                _btnBackClick = new RelayCommand(param => BtnBackClickEvent());
                return _btnBackClick;
            }
        }

        /// <summary>
        /// Gets the Add Button Click
        /// </summary>
        ///<value>The Button List View Click</value>
        private RelayCommand _btnAddClick;
        public ICommand BtnAddClick
        {
            get
            {
                _btnAddClick = new RelayCommand(BtnAddClickEvent);
                return _btnAddClick;
            }
        }

        /// <summary>
        /// Gets the Cancel Button Click
        /// </summary>
        ///<value>The Button List View Click</value>
        private RelayCommand _btnCancelClick;
        public ICommand BtnCancelClick
        {
            get
            {
                _btnCancelClick = new RelayCommand(param => BtnCancelClickEvent());
                return _btnCancelClick;
            }
        }


        /// <summary>
        /// Gets the Listview DoubleClickCommand 
        /// </summary>
        private ICommand _doubleClickCommand;
        public ICommand DoubleClickCommand
        {
            get
            {
                return _doubleClickCommand;
            }
        }


        /// <summary>
        /// Gets the Search Button Click
        /// </summary>
        ///<value>The Button Search Click</value>
        private RelayCommand _btnSearchClick;
        public ICommand BtnSearchClick
        {
            get
            {
                _btnSearchClick = new RelayCommand(param => BtnSearchClickEvent());
                return _btnSearchClick;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private RelayCommand _btnModifyItemClick;
        public ICommand BtnModifyItemClick
        {
            get
            {
             _btnModifyItemClick= new RelayCommand(param=>BtnModifyItemClickEvent());
                return _btnModifyItemClick;
            }
        }


        /// <summary>
        /// Gets and Sets the Description data
        /// </summary>
        private IEnumerable<WorkspaceItemDescription> _descriptionlistItem;
        public IEnumerable<WorkspaceItemDescription> DescriptionListItem
        {
            get
            {
                return _descriptionlistItem;
            }
            set
            {
                _descriptionlistItem = value;
                RaisePropertyChanged(Property.DescriptionListItem);
            }
        }
        #region "Private Methods"

        /// <summary>
        /// 
        /// </summary>
        private void BtnModifyItemClickEvent()
        {
            if (SelectedIndex < 0)
            {
                MessageBox.Show("Please make a selection into list!", Constants.ProjectTitle);
                return;
            }

            AddItem = new AddItem();
            AddItem.ApplicationName = Constants.ViewNames.ModifyItem;
            AddItem.ProcessFrom = Constants.ViewNames.ModifyItem;
            AddItem.Vm.ProcessFrom = Constants.ViewNames.ModifyItem;
            AddItem.txtparentworkspace.IsEnabled = false;
            AddItem.btnsearch.IsEnabled = false;
            AddItem.workspacetypecombo.IsEnabled = false;
            AddItem.Workspacetext.IsEnabled = false;
            AddItem.addimage.IsEnabled = false;
            AddItem.txtOI.IsEnabled = false;
            AddItem.Vm.WorkspaceItemProperties = WorkspaceItemProperties;
            AddItem.WorkspaceItemProperties = WorkspaceItemProperties;
            AddItem.Vm.CurrentItem = SelectedItem;
            AddItem.Vm.DescriptionListItem = DescriptionListItem;
            AddItem.DescriptionListItem = DescriptionListItem;
            AddItem.ShowDialog();
            EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs() { ItemId = SelectedItem.ItemId });
        }


        //code by SP-10Dec2010

        /// <summary>
        /// Click event to popup the AddItem window 
        /// </summary>
        private void ShowAddDescriptionPopUpEvent()
        {


            //AddDescription = new AddDescription();
            //// AddDescription.Vm.DescriptionListItem = DescriptionListItem;
            //AddDescription.descriptionusercontrol.Vm.DescriptionListItem = DescriptionListItem;
            //AddDescription.descriptionusercontrol.DescriptionListItem = DescriptionListItem;
            ////  AddDescription.DescriptionListItem = DescriptionListItem;

            //AddDescription.ShowDialog();
        }

        //code by SP-20Dec2010

        /// <summary>
        /// Click event to popup the AddItem window 
        /// </summary>
        private void ShowAddPropertyPopUpEvent()
        {
            //AddProperty = new AddProperty();

            //AddProperty.PropertyUserControl.Vm.WorkspaceItemProperties = WorkspaceItemProperties;
            //AddProperty.PropertyUserControl.WorkspaceItemProperties = WorkspaceItemProperties;

            //AddProperty.ShowDialog();
        }



        /// <summary>
        /// Click event to search the workspace item
        /// </summary>
        private void BtnSearchClickEvent()
        {
            WorkspaceItemSearchString = WorkspaceSearch.SearchText.Text;
            SearchWorkspaceItemAsync(WorkspaceItemSearchString);
        }

        /// <summary>
        /// Click event to cancel the workspace item.
        /// </summary>
        private void BtnCancelClickEvent()
        {
            //  AddWorkspace.Close();
        }

        /// <summary>
        /// Click event to add the workspace item.
        /// </summary>
        private void BtnAddClickEvent(object param)
        {
            ////string parameter = param.ToString();
            ////if (parameter == Property.AddWorkspace)
            ////{
            ////    Workspace = AddWorkspace.Workspacetext.Text;
            ////    if (Workspace != string.Empty)
            ////    {
            ////        WorkspaceTypeId = Convert.ToString(AddWorkspace.workspacetypecombo.SelectedItem);
            ////        var newWorkspaceItem = new WorkspaceItem
            ////        {
            ////            ParentId = ParentWorkspaceId,
            ////            ItemTitle = Workspace,
            ////            TypeId = WorkspaceTypeId
            ////        };

            ////        WorkspaceMainView.wsNavigator.wsTreeView.AddWorkspace(newWorkspaceItem);


            ////        AddWorkspace.Close();
            ////        AddWorkspaceAsync();
            ////    }
            ////    else
            ////    {

            ////        AddWorkspace.Workspacetext.BorderBrush = Brushes.Red;
            ////        AddWorkspace.Errormsg.Visibility = Visibility.Visible;
            ////    }

            ////    AddWorkspace.Close();
            ////    AddWorkspaceAsync();

            ////}
            ////else
            ////{
            ////    Workspace = AddItem.Workspacetext.Text;
            ////    if (ParentWorkspaceId != null)
            ////    {
            ////        if (Workspace != string.Empty)
            ////        {
            ////            WorkspaceTypeId = Convert.ToString(AddItem.workspacetypecombo.SelectedItem);
            ////            var newWorkspaceItem = new WorkspaceItem
            ////            {
            ////                ParentId = ParentWorkspaceId,
            ////                ItemTitle = Workspace,
            ////                TypeId = WorkspaceTypeId
            ////            };

            ////            WorkspaceMainView.wsNavigator.wsTreeView.AddWorkspace(newWorkspaceItem);

            ////            AddItem.Workspacetext.BorderBrush = Brushes.Transparent;
            ////            //  AddItem.Errormsg.Visibility = Visibility.Collapsed;
            ////            AddItem.Close();
            ////            AddItemAsync();
            ////        }

            ////        else
            ////        {

            ////            AddItem.Workspacetext.BorderBrush = Brushes.Red;
            ////            //  AddItem.Errormsg.Visibility = Visibility.Visible;
            ////        }
            ////        AddItem.ParentworkspaceCombo.BorderBrush = Brushes.Transparent;
            ////        //   AddItem.ParentErrormsg.Visibility = Visibility.Collapsed;
            ////    }
            ////    else
            ////    {
            ////        AddItem.ParentworkspaceCombo.BorderBrush = Brushes.Red;
            ////        // AddItem.ParentErrormsg.Visibility = Visibility.Visible;
            ////    }
            ////}
        }

        /// <summary>
        ///  click event to add the selected item to favorites
        /// </summary>
        private void BtnAddtoFavoritesClickEvent()
        {
            //if (WorkspaceMainView.wsNavigator.wsTreeView.MyTreeView.SelectedItem != null)
            //{
            //    bool lastitem = false;
            //    if (FavoritesItem == null)
            //        FavoritesItem = new List<WorkspaceItem>();
            //    foreach (var item in FavoritesItem)
            //    {
            //        if (item == WorkspaceMainView.wsNavigator.wsTreeView.MyTreeView.SelectedItem)
            //        {
            //            lastitem = true;
            //        }

            //    }
            //    if (!lastitem)
            //    {
            //        FavoritesItem.Add(WorkspaceMainView.wsNavigator.wsTreeView.MyTreeView.SelectedItem as WorkspaceItem);
            //        WorkspaceMainView.wsFavorites.Vm.FavoritesItem = new List<WorkspaceItem>();
            //        WorkspaceMainView.wsFavorites.Vm.FavoritesItem = FavoritesItem;
            //    }
            //    WorkspaceMainView.twFavorites.Activate();
            //    WorkspaceMainView.twFavorites.Open();
            //    WorkspaceMainView.wsFavorites.FavoritesListView.SelectionChanged += FavoritesListViewSelectionChanged;



            //}


        }



        /// <summary>
        /// click event to view the New workspace-partial implementation
        /// </summary>
        private void BtnAddFolderClickEvent()
        {
            if (NewFolderString == null)
                NewFolderString = new List<string>();
            var BlnAddFolder = true;
            EventBroker.RaiseGetBlnFolderString(new LoadDetailViewEventArgs() { BlnAddFolder = BlnAddFolder });
           // EventBroker.GetListItem += (snd, e) => WorkspaceListItem = e.ListItem;
           
            
            AddFolder();

        }

        /// <summary>
        /// Click event to view the List -partial implementation
        /// </summary>
        private void BtnListViewclickEvent()
        {
            EventBroker.RaiseVisibleList(new LoadDetailViewEventArgs() { VisibleListOrDetails = true });

            //OpenDetailWindow = true;
            //View = List;
            //ViewinList();
            //WorkspaceMainView.wsNavigator.wsTreeView.View = View;
            //if (OpenWindow && WorkspaceMainView.wsNavigator.wsTreeView.Vm.OpenWindow)
            //{
            //    if (NewWorkspaceDetailView != null)
            //    {
            //        WorkspaceMainView.mdiContainer.Items.Remove(NewWorkspaceDetailView);
            //        AddListWindow();
            //        OpenWindow = false;
            //    }
            //}
            //BindListViewData();
        }

        /// <summary>
        /// Click Event to View the Detail -partial implementation
        /// </summary>
        private void BtnDetailViewClickEvent()
        {
            EventBroker.RaiseVisibleList(new LoadDetailViewEventArgs() { VisibleListOrDetails = false });

            //OpenWindow = true;
            //View = Detail;
            //ViewinDetail();
            //WorkspaceMainView.wsNavigator.wsTreeView.View = View;

            //if (OpenDetailWindow && WorkspaceMainView.wsNavigator.wsTreeView.Vm.OpenDetailWindow)
            //{
            //    if (NewWorkspaceListView != null)
            //    {
            //        WorkspaceMainView.mdiContainer.Items.Remove(NewWorkspaceListView);

            //        AddDetailWindow();
            //        OpenDetailWindow = false;
            //    }
            //}
            //BindDetailViewData();

        }



        /// <summary>
        /// Click Event to view the Workspace item in new tab
        /// </summary>
        private void BtnShowinNewTabClickEvent()
        {
            //WorkspaceMainView.wsNavigator.wsTreeView.NewWorkspaceDetailView = NewWorkspaceDetailView = null;
            //WorkspaceMainView.wsNavigator.wsTreeView.NewWorkspaceListView = NewWorkspaceListView = null;
            //OpenWindow = true;
            //OpenDetailWindow = true;
            //WorkspaceMainView.wsNavigator.wsTreeView.Vm.OpenDetailWindow = true;
            //WorkspaceMainView.wsNavigator.wsTreeView.Vm.OpenWindow = true;
            //AddListWindow();
        }

        /// <summary>
        /// Adds a List View Window
        /// </summary>
        public void AddListWindow()
        {
            #region old code for reference
            //NewWorkspaceListView = new WorkspaceListView();
            ////NewWorkspaceListView.Vm.ListItem = ListItem;
            //if (NewWorkspaceDetailView != null)
            //    if (NewWorkspaceDetailView.Vm.ListItem == ListItem)
            //        NewWorkspaceListView.Vm.ListItem = NewWorkspaceDetailView.Vm.ListItem;
            //    else
            //        NewWorkspaceListView.Vm.ListItem = ListItem;
            //else
            //    NewWorkspaceListView.Vm.ListItem = ListItem;
            //NewWorkspaceListView.ListViewControl.SelectionChanged += ListviewSelectionChanged;
            //WorkspaceMainView.mdiContainer.Items.Add(NewWorkspaceListView);
            //WorkspaceMainView.mdiContainer.SelectedItem = NewWorkspaceListView;
            //WorkspaceMainView.mdiContainer.DockSite.AreDocumentWindowsDestroyedOnClose = false;

            //WorkspaceMainView.mdiContainer.Visibility = Visibility.Visible;
            #endregion

        }

        /// <summary>
        /// Adds a Detail View Window
        /// </summary>
        public void AddDetailWindow()
        {
            #region old code for reference
            //NewWorkspaceDetailView = new WorkspaceDetailView();
            ////NewWorkspaceDetailView.Vm.ListItem = ListItem;
            //NewWorkspaceDetailView.Vm.ListItem = NewWorkspaceListView.Vm.ListItem;
            //NewWorkspaceDetailView.DetailViewControl.SelectionChanged += DetailViewControlSelectionChanged;
            //WorkspaceMainView.mdiContainer.Items.Add(NewWorkspaceDetailView);
            //WorkspaceMainView.mdiContainer.SelectedItem = NewWorkspaceDetailView;
            //WorkspaceMainView.mdiContainer.DockSite.AreDocumentWindowsDestroyedOnClose = false;

            //WorkspaceMainView.mdiContainer.Visibility = Visibility.Visible;
            #endregion
        }

        ///<summary>
        ///click event to View Prevoius the Tree View items -partial implementation
        ///</summary>
        private void BtnBackClickEvent()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            if (PreviousListItem != null)
            {

                if (PreviousListItem.Count > 1)
                {
                    for (int i = 0; i <= PreviousListItem.Count; i++)
                    {
                        var child1 = PreviousListItem[PreviousListItem.Count - 2].Children;
                        var child2 = PreviousListItem[PreviousListItem.Count - 1].Children;
                        if ((child1 != null) && (child1.Count() > 0) && (child2 != null) && (child2.Count() > 0))

                            if (PreviousListItem[PreviousListItem.Count - 2].Children[0].Id ==
                                PreviousListItem[PreviousListItem.Count - 1].Children[0].Id)
                            {
                                if (PreviousListItem.Count > 2)
                                {
                                    PreviousListItem.RemoveAt(PreviousListItem.Count - 1);
                                }
                            }

                    }
                    if (PreviousListItem.Count > 1)
                    {
                        if (PreviousListItem[PreviousListItem.Count - 2].Children != null)
                        {
                            var data = new ObservableCollection<WorkspaceItem>();
                            foreach (var item in PreviousListItem[PreviousListItem.Count - 2].Children.ToList())
                            {
                                var info = new WorkspaceItem
                                {
                                    AdditionalInfoUri = item.AdditionalInfoUri,
                                    Children = item.Children,
                                    DateModified = item.DateModified,
                                    Descriptions = item.Descriptions,
                                    Id = item.Id,
                                    IsFolder = item.IsFolder,
                                    ItemId = item.ItemId,
                                    ItemImage = item.ItemImage,
                                    ItemTitle = item.ItemTitle,
                                    ParentId = item.ParentId,
                                    Properties = item.Properties,
                                    SortOrder = item.SortOrder,
                                    TypeId = item.TypeId,
                                    TypeImage = item.TypeImage,
                                    TypeTitle = item.TypeTitle
                                };
                                info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0 ? GetEmbeddedFile("Pms.WorkspaceBrowser.Resources", "CloseFolder.png") : item.ItemImage;
                                data.Add(info);

                            }

                            ItemId = PreviousListItem[PreviousListItem.Count - 2].Children[0].ParentId;
                            //BindPropertyDescription();
                            EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs() { ItemId = ItemId });
                            PreviousListItem.RemoveAt(PreviousListItem.Count - 1);
                            EventBroker.RaiseGetPreviousListItem(new LoadWorkspaceItemEventArgs() { PreviousListItem = PreviousListItem });
                            EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs() { ListItem = data });

                        }



                    }
                }
            }

            
           
        }


        /// <summary>
        /// Click event to popup the AddItem window 
        /// </summary>
        private void BtnAddItemClickEvent()
        {
            AddItem = new AddItem();
            AddItem.ApplicationName = Constants.ViewNames.AddItem;
            AddItem.ProcessFrom = Constants.ViewNames.AddItem;
            AddItem.txtparentworkspace.IsEnabled = false;
            AddItem.Vm.ProcessFrom = Constants.ViewNames.AddItem;
            AddItem.ShowDialog();
        }




        #endregion
        #endregion
    }
}
