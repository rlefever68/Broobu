using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Constants;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Result;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.Behaviour;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class WorkspaceTreeViewViewModel : WorkspaceBrowserViewModelBase
    {

        #region Class Field/Members
        public const string LoadMock = "WorkspaceBrowserMockAgent";
        public bool PopUp;
        public bool Istreeviewselected;
        public bool Child;

        /// <summary>
        /// Class Property
        /// </summary>
        public new class Property
        {
            public const string PreviousListItem = "PreviousListItem";
            public const string WorkspaceItems = "WorkspaceItems";
            public const string WorkspaceId = "WorkspaceId";
            public const string ItemId = "ItemId";
            public const string PropertiesListItem = "PropertiesListItem";
            public const string SelectedWorkspace = "SelectedWorkspace";
            public const string Targetworkspace = "Targetworkspace";
            public const string SourceWorkspace = "SourceWorkspace";

        }
        #endregion

        #region Properties

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

        ///// <summary>
        ///// Gets or sets the Save Description 
        ///// </summary>
        //private ObservableCollection<WorkspaceItemDescription> _savedItemDesc;
        //public ObservableCollection<WorkspaceItemDescription> SavedItemDesc
        //{
        //    get
        //    {
        //        return _savedItemDesc;
        //    }

        //    set
        //    {
        //        _savedItemDesc = value;
        //        foreach (var workspaceItemDescription in value)
        //        {
        //            var info = workspaceItemDescription;
        //            info.ItemId = ItemId;
        //            Agent.RegisterDescriptionAsync(info);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Gets the descriptions (refreshed)
        ///// </summary>
        ///// <param name="obj"></param>
        //void Agent_RegisterDescriptionCompleted(WorkspaceItemResult<WorkspaceItemDescription> obj)
        //{
        //    GetDescriptionsAsync();
        //}

        /// <summary>
        /// Gets and Sets Targetworkspace Data
        /// </summary>
        //private WorkspaceItem _targetworkspace;
        //public WorkspaceItem Targetworkspace
        //{
        //    get
        //    {
        //        return _targetworkspace;
        //    }
        //    set
        //    {
        //        _targetworkspace = value;

        //        RaisePropertyChanged(Property.Targetworkspace);
        //    }
        //}

        /// <summary>
        /// Gets and Sets SourceWorkspace Data
        /// </summary>
        //private WorkspaceItem _sourceWorkspace;
        //public WorkspaceItem SourceWorkspace
        //{
        //    get
        //    {
        //        return _sourceWorkspace;
        //    }
        //    set
        //    {
        //        _sourceWorkspace = value;
        //        RaisePropertyChanged(Property.SourceWorkspace);
        //    }
        // }

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
        /// Gets or sets the workspace id.
        /// </summary>
        /// <value>The workspace id.</value>
        private bool _selectedWorkspace;
        public bool SelectedWorkspace
        {
            get { return _selectedWorkspace; }
            set
            {

                _selectedWorkspace = value;
                RaisePropertyChanged(Property.SelectedWorkspace);
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

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceTreeViewViewModel"/> class.
        /// </summary>
        public WorkspaceTreeViewViewModel()
        {
            Child = false;
            Initialize();
            //Agent.RegisterDescriptionCompleted += Agent_RegisterDescriptionCompleted;
        }

        //void EventBroker_SaveDescription(object sender, LoadDescriptionEventArgs e)
        //{
        //    if (PopUp) return;
        //    SavedItemDesc = (ObservableCollection<WorkspaceItemDescription>)e.DescriptionListItem;
        //}
        #endregion

        #region Public Methods

        /// <summary>
        /// Called for when load page
        /// </summary>
        public void LoadPage()
        {
            WorkspaceId = WorkspaceRoot.Top;
            GetFoldersAsync();
            EventBroker.TreeViewDropEnable += new EventHandler<LoadWorkspaceItemEventArgs>(EventBroker_TreeViewDropEnable);
            EventBroker.SetPopUpFlag -= EventBroker_SetPopUpFlag;
            EventBroker.SetPopUpFlag += EventBroker_SetPopUpFlag;
            EventBroker.GetId -= EventBroker_GetId;
            EventBroker.GetWorkspaceId -= EventBroker_GetWorkspaceId;
            //EventBroker.SaveDescription -= EventBroker_SaveDescription;
            EventBroker.GetId += EventBroker_GetId;
            EventBroker.GetWorkspaceId += EventBroker_GetWorkspaceId;
            //EventBroker.SaveDescription += EventBroker_SaveDescription;
            EventBroker.GetChild -= EventBroker_GetChild;
            EventBroker.GetChild += EventBroker_GetChild;
        }

        /// <summary>
        /// Calls the Asynchronous Method with callback to get Workspace Item
        /// </summary>
        public void GetFoldersAsync()
        {
            Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetFoldersCompleted;
            Agent.GetFoldersAsync(WorkspaceId, action);
        }

        /// <summary>
        /// Calls the Asynchronous Method  with callback to get Workspace Item
        /// </summary>
        public void GetWorkspaceAsync()
        {
            ActionQueue.AddQueue(new ActionQueue.QueableAction
            {
                SenderId = Guid.NewGuid(),
                EventBroker = EventBroker
            });
            Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetWorkspaceCompleted;
            Agent.GetWorkspaceAsync(WorkspaceId, action);
        }


        /// <summary>
        /// Calls the Asynchronous Method  with callback to get Descriptions
        /// </summary>
        public void GetDescriptionsAsync()
        {
            ActionQueue.AddQueue(new ActionQueue.QueableAction
            {
                SenderId = Guid.NewGuid(),
                EventBroker = EventBroker
            });
            Action<WorkspaceItemResult<WorkspaceItemDescription>> action = OnGetDescriptionsCompleted;
            Agent.GetDescriptionsAsync(ItemId, action);
        }

        /// <summary>
        /// Calls the Asynchronous Method  with callback to get Properties
        /// </summary>
        public void GetPropertiesAsync()
        {
            ActionQueue.AddQueue(new ActionQueue.QueableAction
            {
                SenderId = Guid.NewGuid(),
                EventBroker = EventBroker
            });
            Action<WorkspaceItemResult<WorkspaceItemProperty>> action = OnGetPropertiesCompleted;
            Agent.GetPropertiesAsync(ItemId, action);
        }

        /// <summary>
        /// Calls the asynchronous Method  with callback to save the Dragged Data
        /// </summary>
        public void SaveDraggedDataAsync()
        {
            //Action<WorkspaceItemResult<WorkspaceItem>> action = RegisterDraggedDataCompleted;
            ////CreateAgent().RegisterDraggedDataAsync(SourceWorkspace, Targetworkspace, action); //need to check
            //CreateAgent().RegisterDraggedDataAsync(DragDropBehavior.SourceWorkspace, DragDropBehavior.Targetworkspace, action);
        }

        /// <summary>
        /// Calss the Asynchronous Methods //todo need to check
        /// </summary>
        //public void AsyncMethod()
        //{
        //    GetWorkspaceAsync();
        //    GetDescriptionsAsync();
        //    GetPropertiesAsync();
        //}


        #endregion

        #region Protected Methods
        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters) { }
        #endregion

        #region Private Methods


        private void FinishRefreshState()
        {
            ActionQueue.DeQueue();
            int count = ActionQueue.Instance.Actions.Count;
            if (count == 0)
                EventBroker.RaiseRefreshed();
        }
        /// <summary>
        /// Save the Drag Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventBroker_TreeViewDropEnable(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (e.TreeViewDropEnable == true)
            {
                SaveDraggedDataAsync();
            }
        }

        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        private IWorkspaceBrowserAgent CreateAgent()
        {
            var agt = WorkspaceBrowserAgentFactory.CreateAgent(Constants.CreateAgentKey.Key);
            if (agt.GetType().Name == LoadMock)
            {
                EventBroker.RaiseLoadText(new LoadWorkspaceItemEventArgs { BlnLoad = true });
            }
            //Start 
            //need to change in service
            // agt.OnGetWorkspaceCompleted += AgtOnGetWorkspaceCompleted;     //   -- callback event - OnGetWorkspaceCompleted 
            //agt.OnGetFoldersCompleted += AgtOnGetFoldersCompleted;            -- callback event - OnGetFoldersCompleted
            //agt.OnGetDescriptionsCompleted += AgtOnGetDescriptionsCompleted;  -- callback event - OnGetDescriptionsCompleted
            //agt.OnGetPropertiesCompleted += AgtOnGetPropertiesCompleted;      -- callback event - OnGetPropertiesCompleted
            EventBroker.DoubleClickListView += EventBrokerDoubleClickListView;
            //End

            return agt;
        }

        /// <summary>
        ///  Event Handler for Assigning the WorkspaceItem to ListItem Property
        /// </summary>
        /// <param name="action"></param>
        private void OnGetWorkspaceCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            try
            {
                if (action.Items == null)return;
                
                var list = action.Items;
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
                    #region "Binding Image"
                    //if (item.ItemImage != null)
                    //{
                    //    info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0
                    //                         ? Constants.GetEmbeddedFile("Pms.ManageWorkspaces.Resources", "CloseFolder.png")
                    //                         : item.ItemImage;
                    //}
                    #endregion
                    data.Add(info);
                }

                EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs { ListItem = data });

                //EventBroker.RaiseSetWorkspaceChildItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = data });
                //EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs { ListItem = data });
                //EventBroker.RaiseSetWorkspaceChildItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = data });
                if (SelectedWorkspace)
                {
                    WorkspaceItems[0].Children = data.ToArray();
                    PreviousListItem = new List<WorkspaceItem>();
                    SelectedWorkspace = false;
                    if (!Istreeviewselected)
                    {
                        WorkspaceBrowserMainViewViewModel.CurrentListItem = WorkspaceItems[0];
                        Istreeviewselected = true;
                    }
                }

                #region "Unused code- need to check"
                #endregion
                if (Child)
                {
                    EventBroker.RaiseLoadChild(new LoadDetailViewEventArgs { ChildItems = data.ToList() });
                    Child = false;
                }
                else
                {
                    //  EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs { ListItem = data });// need to check
                    EventBroker.RaiseSetWorkspaceChildItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = data });
                }

            }
            finally
            {
                FinishRefreshState();
                // if (WorkspaceItems != null)
                //EventBroker.RaiseLoadWorkspaceItemCount(new LoadDetailViewEventArgs() { WorkspaceItemCount = WorkspaceItems.Count });
                //Mouse.OverrideCursor = null; //need to ch
            }
        }

        /// <summary>
        /// Assigns the workspace item to the WorkspaceItems property
        /// </summary>
        /// <param name="action"></param>
        private void OnGetFoldersCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            //var list = new ObservableCollection<WorkspaceItem>(e.Items);
            if (action.Items == null) return;
            var list = new ObservableCollection<WorkspaceItem>(action.Items);
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
                //if (item.ItemImage != null)
                //    info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0 ? Constants.GetEmbeddedFile("Pms.ManageWorkspaces.Resources", "CloseFolder.png") : item.ItemImage;
                data.Add(info);
            }
            //   data[0].ItemImage = Constants.GetEmbeddedFile("Pms.ManageWorkspaces.Resources", "DefaultOpenFolder.png");
            WorkspaceItems = data;
            EventBroker.RaiseLoadWorkspaceItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = WorkspaceItems });
        }

        /// <summary>
        /// Event Handler for Assigning the Description to DescriptionListItem Property.
        /// </summary>
        /// <param name="action">Collection of WorkspaceItemdescription</param>
        private void OnGetDescriptionsCompleted(WorkspaceItemResult<WorkspaceItemDescription> action)
        {
            if (action.Descriptions == null) return;
            EventBroker.RaiseLoadDescription(new LoadDescriptionEventArgs
            {
                DescriptionListItem = action.Descriptions,
                ItemId = ItemId
            });
            FinishRefreshState();
        }

        /// <summary>
        /// Event Handler for Assigning the property to WorkspaceItemProperties Property 
        /// </summary>
        /// <param name="action">Collection of WorkspaceItemProperty</param>
        private void OnGetPropertiesCompleted(WorkspaceItemResult<WorkspaceItemProperty> action)
        {
            if (action.Properties == null) return;
            EventBroker.RaiseLoadProperties(new LoadPropertiesEventArgs
            {
                WorkspaceItemProperties = action.Properties,
                ItemId = ItemId
            });
            FinishRefreshState();
        }

        /// <summary>
        /// Event Handler for Assigning the listviewitem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Itemid</param>
        private void EventBrokerDoubleClickListView(object sender, LoadWorkspaceItemEventArgs e)
        {
            ActionQueue.AddQueue(new ActionQueue.QueableAction
            {
                SenderId = Guid.NewGuid(),
                EventBroker = EventBroker
            });
            Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetWorkspaceCompleted;
            Agent.GetWorkspaceAsync(e.ItemId, action);
        }

        /// <summary>
        /// Partial implementation
        /// </summary>
        /// <param name="obj"></param>
        private void RegisterDraggedDataCompleted(WorkspaceItemResult<WorkspaceItem> obj)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Called for when raise the getworkspaceId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        private void EventBroker_GetWorkspaceId(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (PopUp) return;
            ItemId = e.ItemId;
            WorkspaceId = e.WorkspaceId;
            GetWorkspaceAsync();
            GetDescriptionsAsync();
            GetPropertiesAsync();
        }

        /// <summary>
        /// Called for when raise the GetId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        private void EventBroker_GetId(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (PopUp) return;
            ItemId = e.ItemId;
            GetDescriptionsAsync();
            GetPropertiesAsync();
        }

        /// <summary>
        /// Occurs when open the popup window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        private void EventBroker_SetPopUpFlag(object sender, LoadWorkspaceItemEventArgs e)
        {
            PopUp = e.PopUp;
        }

        /// <summary>
        /// Gets the child item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        private void EventBroker_GetChild(object sender, LoadWorkspaceItemEventArgs e)
        {
            Child = true;
            ItemId = e.ItemId;
            WorkspaceId = e.WorkspaceId;
            GetWorkspaceAsync();
            GetDescriptionsAsync();
            GetPropertiesAsync();
        }

        #endregion

        #region "Old Method"
        //  /// <summary>
        //  /// Gets the embedded file.
        //  /// </summary>
        //  /// <param name="assemblyName">Name of the assembly.</param>
        //  /// <param name="fileName">Name of the file.</param>
        //  /// <returns>Byte[]</returns>
        ////  public static Byte[] GetEmbeddedFile(string assemblyName, string fileName)
        // // {
        // //     var r = new WorkspaceBrowserResource();
        // //     return r.GetEmbeddedFile(assemblyName, fileName);
        ////  }


        //  /// <summary>
        //  /// Gets the high light image.
        //  /// </summary>
        //  /// <value>The high light image.</value>
        //  //public Uri HighLightImage
        //  //{
        //  //    get
        //  //    {
        //  //        return new Uri("pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/OpenFolder.png");
        //  //    }
        //  //}
        //  /// <summary>
        //  /// Gets the close image.
        //  /// </summary>
        //  /// <value>The high light image.</value>
        //  //public Uri CloseImage
        //  //{
        //  //    get
        //  //    {
        //  //        return new Uri("pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/DefaultCloseFolder.png");
        //  //    }
        //  //}

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
