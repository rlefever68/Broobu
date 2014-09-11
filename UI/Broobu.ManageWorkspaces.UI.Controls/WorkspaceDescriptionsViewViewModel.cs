using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Pms.WorkspaceBrowser.Contract.Domain;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;
using Pms.WorkspaceBrowser.UI.Controls.ViewModel;

namespace Pms.WorkspaceBrowser.UI.Controls
{
  public  class WorkspaceDescriptionsViewViewModel :WorkspaceBrowserViewModelBase
  {

      public bool PopUp; 

      #region Property
      /// <summary>
      /// Declare the constants
      /// </summary>
      public new class Property
      {
          public const String DescriptionListItem = "DescriptionListItem";
          
          public const string AddItem = "AddItem";
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
      }

      private void EventBroker_SelectedItemChange(object sender, LoadWorkspaceItemEventArgs e)
      {
          if (e.SelectedItem==null) return;
          SelectedItem = e.SelectedItem;
      }

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
          } 
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
      }

      #endregion

      #region Properties
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
      /// Gets or sets the item id.
      /// </summary>
      /// <value>The item id.</value>
      private string _itemId;
      public string ItemId
      {
          get { return _itemId; }
          set
          {
              _itemId = value;
          }
      }

      #endregion
      
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

      private RelayCommand _deleteDescription;
      public ICommand DeleteDescription
      {
          get
          {
              _deleteDescription = new RelayCommand(param => DeleteDescriptionFun());
              return _deleteDescription;
          }
      }

      private void DeleteDescriptionFun()
      {
          var result = MessageBox.Show("Do you really want to delete?", "WorkSpace Browser", MessageBoxButton.YesNo);

          switch (result)
          {
              case MessageBoxResult.Yes:
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
          AddItem=new AddItem();
          AddItem.ApplicationName = Constants.ViewNames.ModifyDesc;
          AddItem.ProcessFrom = Constants.ViewNames.ModifyDesc;
          AddItem.Vm.ProcessFrom = Constants.ViewNames.ModifyDesc;
          AddItem.Vm.DescriptionListItem = DescriptionListItem;
          AddItem.Vm.CurrentItem = SelectedItem;
          AddItem.DescriptionListItem = DescriptionListItem;
          AddItem.descriptiontab.Focus();
          AddItem.propertytab.IsEnabled = false;
          AddItem.txtparentworkspace.IsEnabled = false;
          AddItem.workspacetypecombo.IsEnabled = false;
          AddItem.Workspacetext.IsEnabled = false;
          AddItem.btnsearch.IsEnabled = false;
          AddItem.txtOI.IsEnabled = false;
          AddItem.addimage.IsEnabled = false;
          AddItem.ShowDialog();
          EventBroker.RaiseGetId(new LoadWorkspaceItemEventArgs() {ItemId = SelectedItem.ItemId});
      }
    }
}
