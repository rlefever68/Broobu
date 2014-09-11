using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pms.Framework.UI;
using Pms.WorkspaceBrowser.Contract.Agent;
using Pms.WorkspaceBrowser.Contract.Domain;
using Pms.WorkspaceBrowser.Contract.Interfaces;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;
using Pms.WorkspaceBrowser.UI.Controls.ViewModel;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class WorkspaceListViewViewModel : WorkspaceBrowserViewModelBase
    {
        public bool PopUp; 

        #region Property

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
        }
        
        #endregion

        #region Constructor Declaration
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceListViewViewModel()
        {
            Initialize();
            PreviousListItem=new List<WorkspaceItem>();
            ItemSelectedCommand = new DelegateCommand(ListViewSelectionChanged);
            _doubleClickCommand = new DelegateCommand(GetWorkspaceAsyncItem);
            SelectedIndex = -1;
            
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            EventBroker.LoadDetailView += EventBroker_LoadDetailView;
            EventBroker.GetFolderString += (snd, e) =>NewFolderString = e.NewFolderString;
            EventBroker.SetPopUpFlag += (snd, e) => PopUp = e.PopUp;
          //  EventBroker.GetPreviousListItem += (snd, e) => PreviousListItem = e.PreviousListItem;
        }

        /// <summary>
        /// Load the List view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventBroker_LoadDetailView(object sender, LoadDetailViewEventArgs e)
        {
            if(PopUp) return;
            ListItem = e.ListItem;
            //Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<WorkspaceItem> _deleteListItem;
        public ObservableCollection<WorkspaceItem> DeleteListItem
        {
            get
            {
                return _deleteListItem;
            }
            set
            {
                _deleteListItem = value;
                CreateAgent().DeleteWorkspaceItemsAsync(DeleteListItem.ToArray());
            }
        }

       
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICommand ItemSelectedCommand { get; set; }

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
                var searchworkspace = new WorkspaceItem { Children = _listItem.ToArray() };
                PreviousListItem.Add(searchworkspace);
               // EventBroker.RaiseGetListItem(new LoadDetailViewEventArgs() {ListItem = ListItem});
                EventBroker.RaiseGetPreviousListItem(new LoadWorkspaceItemEventArgs() { PreviousListItem = PreviousListItem });
                RaisePropertyChanged(Property.ListItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool VisibilityListOrDetailView
        {
            get;
            set;
        }




        /// <summary>
        /// Gets the Cancel Button Click
        /// </summary>
        ///<value>The Button List View Click</value>
        /// 
        private RelayCommand _newitem;
        public ICommand newitem
        {
            get
            {
                _newitem = new RelayCommand(param => BtnnewitemClickEvent());
                return _newitem;
            }
        }

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
        /// 
        /// </summary>
        private static void BtnnewitemClickEvent()
        {
            var additem = new AddItem();
            
            additem.ShowDialog();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        private IWorkspaceBrowserAgent CreateAgent()
        {
           // var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Mock);
            var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Instance);
            agt.AddFolderCompleted += (r) => agtOnGetNewFolderCompleted(r.Item);
            return agt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void agtOnGetNewFolderCompleted(WorkspaceItem item)//private void agtOnGetNewFolderCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            var workspace = new WorkspaceItem();
            workspace = item;
            var workspacelist = new List<WorkspaceItem>();
            workspacelist = ListItem.ToList();
            workspacelist.Add(workspace);
            workspace.ParentId = ListItem.ToList()[0].ParentId;
            workspace.ParentTitle = ListItem.ToList()[0].ParentTitle;
            workspace.IsFolder = true;
            workspace.DateModified = DateTime.Now.Date;
            //Due to error in service
           // CreateAgent().RegisterWorkspaceAsync(workspace);
            ListItem = workspacelist;
            NewFolderString.Add(workspace.ItemTitle);
            EventBroker.RaiseGetFolderString(new LoadDetailViewEventArgs(){NewFolderString = NewFolderString});
        }

    
        /// <summary>
        /// Gets and Sets the List string
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
                _newFolderString=value;
                RaisePropertyChanged(Property.NewFolderString);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddFolder()
        {
            CreateAgent().AddFolderAsync(NewFolderString);
        }
        #endregion
        private readonly ICommand _doubleClickCommand;
        
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
                EventBroker.RaiseSelectedItemChange(new LoadWorkspaceItemEventArgs(){SelectedItem = SelectedItem,SelectedIndex = SelectedIndex});
            }
        }

        /// <summary>
        /// Gets the Listview DoubleClickCommand 
        /// </summary> 
        public ICommand DoubleClickCommand
        {
            get
            {
                return _doubleClickCommand;
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
        /// Calls the Asynchronous method to get Workspace Item 
        /// </summary>
        private void GetWorkspaceAsyncItem()
        {
            if ((SelectedItem.Children != null) && SelectedItem.Children.Length > 0)
            {
                Mouse.OverrideCursor = Cursors.Wait;
               // PreviousListItem.Add(SelectedItem);
               // EventBroker.RaiseGetPreviousListItem(new LoadWorkspaceItemEventArgs() { PreviousListItem = PreviousListItem });
                NewFolderString = new List<string>();
                EventBroker.RaiseDoubleClickListView(new LoadWorkspaceItemEventArgs() { ItemId = SelectedItem.Id });
            }

        }
        /// <summary>
        /// 
        /// </summary>
        private void ListViewSelectionChanged()
        {
         
            if (NewFolderString == null)
                NewFolderString = new List<string>();
            if ((SelectedItem != null))
            {
                EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs()
                                           {
                                               ItemId = SelectedItem.ItemId,SelectedItem = SelectedItem,SelectedIndex = SelectedIndex
                                           });
            }
            
            Mouse.OverrideCursor = null;
        }


    }
}
