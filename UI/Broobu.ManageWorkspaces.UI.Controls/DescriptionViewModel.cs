using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Shapes;
using Pms.WorkspaceBrowser.Agent;
using Pms.WorkspaceBrowser.Agent.Interfaces;
using Pms.WorkspaceBrowser.Domain;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class DescriptionViewModel :WorkspaceBrowserViewModelBase
    {
        #region Property
      /// <summary>
      /// Declare the constants
      /// </summary>
      public new class Property
      {
          public const String DescriptionListItem = "DescriptionListItem";
          public const string AllLanguages = "AllLanguages";
          public const string AllTypes = "AllTypes";
      }

      #endregion

      #region Constructor
      /// <summary>
      /// Constructor Declaration
      /// </summary>
      public DescriptionViewModel()
      {
          Initialize();
          CreateAgent().GetLanguagesAsync();
          
      }

      void DescriptionViewModel_OnGetLanguagesCompleted(object sender, WorkspaceItemsEventArgs e)
      {
          throw new NotImplementedException();
      }




      /// <summary>
      /// Initializes the ViewModel the first time it is called.
      /// This method will be called from the View that implements the
      /// ViewModel
      /// </summary>
      /// <param name="parameters">The parameters used to initialize the ViewModel</param>
      protected override void InitializeInternal(object[] parameters)
      {
          EventBroker.LoadDescription += (snd, e) => DescriptionListItem = e.DescriptionListItem;
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
              EventBroker.RaiseSaveDescription(new LoadDescriptionEventArgs {DescriptionListItem = SavedItemDesc});
          }
      }

      public string ItemId { get; set;}

      # endregion




        # region "For getting languages"

      /// <summary>
      /// Calls the Asynchronous Method to get Workspace Item
      /// </summary>
      public void GetLanguagesAsync()
      {
          Agent.GetLanguagesAsync();
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
      /// Creates the agent.
      /// </summary>
      /// <returns></returns>
      private IWorkspaceBrowserAgent CreateAgent()
      {
          // var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Mock);
          var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Instance);
          agt.OnGetLanguagesCompleted+=AgtOnGetLanguagesCompleted;
          return agt;
      }



      /// <summary>
      /// Assigns the workspace item to the WorkspaceItems property
      /// </summary>
      /// <param name="sender">The Name of the sender</param>
      /// <param name="e">WorkspaceItemsEventArgs</param>
      private void AgtOnGetLanguagesCompleted(object sender, WorkspaceItemsEventArgs e)
      {
          var list = new ObservableCollection<WorkspaceItem>(e.Items);
          AllLanguages = list.Select(l => l.ItemTitle).ToArray();
          //AllTypes = list.Select(l => l.TypeTitle).ToArray();
      }
      /// <summary>
      /// Gets or sets the Languages.
      /// </summary>
      /// <value>The workspace items.</value>
      private Array _allLanguages;
      public Array AllLanguages
      {
          get
          {
              return _allLanguages;
          }
          set
          {
              _allLanguages = value;
          }
      }

      /// <summary>
      /// Gets or sets the Types.
      /// </summary>
      /// <value>The workspace items.</value>
      private Array _allTypes;
      public Array AllTypes
      {
          get
          {
              return _allTypes;
          }
          set
          {
              _allTypes = value;
          }
      }
        # endregion
    }
}
