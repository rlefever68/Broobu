using System.Collections.ObjectModel;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class WorkspaceNavigatorViewViewModel:WorkspaceBrowserViewModelBase
    {
        #region Fields/Members
        private bool _popUp;

        public new class Property
        {
            public const string WorkspaceItems = "WorkspaceItems";
        }

        #endregion

        #region Properties

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
        /// Gets the current selected Item.
        /// </summary>
        public WorkspaceItem SelectedItem { get; set; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceNavigatorViewViewModel"/> class.
        /// </summary>
        public WorkspaceNavigatorViewViewModel()
        {
            Initialize();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the page.
        /// </summary>
        public void LoadPage()
        {
            EventBroker.SetPopUpFlag -= EventBroker_SetPopUpFlag;
            EventBroker.SetPopUpFlag += EventBroker_SetPopUpFlag;
            EventBroker.LoadWorkspaceItem -= EventBroker_LoadWorkspaceItem;
            EventBroker.LoadWorkspaceItem += EventBroker_LoadWorkspaceItem;
        }

        /// <summary>
        /// Occurs when click the ok button
        /// </summary>
        public void RaiseEvent()
        {
            EventBroker.RaiseLoadSearchFolder(new LoadWorkspaceItemEventArgs { SelectedItem = SelectedItem });
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
            EventBroker.SetPopUpFlag -= EventBroker_SetPopUpFlag;
            EventBroker.SetPopUpFlag += EventBroker_SetPopUpFlag;
            EventBroker.LoadWorkspaceItem -= EventBroker_LoadWorkspaceItem;
            EventBroker.LoadWorkspaceItem += EventBroker_LoadWorkspaceItem;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Handles the LoadWorkspaceItem event of the EventBroker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs.LoadWorkspaceItemEventArgs"/> instance containing the event data.</param>
        private void EventBroker_LoadWorkspaceItem(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (_popUp) return;
            WorkspaceItems = e.WorkspaceItems;
        }

        /// <summary>
        /// Handles the SetPopUpFlag event of the EventBroker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs.LoadWorkspaceItemEventArgs"/> instance containing the event data.</param>
        private void EventBroker_SetPopUpFlag(object sender, LoadWorkspaceItemEventArgs e)
        {
            _popUp = e.PopUp;
        }

        #endregion

        protected override void StartAuthenticatedSession()
        {
            throw new System.NotImplementedException();
        }

        public override void TerminateAuthenticatedSession(System.Action onSessionTerminated = null)
        {
            throw new System.NotImplementedException();
        }
    }

}
