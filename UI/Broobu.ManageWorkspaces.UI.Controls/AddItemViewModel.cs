using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Pms.WorkspaceBrowser.Contract;
using Pms.WorkspaceBrowser.Contract.Agent;
using Pms.WorkspaceBrowser.Contract.Domain;
using Pms.WorkspaceBrowser.Contract.Interfaces;
using Pms.WorkspaceBrowser.UI.Controls.ApplicationEventArgs;
using Pms.WorkspaceBrowser.UI.Controls.ViewModel;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class AddItemViewModel :WorkspaceBrowserViewModelBase
    {

        public string ProcessFrom { get; set; }
        public string ProcessType { get; set; }

        #region Property
        /// <summary>
        /// Declare the constants
        /// </summary>
        public new class Property
        {
            public const string DescriptionListItem = "DescriptionListItem";
            public const string WorkspaceItemProperties = "WorkspaceItemProperties";
            public const string OrderOfItem = "OrderOfItem";
            public const string ItemName = "ItemName";
            public const string Type = "Type";
            public const string ParentofItem = "ParentofItem";
            public const string SelectedItem = "SelectedItem";
            public const string Languages = "Languages";
            public const string Types = "Types";
            public const string ItemImage = "ItemImage";
            public const string CurrentItem = "CurrentItem";
            public const string TypeId = "TypeId";
        }

        # endregion

        #region Constructor
      /// <summary>
      /// Constructor Declaration
      /// </summary>
      public AddItemViewModel()
      {
         Initialize();
      }

      protected override void InitializeInternal(object[] parameters)
      {
         GetLanguagesAsync();
         GetTypesAsync();
         EventBroker.LoadSearchFolder += EventBroker_LoadSearchFolder;
      }

      private void EventBroker_LoadSearchFolder(object sender, LoadWorkspaceItemEventArgs e)
      {
          SelectedItem = e.SelectedItem;
      }

     #endregion

        #region Properties

       /// <summary>
       /// Gets the agent.
       /// </summary>
       /// <value>The agent.</value>
       private IWorkspaceBrowserAgent _agent;
       private IWorkspaceBrowserAgent Agent
       {
           get { return _agent ?? (_agent = CreateAgent()); }
       }

       private WorkspaceItem _currentItem;
       public WorkspaceItem CurrentItem
       {
           get
           {
               return _currentItem;
           }
           set
           {
               _currentItem = value;
               ParentofItem = CurrentItem.ParentTitle;
               ItemName = CurrentItem.ItemTitle;
               ItemId = CurrentItem.ItemId;
               OrderOfItem =Convert.ToString(CurrentItem.SortOrder);
               TypeId = CurrentItem.TypeId;
           }
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
               RaisePropertyChanged(Property.SelectedItem);
               ParentofItem = SelectedItem.ItemTitle;
           }
       }

       private ObservableCollection<TableLanguage> _languages;
       public ObservableCollection<TableLanguage> Languages
       {
           get
           {
               return _languages;
           }
           set
           {
               _languages = value;
               RaisePropertyChanged(Property.Languages);
           }
       }

       private ObservableCollection<WorkspaceItem> _types;
       public ObservableCollection<WorkspaceItem> Types
       {
           get
           {
               return _types;
           }
           set
           {
               _types = value;
               RaisePropertyChanged(Property.Types);
           }
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
                RaisePropertyChanged(Property.DescriptionListItem);
            }
        }

        /// <summary>
        /// Gets or sets the Save Item Description
        /// </summary>
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
                if (ProcessFrom != Constants.ViewNames.AddItem)
                    RegisterDescription();
            }
        }

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
        /// Gets or sets the save item Property
        /// </summary>
        private ObservableCollection<WorkspaceItemProperty> _saveItemProperty;
        public ObservableCollection<WorkspaceItemProperty> SaveItemProperty
        {
            get
            {
                return _saveItemProperty;
            }
            set
            {
                _saveItemProperty = value;
                if (ProcessFrom !=Constants.ViewNames.AddItem)
                    RegisterProperty();
            }
        }
     
        
        /// <summary>
        /// Gets or sets the ItemId
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the workspace Id
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the parentItem
        /// </summary>
        private string _parentofItem;
        public string ParentofItem
        {
            get
            {
                return _parentofItem;
            }
            set
            {
                _parentofItem = value;
                RaisePropertyChanged(Property.ParentofItem);
            }
        }

        /// <summary>
        /// Gets or sets the Type name
        /// </summary>
        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                RaisePropertyChanged(Property.Type);
            }
        }

        private string _typeId;
        public string TypeId
        {
            get
            {
                return _typeId;
            }
            set
            {
                _typeId = value;
                RaisePropertyChanged(Property.TypeId);
            }
        }

        /// <summary>
        /// Gets or sets the ItemName
        /// </summary>
        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
                RaisePropertyChanged(Property.ItemName);
            }
        }

        /// <summary>
        /// Gets or sets the OrderofItem
        /// </summary>
        private string _orderofItem;
        public string  OrderOfItem
        {
            get
            {
                return _orderofItem;
            }
            set
            {
                _orderofItem = value;
                RaisePropertyChanged(Property.OrderOfItem);
            }
        }

        private byte[] _itemImage;
        public byte[] ItemImage
        {
            get
            {
                return _itemImage;
            }
            set
            {
                _itemImage = value;
                RaisePropertyChanged(Property.ItemImage);
            }
        }
      
    # endregion

   # region Private Methods

        /// <summary>
        /// Calls the Asynchronous Method to get Workspace Item
        /// </summary>
        public void GetLanguagesAsync()
        {
            Agent.GetLanguagesAsync();
            //var item = new ObservableCollection<TableLanguage>
            //               {
            //                   new TableLanguage {CultureId = "nl-BE", Title = "Dutch(Belgium)"},
            //                   new TableLanguage {CultureId = "en-ZA", Title = "South coria"},
            //                   new TableLanguage {CultureId ="en-US",Title = "English"}
            //               };
            //Languages = item;

        }

        /// <summary>
        /// Call the Asynchronous method to get the Description
        /// </summary>
        public void GetDescriptionAsync()
        {

            Agent.GetDescriptionsAsync(ItemId);
        }

        /// <summary>
        /// Call the Asynchronous method to get the Properties
        /// </summary>
        public void GetPropertiesAsync()
        {
            Agent.GetPropertiesAsync(ItemId);
        }

        public void GetWorkspaceItemAsync()
        {
            Agent.GetWorkspaceAsync(WorkspaceId);
        }

        public void GetTypesAsync()
        {
            var info = new ObservableCollection<WorkspaceItem>
                           {
                               new WorkspaceItem {TypeId = "BASE_TYPE_UI_TRV_FOLDER",ItemTitle = "BASE_TYPE_UI_TRV_FOLDER"},
                               new WorkspaceItem {TypeId = "BASE_TYPE_UI_TRV_NODE_TEXT",ItemTitle = "BASE_TYPE_UI_TRV_NODE_TEXT"},
                               new WorkspaceItem {TypeId = "BASE_TYPE_WPI_DESCRIPTION",ItemTitle= "BASE_TYPE_WPI_DESCRIPTION"}

                           };
            Types = info;
        }

        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        private IWorkspaceBrowserAgent CreateAgent()
        {
            // var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Mock);
            var agt = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Instance);
            agt.GetLanguagesCompleted += (r) => AgtOnGetLanguagesCompleted(r.Items); //agt.OnGetLanguagesCompleted += AgtOnGetLanguagesCompleted;
            return agt;
        }
        /// <summary>
        /// Assigns the workspace item to the WorkspaceItems property
        /// </summary>
        /// <param name="items"></param>
        private void AgtOnGetLanguagesCompleted(IEnumerable<WorkspaceItem> items)//private void AgtOnGetLanguagesCompleted(object sender, WorkspaceItemsEventArgs e)
        {
            var list = new ObservableCollection<WorkspaceItem>(items);
            var item = new ObservableCollection<TableLanguage>();
            foreach (var row in list.Select(info => new TableLanguage
                    {
                        CultureId = info.ItemId, Title = info.ItemTitle
                    }))
            {
                item.Add(row);
            }
            Languages = item;
        }

        /// <summary>
        /// Save the new Property
        /// </summary>
        private void RegisterProperty()
        {
            foreach (var workspaceItemProperty in SaveItemProperty)
            {
                var info = workspaceItemProperty;
                info.ItemId = ItemId;
                info.PropertyTypeId = "BASE_TYPE_WPI_PROPERTY";
                Agent.RegisterPropertyAsync(info);
            }
        }

        /// <summary>
        /// Save the new description item.
        /// </summary>
        private void RegisterDescription()
        {
            foreach (var workspaceItemDescription in SavedItemDesc)
            {
                var info = workspaceItemDescription;
                info.ItemId = ItemId;
                //info.TypeId = "BASE_TYPE_WPI_DESCRIPTION";
                Agent.RegisterDescriptionAsync(info);
            }
            
        }

        private WorkspaceItemDescription[] ItemDescription(ObservableCollection<WorkspaceItemDescription> info)
        {
            var item = new WorkspaceItemDescription[info.Count];
            var index=0;
            foreach(var desc in info)
            {
                item.SetValue(desc,index);
                index += 1;
            }
            return item;
        }

        private WorkspaceItemProperty[] ItemProperty(ObservableCollection<WorkspaceItemProperty> info)
        {
            var item = new WorkspaceItemProperty[info.Count];
            var index = 0;
            foreach (var desc in info)
            {
                item.SetValue(desc, index);
                index += 1;
            }
            return item;
        }

        /// <summary>
        /// Occurs when click the save button
        /// </summary>
        public void RegisterWorkspaceItem()
        {
            if (string.IsNullOrEmpty(ParentofItem))
            {
                MessageBox.Show("Please select parent of item.",Constants.ProjectTitle,MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(ItemName))
            {
                MessageBox.Show("Item name should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(TypeId))
            {
                MessageBox.Show("Type should not be empty.", Constants.ProjectTitle,MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(OrderOfItem))
            {
                MessageBox.Show("Order no should not be empty.", Constants.ProjectTitle,MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }

            if (IsNumeric(OrderOfItem))
            {
                MessageBox.Show("Order no should be numeric!", Constants.ProjectTitle,MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }
         
            var info = new WorkspaceItem();
            info.ParentId = SelectedItem.ParentId;
            info.TypeId = TypeId;
            info.ItemTitle = ItemName;
            info.ItemImage = ItemImage;
            info.SortOrder = Convert.ToInt32(OrderOfItem);
            info.Descriptions = ItemDescription(SavedItemDesc);
            info.Properties = ItemProperty(SaveItemProperty);
            info.DateModified = DateTime.Now.Date;
            //Agent.RegisterWorkspaceAsync(info);
            //MessageBox.Show("WorkspaceItem Saved Successfully!", Constants.ProjectTitle, MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void BtnSearchFolder()
        {
            EventBroker.RaiseSetPopUpFlag(new LoadWorkspaceItemEventArgs { PopUp = true });
            var pop = new PopUpTreeView();
            pop.ShowDialog();
            EventBroker.RaiseSetPopUpFlag(new LoadWorkspaceItemEventArgs { PopUp = false });
        }

        /// <summary>
        /// Get the Button Search Folder
        /// </summary>
        /// <value>The Button AddWorkspace Click</value>
        private RelayCommand _btnSearchFolderClick;
        public ICommand BtnSearchFolderClick
        {
            get
            {
                _btnSearchFolderClick = new RelayCommand(param => BtnSearchFolder());
                return _btnSearchFolderClick;
            }
        }

        public static bool IsNumeric(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotWholePattern.IsMatch(strTextEntry);
        }

        # endregion
   
    }
}
