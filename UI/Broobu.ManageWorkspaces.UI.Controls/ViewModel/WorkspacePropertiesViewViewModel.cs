using System.Collections.Generic;
using System.Windows.Input;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class WorkspacePropertiesViewViewModel : WorkspaceBrowserViewModelBase
    {
        #region Class / Fields / Members

        public bool PopUp;
        public ICommand ShowAddPropertyPopUp { get; set; }

        /// <summary>
        /// Declare the constants
        /// </summary>
        public new class Property
        {
            public const string WorkspaceItemProperties = "WorkspaceItemProperties";
            public const string AddItem = "AddItem";
        }

        # endregion

        #region Properties

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
        /// Gets or sets the ItemId
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the SelectedItem
        /// </summary>
        public WorkspaceItem SelectedItem { get; set; }

        #endregion

        # region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspacePropertiesViewViewModel()
        {
            Initialize();
        }

        # endregion

        # region Protected Methods

        /// <summary>
        /// Eventbrokers Initialization
        /// </summary>
        /// <param name="parameters"></param>
        protected override void InitializeInternal(object[] parameters)
        {
            EventBroker.LoadProperties += EventBroker_LoadProperties;
            EventBroker.SetPopUpFlag += (snd, e) => PopUp = e.PopUp;
            EventBroker.SelectedItemChange += EventBroker_SelectedItemChange;
            ShowAddPropertyPopUp = new DelegateCommand(ShowAddPropertyPopUpEvent);
        }

        # endregion

        # region Private Methods


        /// <summary>
        /// Occurs when the Item selection gets changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Selected workspceitem.</param>
        private void EventBroker_SelectedItemChange(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (e.SelectedItem == null) return;
            SelectedItem = e.SelectedItem;
        }

        /// <summary>
        /// Code for loading properties of that particular Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventBroker_LoadProperties(object sender, LoadPropertiesEventArgs e)
        {
            if (PopUp) return;
            WorkspaceItemProperties = e.WorkspaceItemProperties;
            ItemId = e.ItemId;
        }

        /// <summary>
        /// Click event to popup the AddItem window .
        /// </summary>
        private void ShowAddPropertyPopUpEvent()
        {
            WindowManager.ShowAddItemScreen(null, WorkspaceItemProperties, SelectedItem, Constants.ViewNames.ModifyProperty);

            //var addItemVm = new AddItemViewModel();
            //addItemVm.WorkspaceItemProperties = WorkspaceItemProperties;
            //addItemVm.HandleIsEnableProperty(Constants.ViewNames.ModifyProperty);
            //var addItem = new AddItem();
            //addItem.Initialize(addItemVm);
            //addItem.ShowDialog();

            //AddItem = new AddItem
            //{
            //  ApplicationName = Constants.ViewNames.ModifyProperty,
            // ProcessFrom = Constants.ViewNames.ModifyProperty
            //};
            //   AddItem.Vm.ProcessFrom = Constants.ViewNames.ModifyProperty;
            //   AddItem.Vm.WorkspaceItemProperties = WorkspaceItemProperties;
            //   AddItem.Vm.CurrentItem = SelectedItem;
            ////   AddItem.WorkspaceItemProperties = WorkspaceItemProperties;
            //   AddItem.propertytab.Focus();
            //   AddItem.descriptiontab.IsEnabled = false;
            //   AddItem.txtparentworkspace.IsEnabled = false;
            //   AddItem.workspacetypecombo.IsEnabled = false;
            //   AddItem.btnsearch.IsEnabled = false;
            //   AddItem.Workspacetext.IsEnabled = false;
            //   AddItem.txtOrderofItem.IsEnabled = false;
            //   AddItem.addimage.IsEnabled = false;
            //   AddItem.ShowDialog();
            EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs { ItemId = SelectedItem.ItemId });
        }

        # endregion



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
