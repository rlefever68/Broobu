using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Pms.WorkspaceBrowser.Contract.Domain;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;
using Pms.WorkspaceBrowser.UI.Controls.ViewModel;


namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class WorkspacePropertiesViewViewModel:WorkspaceBrowserViewModelBase
    {
        public bool PopUp; 

        #region Property
        /// <summary>
        /// Declare the constants
        /// </summary>
        public new class Property
        {
            public const string WorkspaceItemProperties = "WorkspaceItemProperties";
           
            public const string AddItem = "AddItem";
        }

        # endregion

        # region "Constructor"

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspacePropertiesViewViewModel()
        {
            Initialize();
        }

        # endregion

        protected override void InitializeInternal(object[] parameters)
        {

            EventBroker.LoadProperties += EventBroker_LoadProperties;
            EventBroker.SetPopUpFlag += (snd, e) => PopUp = e.PopUp;
            EventBroker.SelectedItemChange += EventBroker_SelectedItemChange;
        }

        private void EventBroker_SelectedItemChange(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (e.SelectedItem==null) return;
            SelectedItem = e.SelectedItem;
        }

        private void EventBroker_LoadProperties(object sender, LoadPropertiesEventArgs e)
        {
            if (PopUp) return;
            WorkspaceItemProperties = e.WorkspaceItemProperties;
            ItemId = e.ItemId;
        }

        public WorkspaceItem SelectedItem { get; set; }


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

        public string ItemId { get; set; }
      
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
        #endregion

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
        /// Click event to popup the AddItem window 
        /// </summary>
        private void ShowAddPropertyPopUpEvent()
        {
            AddItem = new AddItem();
            AddItem.ApplicationName = Constants.ViewNames.ModifyProperty;
            AddItem.ProcessFrom = Constants.ViewNames.ModifyProperty;
            AddItem.Vm.ProcessFrom = Constants.ViewNames.ModifyProperty;
            AddItem.Vm.WorkspaceItemProperties = WorkspaceItemProperties;
            AddItem.Vm.CurrentItem = SelectedItem;
            AddItem.WorkspaceItemProperties = WorkspaceItemProperties;
            AddItem.propertytab.Focus();
            AddItem.descriptiontab.IsEnabled = false;
            AddItem.txtparentworkspace.IsEnabled = false;
            AddItem.workspacetypecombo.IsEnabled = false;
            AddItem.btnsearch.IsEnabled = false;
            AddItem.Workspacetext.IsEnabled = false;
            AddItem.txtOI.IsEnabled = false;
            AddItem.addimage.IsEnabled = false;
            AddItem.ShowDialog();
            EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs() { ItemId = SelectedItem.ItemId });
        }

    }
}
