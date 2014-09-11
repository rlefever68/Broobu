using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Constants;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Result;
using Pms.ManageWorkspaces.Resources;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class WorkspaceBrowserMainViewViewModel : WorkspaceBrowserViewModelBase
    {
        #region Fields
        private bool _popUp;
        //private int WorkspaceItemCount;
        public ICommand BtnAddFolderClick { get; set; }
        public ICommand BtnAddItemClick { get; set; }
        public ICommand BtnListViewClick { get; set; }
        public ICommand BtnDetailViewClick { get; set; }
        public ICommand BtnBackClick { get; set; }
        public ICommand BtnModifyItemClick { get; set; }

        #endregion

        #region Constants Class

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
            public const string WorkspaceItemProperties = "WorkspaceItemProperties";
            public const string WorkspaceListItem = "WorkspaceListItem";
            public const string WorkspaceSearch = "WorkspaceSearch";
            public const string WorkspaceItemSearchString = "WorkspaceItemSearchString";
            public const string PreviousListItem = "PreviousListItem";
            public const string DescriptionListItem = "DescriptionListItem";
            public const string BlnBack = "BlnBack";

            public const string IsRefreshing = "IsRefreshing";
            public const string IsEmpty = "IsEmpty";
        }

        #endregion

        #region Constructor Declaration

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceBrowserMainViewViewModel"/> class.
        /// </summary>
        public WorkspaceBrowserMainViewViewModel()
        {
            Initialize();

            IsRefreshing = true;
            OptinMessages();
            EventBroker.GetModifyItem += (snd, e) =>
            {
                ModifyItem = e.ModifyItem;
            };
            EventBroker.LoadProperties += EventBroker_LoadProperties;
            EventBroker.GetListItem += (snd, e) => WorkspaceListItem = e.ListItem;
            EventBroker.GetPreviousListItem += (snd, e) => PreviousListItem = e.PreviousListItem;
            EventBroker.LoadDescription += (snd, e) => DescriptionListItem = e.DescriptionListItem;
            EventBroker.SetPopUpFlag += (snd, e) => _popUp = e.PopUp;
            EventBroker.SelectedItemChange += EventBroker_SelectedItemChange;
            EventBroker.LoadDetailView += (snd, e) => WorkspaceListItem = e.ListItem;
            //  EventBroker.WorkspaceItemCount += EventBroker_WorkspaceItemCount;
        }



        #endregion

        #region Properties


        private bool _isRefreshing;
        /// <summary>
        /// Is the list being refreshed?
        /// </summary>
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(Property.IsRefreshing);
            }
        }

        ///// <summary>
        ///// Is the list empty?
        ///// </summary>
        public new bool IsEmpty
        {
            get
            {
                //if (IsRefreshing) return false;
                //return (WorkspaceItemCount == 0);
                return false;
            }
        }

        /// <summary>
        /// Gets or Sets the BlnBack
        /// </summary>
        /// <value>The Item Add window</value>
        private bool _blnBack;
        public bool BlnBack
        {
            get
            {
                return _blnBack;
            }
            set
            {
                _blnBack = value;
                RaisePropertyChanged(Property.BlnBack);
            }
        }

        /// <summary>
        /// Gets and Sets the ModifyItem
        /// </summary>
        public WorkspaceItem ModifyItem { get; set; }

        /// <summary>
        /// Gets the selected Listview Item Index 
        /// </summary>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Gets the selectedItem
        /// </summary>
        public WorkspaceItem SelectedItem { get; set; }

        public List<string> NewFolderString { get; set; }

        /// <summary>
        /// Gets the selected Id
        /// </summary>
        public WorkspaceItem SelectedId { get; set; }

        /// <summary>
        /// Gets the current selected workspce item.
        /// </summary>
        public static WorkspaceItem CurrentListItem { get; set; }

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
                BlnBack = _perviouslistitem.Count > 1;

                if (_perviouslistitem.Count > 1)
                {
                    CurrentListItem = _perviouslistitem[_perviouslistitem.Count - 2];
                }
                RaisePropertyChanged(Property.PreviousListItem);
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

        #endregion

        #region Public Methods

        /// <summary>
        /// Asynchronous method with callback to get the add folder title
        /// </summary>
        public void AddFolder()
        {
            Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetNewFolderCompleted;
            Agent.GetFolderTitleAsync(action); // need to change in service
        }

    

        #endregion

        #region Private Methods

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
        /// 
        /// </summary>
        private void OptinMessages()
        {
            EventBroker.StartRefresh += () =>
                                            {
                                                IsBusy = true;
                                                IsRefreshing = true;
                                            };
            EventBroker.Refreshed += () =>
                                         {
                                             IsBusy = false;
                                             IsRefreshing = false;
                                             RaisePropertyChanged(Property.IsEmpty);
                                         };
        }

        /// <summary>
        ///  GetFolders() Completed result 
        /// </summary>
        /// <param name="action"></param>
        private void OnGetNewFolderCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            if (action.Item == null) return;
            var workspace = action.Item;
            var workspacelist = WorkspaceListItem.ToList();
            workspacelist.Add(workspace);
            WorkspaceListItem = workspacelist;
            NewFolderString.Add(workspace.ItemTitle);
            EventBroker.RaiseGetFolderString(new LoadDetailViewEventArgs { NewFolderString = NewFolderString });
            EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs { ListItem = WorkspaceListItem });
        }
        

        /// <summary>
        /// Occurs when the selected item changed in Listview
        /// </summary>
        /// <param name="sender">Listview item</param>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        private void EventBroker_SelectedItemChange(object sender, LoadWorkspaceItemEventArgs e)
        {
            SelectedItem = e.SelectedItem;
            SelectedIndex = e.SelectedIndex;
        }

        /// <summary>
        /// Occurs when change the properties 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Collection of workspaceitem Properties.</param>
        private void EventBroker_LoadProperties(object sender, LoadPropertiesEventArgs e)
        {
            if (_popUp) return;
            WorkspaceItemProperties = e.WorkspaceItemProperties;
        }

        /// <summary>
        /// Event Handler for ModifyItem Button
        /// </summary>
        private void BtnModifyItemClickEvent()
        {

            if (ModifyItem != null) if (SelectedItem != null) if (SelectedItem.ParentId != ModifyItem.ParentId) SelectedItem.ParentTitle = ModifyItem.ItemTitle;

            if (SelectedItem == null)
            {
                MessageBox.Show("Please make a selection into list.", Constants.ProjectTitle);
                return;
            }
            WindowManager.ShowAddItemScreen(DescriptionListItem, WorkspaceItemProperties, SelectedItem, Constants.ViewNames.ModifyItem);
            EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs { ItemId = SelectedItem.ItemId });

            #region "Usused Code"

            
            //AddItemViewModel AddItemVM = new AddItemViewModel();
            //AddItemVM.DescriptionListItem = DescriptionListItem;
            //AddItemVM.WorkspaceItemProperties = WorkspaceItemProperties;
            //AddItemVM.CurrentItem = SelectedItem;
            //AddItemVM.HandleIsEnableProperty(Constants.ViewNames.ModifyItem);
            //var addItem = new AddItem();
            //addItem.Initialize(AddItemVM);
            //addItem.ShowDialog();

            //AddItem = new AddItem
            //{
            //    ApplicationName = Constants.ViewNames.ModifyItem,
            //  //  ProcessFrom = Constants.ViewNames.ModifyItem
            //};
            //   AddItem.Vm.ProcessFrom = Constants.ViewNames.ModifyItem;
            //   AddItem.txtparentworkspace.IsEnabled = false;
            //   AddItem.btnsearch.IsEnabled = false;
            //   AddItem.workspacetypecombo.IsEnabled = false;
            //   AddItem.Workspacetext.IsEnabled = false;
            //   AddItem.addimage.IsEnabled = false;
            //   AddItem.txtOrderofItem.IsEnabled = false;
            //   AddItem.Vm.WorkspaceItemProperties = WorkspaceItemProperties;
            ////   AddItem.WorkspaceItemProperties = WorkspaceItemProperties;
            //   AddItem.Vm.CurrentItem = SelectedItem;
            //   AddItem.Vm.DescriptionListItem = DescriptionListItem;
            // //  AddItem.DescriptionListItem = DescriptionListItem;
            //   AddItem.ShowDialog();
            #endregion
        }

        /// <summary>
        /// Event Handler for the AddFolder Click 
        /// </summary>
        private void BtnAddFolderClickEvent()
        {
            if (NewFolderString == null)
                NewFolderString = new List<string>();
            const bool blnAddFolder = true;
            EventBroker.RaiseGetBlnFolderString(new LoadDetailViewEventArgs { BlnAddFolder = blnAddFolder });
            AddFolder();
        }

        /// <summary>
        /// Click event to view the List -partial implementation
        /// </summary>
        private void BtnListViewclickEvent()
        {
            EventBroker.RaiseVisibleList(new LoadDetailViewEventArgs { CurrentViewType = LoadDetailViewEventArgs.ListviewcontrolviewTypes.ListView });
        }

        /// <summary>
        /// Event Handler for the DetailView Click
        /// </summary>
        private void BtnDetailViewClickEvent()
        {
            EventBroker.RaiseVisibleList(new LoadDetailViewEventArgs { CurrentViewType = LoadDetailViewEventArgs.ListviewcontrolviewTypes.DetailView });
        }

        ///<summary>
        /// Event Handler for the Back Button Click
        ///</summary>
        private void BtnBackClickEvent()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            IsRefreshing = true;
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
                                if (item.ItemImage != null)
                                    info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0 ? Constants.GetEmbeddedFile("Pms.ManageWorkspaces.Resources", "CloseFolder.png") : item.ItemImage;
                                data.Add(info);
                            }
                            Mouse.OverrideCursor = null;
                            ItemId = PreviousListItem[PreviousListItem.Count - 2].Children[0].ItemId;
                            EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs { ItemId = ItemId });
                            PreviousListItem.RemoveAt(PreviousListItem.Count - 1);
                            EventBroker.RaiseGetPreviousListItem(new LoadWorkspaceItemEventArgs { PreviousListItem = PreviousListItem });
                            EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs { ListItem = data });
                        }
                    }
                }
                else
                    Mouse.OverrideCursor = null;
            }
        }


        /// <summary>
        /// Event Handler for the AddItem Click
        /// </summary>
        private void BtnAddItemClickEvent()
        {
            WindowManager.ShowAddItemScreen(null, null, null, Constants.ViewNames.AddItem);

            #region "Unused Code"
            
            // AddItem = new AddItem
            // {
            //     ApplicationName = Constants.ViewNames.AddItem,
            //     //ProcessFrom = Constants.ViewNames.AddItem,
            //     txtparentworkspace = { IsEnabled = false }
            // };
            //// AddItem.Vm.ProcessFrom = Constants.ViewNames.AddItem;
            // AddItem.ShowDialog();


            //var addItemVm = new AddItemViewModel();
            //addItemVm.HandleIsEnableProperty(Constants.ViewNames.AddItem);
            //var addItem = new AddItem()
            //                  {
            //                      txtparentworkspace = { IsEnabled = false }
            //                  };
            //addItem.Initialize(addItemVm);
            //addItem.ShowDialog();
            #endregion
        }

        #endregion

        #region Protected Methods
        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            WorkspaceId = WorkspaceRoot.Top;
            BtnAddFolderClick = new DelegateCommand(BtnAddFolderClickEvent);
            BtnAddItemClick = new DelegateCommand(BtnAddItemClickEvent);
            BtnListViewClick = new DelegateCommand(BtnListViewclickEvent);
            BtnDetailViewClick = new DelegateCommand(BtnDetailViewClickEvent);
            BtnBackClick = new DelegateCommand(BtnBackClickEvent);
            BtnModifyItemClick = new DelegateCommand(BtnModifyItemClickEvent);
        }

        #endregion

        #region "Unused Method"

        /// <summary>
        /// 
        /// </summary>
        //public void FinishRefreshState()
        //{
        //    if (WorkspaceItemCount != 0)
        //    {
        //        IsRefreshing = false;
        //        RaisePropertyChanged(Property.IsEmpty);
        //    }
        //    else
        //    {
        //        IsRefreshing = false;
        //    }

        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void EventBroker_IsRefresh(object sender, LoadDetailViewEventArgs e)
        //{
        //    IsRefreshing = true;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void EventBroker_WorkspaceItemCount(object sender, LoadDetailViewEventArgs e)
        //{
        //    WorkspaceItemCount = e.WorkspaceItemCount;
        //    //FinishRefreshState();
        //}

        /// <summary>
        /// Gets and sets WorkspaceItemSearch string with call back. 
        /// </summary>
        /// <value>The workspace item search string.</value>
        //private string _workspaceitemsearchstring;
        //public string WorkspaceItemSearchString
        //{
        //    get
        //    {
        //        return _workspaceitemsearchstring;
        //    }
        //    set
        //    {
        //        _workspaceitemsearchstring = value;
        //        if (value == string.Empty) return;
        //        Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetWorkspaceItemsBySearchStringCompleted;
        //        Agent.GetWorkspaceItemsBySearchStringAsync(_workspaceitemsearchstring, action);
        //        RaisePropertyChanged(Property.WorkspaceItemSearchString);
        //    }
        //}


        /// <summary>
        /// Event Handler for Assigning the searched WorkspaceItem to ListItem Property
        /// </summary>
        /// <param name="action"></param>
        //private void OnGetWorkspaceItemsBySearchStringCompleted(WorkspaceItemResult<WorkspaceItem> action)
        //{
        //    if(action.Items==null)return;
        //    if (action.Items.Count() == 0)
        //    {
        //        MessageBox.Show("No items match your search.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    else
        //    {
        //        var list = action.Items;
        //        var data = new ObservableCollection<WorkspaceItem>();
        //        foreach (var item in list)
        //        {
        //            var info = new WorkspaceItem
        //            {
        //                AdditionalInfoUri = item.AdditionalInfoUri,
        //                Children = item.Children,
        //                DateModified = item.DateModified,
        //                Descriptions = item.Descriptions,
        //                Id = item.Id,
        //                IsFolder = item.IsFolder,
        //                ItemId = item.ItemId,
        //                ItemImage = item.ItemImage,
        //                ItemTitle = item.ItemTitle,
        //                ParentId = item.ParentId,
        //                Properties = item.Properties,
        //                SortOrder = item.SortOrder,
        //                TypeId = item.TypeId,
        //                TypeImage = item.TypeImage,
        //                TypeTitle = item.TypeTitle
        //            };
        //            if (item.ItemImage != null)
        //                info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0 ? Constants.GetEmbeddedFile("Pms.ManageWorkspaces.Resources", "CloseFolder.png") : item.ItemImage;
        //            data.Add(info);
        //        }
        //        //EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs { ListItem = data });
        //        EventBroker.RaiseGetSearchItem(new LoadDetailViewEventArgs { ListItem = data });
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
