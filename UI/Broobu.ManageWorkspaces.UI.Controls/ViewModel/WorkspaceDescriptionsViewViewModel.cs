using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Result;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class WorkspaceDescriptionsViewViewModel : WorkspaceBrowserViewModelBase
    {

        #region Field/Members
        public bool PopUp;
        public ICommand ShowAddDescriptionPopUp { get; set; }
        public ICommand DeleteDescription { get; set; }
        #endregion

        #region Constant Class

        /// <summary>
        /// Declare the constants
        /// </summary>
        public new class Property
        {
            public const String DescriptionListItem = "DescriptionListItem";
            public const string AddItem = "AddItem";
            public const string DescriptionSelectedItem = "DescriptionSelectedItem";
            public const string CurrentItem = "CurrentItem";

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Itemid
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the selected Items.
        /// </summary>
        public WorkspaceItem SelectedItem { get; set; }

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
                CheckAndPutImage();
                RaisePropertyChanged(Property.DescriptionListItem);
            }
        }

        private void CheckAndPutImage()
        {
            if (_descriptionlistItem == null) return;
            foreach (var item in _descriptionlistItem.Where(item => item.Image == null || item.Image.Length == 0))
                item.Image = GetLocalItemImageForBreadCrumb();
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
        /// Gets or sets the current selected description item.
        /// </summary>
        private WorkspaceItemDescription _descriptionSelectedItem;
        public WorkspaceItemDescription DescriptionSelectedItem
        {
            get
            {
                return _descriptionSelectedItem;
            }
            set
            {
                _descriptionSelectedItem = value;
                RaisePropertyChanged(Property.DescriptionSelectedItem);
            }
        }

        /// <summary>
        /// Gets or sets the result description.
        /// </summary>
        private WorkspaceItemDescription _resultDescription;
        public WorkspaceItemDescription ResultDescription
        {
            get
            {
                return _resultDescription;
            }
            set
            {
                _resultDescription = value;
                //commneted- need to change in service 
                //Agent.GetDescriptionsAsync(DescriptionSelectedItem.ItemId);
            }
        }

        /// <summary>
        /// Gets or sets the current selected WorkspaceItemDescription
        /// </summary>
        private WorkspaceItemDescription _currentitem;
        public WorkspaceItemDescription CurrentItem
        {
            get
            {
                return _currentitem;
            }
            set
            {
                _currentitem = value;
                RaisePropertyChanged(Property.CurrentItem);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceDescriptionsViewViewModel()
        {
            Initialize();
        }

        #endregion

        # region Protected Methods

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            EventBroker.LoadDescription += EventBroker_LoadDescription;
            EventBroker.SetPopUpFlag += (snd, e) => PopUp = e.PopUp;
            EventBroker.SelectedItemChange += EventBroker_SelectedItemChange;
            ShowAddDescriptionPopUp = new DelegateCommand(ShowAddDescriptionPopUpEvent);
            DeleteDescription = new DelegateCommand(DeleteDescriptionClick);
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// Gets the current selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventBroker_SelectedItemChange(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (e.SelectedItem == null) return;
            SelectedItem = e.SelectedItem;
        }

        /// <summary>
        /// Sets the DescriptionListItem and ItemId
        /// </summary>
        /// <param name="sender">LoadDescriptionEventArgs</param>
        /// <param name="e">DescriptionListItem and ItemId</param>
        private void EventBroker_LoadDescription(object sender, LoadDescriptionEventArgs e)
        {
            if (PopUp) return;
            DescriptionListItem = e.DescriptionListItem;
            ItemId = e.ItemId;
            Mouse.OverrideCursor = null;
            //EventBroker.RaiseLoadWorkspaceItemCount(new LoadDetailViewEventArgs() { WorkspaceItemCount = DescriptionListItem.Count() });
        }

        /// <summary>
        /// Called for Deleting the selected description with callback
        /// </summary>
        private void DeleteDescriptionClick()
        {
            if (CurrentItem == null)
            {
                MessageBox.Show("Please select any one row from description view.", Constants.ProjectTitle,
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show("Do you really want to delete?", Constants.ProjectTitle, MessageBoxButton.YesNo, MessageBoxImage.Information);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (CurrentItem != null)
                    {
                        Action<WorkspaceItemResult<WorkspaceItemDescription>> action = OnDeleteDescriptionCompleted;
                        Agent.DeleteDescriptionAsync(CurrentItem.Id, action);
                    }

                    break;
                case MessageBoxResult.No:
                    break;
            }
        }


        /// <summary>
        /// Click event to popup the AddItem window 
        /// </summary>
        private void ShowAddDescriptionPopUpEvent()
        {

            WindowManager.ShowAddItemScreen(DescriptionListItem, null, SelectedItem, Constants.ViewNames.ModifyDesc);
            //AddItemViewModel AddItemVM = new AddItemViewModel();
            //AddItemVM.DescriptionListItem = DescriptionListItem;
            //AddItemVM.HandleIsEnableProperty(Constants.ViewNames.ModifyDesc);
            //var addItem = new AddItem();
            //addItem.Initialize(AddItemVM);
            //addItem.ShowDialog();


            //  AddItem = new AddItem
            //  {
            //      ApplicationName = Constants.ViewNames.ModifyDesc,
            //      ProcessFrom = Constants.ViewNames.ModifyDesc
            //  };
            //  AddItem.Vm.ProcessFrom = Constants.ViewNames.ModifyDesc;
            //  AddItem.Vm.DescriptionListItem = DescriptionListItem;
            //  AddItem.Vm.CurrentItem = SelectedItem;
            ////  AddItem.DescriptionListItem = DescriptionListItem;
            //  AddItem.descriptiontab.Focus();
            //  AddItem.propertytab.IsEnabled = false;
            //  AddItem.txtparentworkspace.IsEnabled = false;
            //  AddItem.workspacetypecombo.IsEnabled = false;
            //  AddItem.Workspacetext.IsEnabled = false;
            //  AddItem.btnsearch.IsEnabled = false;
            //  AddItem.txtOrderofItem.IsEnabled = false;
            //  AddItem.addimage.IsEnabled = false;
            //  AddItem.ShowDialog();
            EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs { ItemId = SelectedItem.ItemId });
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
        /// need to check - SaveResult
        /// </summary>
        /// <param name="action"></param>
        private void OnDeleteDescriptionCompleted(WorkspaceItemResult<WorkspaceItemDescription> action)
        {
            ResultDescription = action.Result;
        }

        # endregion

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
