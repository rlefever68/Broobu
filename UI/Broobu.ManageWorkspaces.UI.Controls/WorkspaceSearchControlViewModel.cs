using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;
using Pms.WorkspaceBrowser.UI.Controls.ViewModel;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class WorkspaceSearchControlViewModel :WorkspaceBrowserViewModelBase
    {
        #region Property
      /// <summary>
      /// Declare the constants
      /// </summary>
      public new class Property
      {
          public const String WorkspaceItemSearchString = "WorkspaceItemSearchString";
      }

      #endregion

      #region Constructor
      /// <summary>
      /// Constructor Declaration
      /// </summary>
      public WorkspaceSearchControlViewModel()
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

      #region relay command
      /// <summary>
      /// Gets the Search Button Click
      /// </summary>
      ///<value>The Button Search Click</value>
      private RelayCommand _btnSearchClick;
      public ICommand BtnSearchClick
      {
          get
          {
              _btnSearchClick = new RelayCommand(param => BtnSearchClickEvent());
              return _btnSearchClick;
          }
      }

      /// <summary>
      /// Click event to search the workspace item
      /// </summary>
      private void BtnSearchClickEvent()
      {
         // WorkspaceItemSearchString = WorkspaceItemSearchString;
        EventBroker.RaiseGetSearchString(new LoadWorkspaceItemEventArgs() {SearchString = WorkspaceItemSearchString});
      }

        public void Search()
        {
            EventBroker.RaiseGetSearchString(new LoadWorkspaceItemEventArgs() { SearchString = WorkspaceItemSearchString });
        }
       #endregion
    }
}
