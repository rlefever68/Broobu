using System;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Result;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class WorkspaceSearchControlViewModel : WorkspaceBrowserViewModelBase
    {
        #region Class fields/members
        public ICommand BtnSearchClick { get; set; }

        /// <summary>
        /// Declare the constants
        /// </summary>
        public new class Property
        {
            public const String WorkspaceItemSearchString = "WorkspaceItemSearchString";
        }

        #endregion

        #region Properties

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
                RaisePropertyChanged(Property.WorkspaceItemSearchString);
            }
        }

        # endregion

        #region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceSearchControlViewModel()
        {
            Initialize();
            WorkspaceItemSearchString = Constants.ViewNames.SearchText;
        }

        #endregion

        # region Public Methods

        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        public IWorkspaceBrowserAgent CreateAgent()
        {
            var agt = WorkspaceBrowserAgentFactory.CreateAgent(Constants.CreateAgentKey.Key);
            return agt;
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
        /// Fires the RaiseGetSearchString event
        /// </summary>
        public void Search()
        {
            if (WorkspaceItemSearchString != string.Empty)
            {
                ActionQueue.AddQueue(new ActionQueue.QueableAction
                                         {
                                             SenderId = Guid.NewGuid(),
                                             EventBroker = EventBroker
                                         });
                Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetWorkspaceItemsBySearchStringCompleted;
                Agent.GetWorkspaceItemsBySearchStringAsync(WorkspaceItemSearchString, action);
            }
            else
            {
                MessageBox.Show("No items match your search", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// Event Handler for Assigning the searched  workspaceItem to listItem property
        /// </summary>
        /// <param name="action"></param>
        private void OnGetWorkspaceItemsBySearchStringCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {

            if (action.Items == null) return;
            if (action.Items.Count() == 0)
            {
                MessageBox.Show("No items match your search.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                WindowManager.ShowSearchResultScreen(action.Items);
                //PopUpListViewModel searchVm = new PopUpListViewModel();
                //searchVm.ListItem = action.Items; 
                //var window = new PopUpListView();
                //window.Initialize(searchVm);
                //window.ShowDialog();
            }
            //EventBroker.RaiseLoadWorkspaceItemCount(new LoadDetailViewEventArgs() { WorkspaceItemCount = action.Items.Count() });
            FinishRefreshState();
        }
        /// <summary>
        /// 
        /// </summary>
        private void FinishRefreshState()
        {
            ActionQueue.DeQueue();
            int count = ActionQueue.Instance.Actions.Count;
            if (count == 0)
                EventBroker.RaiseRefreshed();
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
            BtnSearchClick = new DelegateCommand(BtnSearchClickEvent);
        }

        # endregion

        #region Private Methods

        /// <summary>
        /// Click event to search the workspace item
        /// </summary>
        private void BtnSearchClickEvent()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Search();
        }

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
