using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pms.WorkspaceBrowser.Contract.Agent;
using Pms.WorkspaceBrowser.Contract.Constants;
using Pms.WorkspaceBrowser.Contract.Domain;
using Pms.WorkspaceBrowser.Contract.Interfaces;
using Pms.WorkspaceBrowser.Resources;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public  class WorkspaceTreeViewViewModel:WorkspaceBrowserViewModelBase
    {

        #region "Field Members"
        public const string LoadMock = "WorkspaceBrowserMockAgent";
        public bool PopUp;
        #endregion

        #region Class
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

        #region Constructor
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceTreeViewViewModel()
        {
            Initialize();
           //// GetFoldersAsync();
           // //EventBroker.GetId += EventBroker_GetId;
           // EventBroker.GetWorkspaceId += EventBroker_GetWorkspaceId;
           // EventBroker.SaveDescription += EventBroker_SaveDescription;
        }

        void EventBroker_SaveDescription(object sender, LoadDescriptionEventArgs e)
        {
            if(PopUp) return;
            SavedItemDesc = (ObservableCollection<WorkspaceItemDescription>) e.DescriptionListItem;
        }
        #endregion

      
        private void EventBroker_GetWorkspaceId(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (PopUp) return;
            ItemId = e.ItemId;
            WorkspaceId = e.WorkspaceId;
            GetWorkspaceAsync();
            GetDescriptionsAsync();
            GetPropertiesAsync();
        }

        private void EventBroker_GetId(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (PopUp) return;
            ItemId = e.ItemId;
            GetDescriptionsAsync();
            GetPropertiesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        protected override void InitializeInternal(object[] parameters)
        {
            //WorkspaceId = WorkspaceRoot.Top;
            // GetFoldersAsync();
            //EventBroker.GetId += EventBroker_GetId;
            ////EventBroker.GetPreviousListItem += (snd, e) => PreviousListItem = e.PreviousListItem;
        }

        public void LoadPage()
        {
            WorkspaceId = WorkspaceRoot.Top;
            GetFoldersAsync();
            EventBroker.SetPopUpFlag -= EventBroker_SetPopUpFlag;
            EventBroker.SetPopUpFlag += EventBroker_SetPopUpFlag;
            EventBroker.GetId -= EventBroker_GetId;
            EventBroker.GetWorkspaceId -= EventBroker_GetWorkspaceId;
            EventBroker.SaveDescription -= EventBroker_SaveDescription;
            EventBroker.GetId += EventBroker_GetId;
            EventBroker.GetWorkspaceId += EventBroker_GetWorkspaceId;
            EventBroker.SaveDescription += EventBroker_SaveDescription;
        }

        private void EventBroker_SetPopUpFlag(object sender, LoadWorkspaceItemEventArgs e)
        {
            PopUp = e.PopUp;
        }

       

        #region Private Methods


        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        private IWorkspaceBrowserAgent CreateAgent()
        {
          // var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Mock);
           var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Instance);
            if (agt.GetType().Name == LoadMock)
            {
                EventBroker.RaiseLoadText(new LoadWorkspaceItemEventArgs { blnLoad = true });
            }
            
            agt.GetWorkspaceCompleted += (r) => AgtOnGetWorkspaceCompleted(r.Items);
            agt.GetFoldersCompleted += (r) => AgtOnGetFoldersCompleted(r.Items);
            //agt.OnGetFullWorkspaceItemCompleted += AgtOnGetFullWorkspaceItemCompleted;
            agt.GetDescriptionsCompleted += (r) => AgtOnGetDescriptionsCompleted(r.Descriptions);
            agt.GetPropertiesCompleted += (r) => AgtOnGetPropertiesCompleted(r.Properties);
            EventBroker.DoubleClickListView += EventBrokerDoubleClickListView;
            //agt.OnGetWorkspaceItemsBySearchStringCompleted += AgtOnGetWorkspaceItemsBySearchStringCompleted;
            //agt.OnSaveWorkSpaceItemDescCompleted += AgtOnWorkspaceCompleted;
            //agt.OnGetNewFolderCompleted += agtOnGetNewFolderCompleted;
            agt.RegisterDraggedDataCompleted += (r) => agtOnRegisterDraggedDataCompleted(r.WorkspaceSource, r.WorkspaceTarget);
            return agt;
        }

        private void agtOnRegisterDraggedDataCompleted(WorkspaceItem workspaceSource, WorkspaceItem workspaceTarget)//private void agtOnRegisterDraggedDataCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            
        }
        /// <summary>
        /// Event Handler for Assigning the property to WorkspaceItemProperties Property
        /// </summary>
        /// <param name="properties"></param>
        private void AgtOnGetPropertiesCompleted(IEnumerable<WorkspaceItemProperty> properties)//private void AgtOnGetPropertiesCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            
            EventBroker.RaiseLoadProperties(new LoadPropertiesEventArgs() { WorkspaceItemProperties = properties,ItemId = ItemId});
           // WorkspaceItemProperties = e.Properties;
           // BindPropertyDescription();
        }

        /// <summary>
        /// Event Handler for Assigning the Description to DescriptionListItem Property
        /// </summary>
        /// <param name="descriptions"></param>
        private void AgtOnGetDescriptionsCompleted(IEnumerable<WorkspaceItemDescription> descriptions)//private void AgtOnGetDescriptionsCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            EventBroker.RaiseLoadDescription(new LoadDescriptionEventArgs() { DescriptionListItem = descriptions, ItemId = ItemId});
           // DescriptionListItem = e.Descriptions;
           // BindPropertyDescription();
        }
        /// <summary>
        /// Event Handler for Assigning the WorkspaceItem to ListItem Property
        /// </summary>
        /// <param name="items"></param>
        private void AgtOnGetWorkspaceCompleted(IEnumerable<WorkspaceItem> items)// private void AgtOnGetWorkspaceCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            //if (AddWorkspace != null && (!AddWorkspace._blnaddworkspace || !AddItem.Blnadditem))
            //{

                //if (WorkspaceMainView != null)
                //{
                //    //WorkspaceMainView.wsNavigator.wsTreeView
                //    WorkspaceMainView.wsNavigator.wsTreeView.WorkspaceItemsChild =
                //        new ObservableCollection<WorkspaceItem>(e.Items);

                //}
            //}
            //else
            //{
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
                    //if (item.ItemImage != null)
                    //{
                        info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0
                                             ? GetEmbeddedFile("Pms.WorkspaceBrowser.Resources", "CloseFolder.png")
                                             : item.ItemImage;
                    //}
                    data.Add(info);
                }
            
                EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs{ListItem = data});
                EventBroker.RaiseSetWorkspaceChildItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = data });
                if (SelectedWorkspace)
                {
                   // EventBroker.RaiseSetWorkspaceChildItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = data });
                   WorkspaceItems[0].Children = data.ToArray();
                  // EventBroker.RaiseLoadWorkspaceItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = WorkspaceItems });
                    PreviousListItem=new List<WorkspaceItem>();
                  // PreviousListItem.Add(WorkspaceItems[0]);
                  // EventBroker.RaiseGetPreviousListItem(new LoadWorkspaceItemEventArgs() { PreviousListItem = PreviousListItem });
                    // WorkspaceItems = WorkspaceMainView.wsNavigator.wsTreeView.WorkspaceItems;
                  //  WorkspaceItemsChild =
                      //   new ObservableCollection<WorkspaceItem>(e.Items);
                   // if (PreviousListItem.Count == 0)
                   // {
                      //  WorkspaceMainView.wsNavigator.wsTreeView.WorkspaceItems[0].Children = ListItem.ToArray();
                       // WorkspaceItems = WorkspaceMainView.wsNavigator.wsTreeView.WorkspaceItems;
                       // WorkspaceMainView.wsNavigator.wsTreeView.Vm.PreviousListItem.Add(WorkspaceItems[0]);
                    // }
                    SelectedWorkspace = false;
                }
               // ListItem = data;
                //ChildrenListItem = e.Item;
              //  if (View == List || View == null)
                  //  BindListViewData();
               // else
                   // BindDetailViewData();
                //if (WorkspaceMainView != null)
                //{
                //if (WorkspaceMainView.wsNavigator.wsTreeView._selected)
                //{
                //    WorkspaceMainView.wsNavigator.wsTreeView.WorkspaceItemsChild =
                //        new ObservableCollection<WorkspaceItem>(e.Items);
                //    if (WorkspaceMainView.wsNavigator.wsTreeView.Vm.PreviousListItem.Count == 0)
                //    {
                //        WorkspaceMainView.wsNavigator.wsTreeView.WorkspaceItems[0].Children = ListItem.ToArray();
                //        WorkspaceItems = WorkspaceMainView.wsNavigator.wsTreeView.WorkspaceItems;
                //        WorkspaceMainView.wsNavigator.wsTreeView.Vm.PreviousListItem.Add(WorkspaceItems[0]);
                //    }
                //}
                //}
           // }

        }

        /// <summary>
        /// Assigns the workspace item to the WorkspaceItems property
        /// </summary>
        /// <param name="items">WorkspaceItemsEventArgs</param>
        private void AgtOnGetFoldersCompleted(IEnumerable<WorkspaceItem> items)//private void AgtOnGetFoldersCompleted(object sender, WorkspaceItemsEventArgs e)
        {

            var list = new ObservableCollection<WorkspaceItem>(items);
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
                info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0 ? GetEmbeddedFile("Pms.WorkspaceBrowser.Resources", "DefaultOpenFolder.png") : item.ItemImage;
                //info.ItemImage = item.IsFolder || item.ItemImage.Count() == 0 ? GetEmbeddedFile("Pms.WorkspaceBrowser.Resources", "CloseFolder.png") : item.ItemImage;
                data.Add(info);
            }


            WorkspaceItems = data;
            EventBroker.RaiseLoadWorkspaceItem(new LoadWorkspaceItemEventArgs { WorkspaceItems = WorkspaceItems });


        }

        /// <summary>
        /// Event Handler for Assigning the listviewitem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventBrokerDoubleClickListView(object sender, LoadWorkspaceItemEventArgs e)
        {
            Agent.GetWorkspaceAsync(e.ItemId);
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
        /// Calss the Asynchronous Methods
        /// </summary>
        public void AsyncMethod()
        {
            GetWorkspaceAsync();
            GetDescriptionsAsync();
            GetPropertiesAsync();
        }
        /// <summary>
        /// Calls the Asynchronous Method to get Workspace Item
        /// </summary>
        public void GetWorkspaceAsync()
        {
            Agent.GetWorkspaceAsync(WorkspaceId);
        }

        /// <summary>
        /// Calls the Asynchronous Method to get Descriptions
        /// </summary>
        public void GetDescriptionsAsync()
        {
            Agent.GetDescriptionsAsync(ItemId);
        }

        /// <summary>
        /// Calls the Asynchronous Method to get Properties
        /// </summary>
        public void GetPropertiesAsync()
        {
            Agent.GetPropertiesAsync(ItemId);
        }

        /// <summary>
        /// Calls the asynchronous Method to save the Dragged Data
        /// </summary>
        public void SaveDraggedDataAsync()
        {
           CreateAgent().RegisterDraggedDataAsync(SourceWorkspace, Targetworkspace);
        }


        /// <summary>
        /// Gets the embedded file.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Byte[]</returns>
        public static Byte[] GetEmbeddedFile(string assemblyName, string fileName)
        {
            var r = new WorkspaceBrowserResource();
            return r.GetEmbeddedFile(assemblyName, fileName);
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

                //  Items = CreateAgent().GetFullWorkspaceItem(_itemId);
                RaisePropertyChanged(Property.ItemId);
            }
        }

        /// <summary>
        /// Gets or sets the Save Description 
        /// </summary>
        private ObservableCollection<WorkspaceItemDescription> _savedItemDesc;
        public ObservableCollection<WorkspaceItemDescription> SavedItemDesc
        {
            get
            {
                return _savedItemDesc;
            }

            set
            {
                _savedItemDesc = value;
                foreach (var workspaceItemDescription in value)
                {
                    var info = new WorkspaceItemDescription();
                    info = workspaceItemDescription;
                    info.ItemId = ItemId;
                    Agent.RegisterDescriptionAsync(info);
                }
                GetDescriptionsAsync();
            }
        }

        /// <summary>
        /// Gets and Sets Targetworkspace Data
        /// </summary>
        private WorkspaceItem _targetworkspace;
        public WorkspaceItem Targetworkspace
        {
            get
            {
                return _targetworkspace;
            }
            set
            {
                _targetworkspace = value;

                RaisePropertyChanged(Property.Targetworkspace);

            }
        }

        /// <summary>
        /// Gets and Sets SourceWorkspace Data
        /// </summary>
        private WorkspaceItem _sourceWorkspace;
        public WorkspaceItem SourceWorkspace
        {
            get
            {
                return _sourceWorkspace;
            }
            set
            {
                _sourceWorkspace = value;

                RaisePropertyChanged(Property.SourceWorkspace);

            }
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
                //  WorkspaceItems = new ObservableCollection<WorkspaceItem>(CreateAgent().GetWorkspace(_workspaceId));

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

        /// <summary>
        /// Gets the high light image.
        /// </summary>
        /// <value>The high light image.</value>
        public Uri HighLightImage
        {
            get
            {
                return new Uri("pack://application:,,,/Pms.WorkspaceBrowser.Resources;component/Application-icons/OpenFolder.png");
            }
        }
        /// <summary>
        /// Gets the close image.
        /// </summary>
        /// <value>The high light image.</value>
        public Uri CloseImage
        {
            get
            {
                return new Uri("pack://application:,,,/Pms.WorkspaceBrowser.Resources;component/Application-icons/DefaultCloseFolder.png");
            }
        }

        #endregion

        
       
    }
}
