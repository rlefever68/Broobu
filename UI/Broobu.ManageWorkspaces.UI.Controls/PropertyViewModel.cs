using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.WorkspaceBrowser.Domain;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class PropertyViewModel : WorkspaceBrowserViewModelBase
    {
        #region Property
        /// <summary>
        /// Declare the constants
        /// </summary>
        public new class Property
        {
            public const string WorkspaceItemProperties = "WorkspaceItemProperties";
        }

        # endregion

        #region Constructor
        /// <summary>
      /// Constructor Declaration
      /// </summary>
        public PropertyViewModel()
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


      # endregion

    }
}
