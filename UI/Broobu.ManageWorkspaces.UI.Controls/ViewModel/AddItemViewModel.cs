using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Result;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.Converters;


namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class AddItemViewModel : WorkspaceBrowserViewModelBase
    {

        #region Fields/Members
        // public string ProcessFrom { get; set; }
        public ICommand BtnSearchFolderClick { get; set; }

        public GridControl GrdWorkspaceDescriptions;
        public GridControl GrdListViewProperty;
        public PopupImageEdit Addimage;
        private IList _modifyDescription;
        private BitmapImage _imageBitmapsource;
        private static int PropertiesCountBeforeModification;
        private static int _pageLoadCount;

        /// <summary>
        /// Gets or sets the Description Information
        /// </summary>
        public ObservableCollection<WorkspaceItemDescription> Line { get; set; }

        /// <summary>
        /// Gets or sets the Modify descriptions.
        /// </summary>
        public WorkspaceItemDescription[] ModifyDescription { get; set; }


        /// <summary>
        /// Gets or sets the SaveItemProperty
        /// </summary>
        public ObservableCollection<WorkspaceItemProperty> SaveItemProp { get; set; }

        /// <summary>
        /// Gets or sets the Property Information
        /// </summary>
        public ObservableCollection<WorkspaceItemProperty> ListViewProperty { get; set; }

        public class CustomEditorLocalizer : EditorLocalizer
        {
            protected override void PopulateStringTable()
            {
                base.PopulateStringTable();
                AddString(EditorStringId.ImageEdit_OpenFileFilter, "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG");
            }
        }

        #endregion

        #region "Command"

        public ICommand DrilldownHeaderClicked { get; set; }

        /// <summary>
        /// Gets the Save Button Command
        /// </summary>
        public ICommand BtnSaveCommand
        {
            get
            {
                return new DelegateCommand(HandleBtnSaveCommand);
            }
        }

        /// <summary>
        /// Gets the Delete ButtonCommand
        /// </summary>
        public ICommand BtnDeleteCommand
        {
            get
            {
                return new DelegateCommand(HandleBtnDeleteCommand);
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteFocusedRow control.
        /// </summary>
        private void HandleBtnDeleteCommand()
        {
            if (TabctrlSelectedIndex == 1)
            {
                DeleteDescriptionItem();
            }
            else
            {
                DeletePropertyListItem();
            }
        }


        /// <summary>
        /// Handle the Click event for SaveCommand
        /// </summary>
        private void HandleBtnSaveCommand()
        {
            switch (ApplicationName)
            {
                case Constants.ViewNames.ModifyDesc:
                    //Desc
                    DescriptionSave();
                    break;
                case Constants.ViewNames.ModifyProperty:
                    //Prop
                    PropertySave();
                    break;
                case Constants.ViewNames.AddItem:
                    _imageBitmapsource = (BitmapImage)Addimage.Source;
                    ItemImage = ImageToByteArray(_imageBitmapsource);
                    //Desc
                    DescriptionSave();
                    //Prop
                    PropertySave();
                    ItemImage = ItemImage;
                    RegisterWorkspaceItem();
                    Reset();
                    Addimage.Source = null;
                    GrdWorkspaceDescriptions.ItemsSource = new ObservableCollection<WorkspaceItemDescription>();
                    GrdListViewProperty.ItemsSource = new ObservableCollection<WorkspaceItemProperty>();
                    break;
                case Constants.ViewNames.ModifyItem:
                    //Desc
                    DescriptionSave();
                    //Prop
                    PropertySave();
                    break;
            }
        }



        #endregion

        #region "WorkspaceDesciptionView    Events"

        #region "Public Method"


        /// <summary>
        /// Handle the WorkspaceDescriptionsGrid Events
        /// </summary>
        public void HandleWorkSapceDescriptionEvents()
        {
            ((TableView)GrdWorkspaceDescriptions.View).RowUpdated += ViewRowUpdated;
            ((TableView)GrdWorkspaceDescriptions.View).ShowingEditor += ViewShowingEditor;
            ((TableView)GrdWorkspaceDescriptions.View).InvalidRowException += ViewInvalidRowException;
            ((TableView)GrdWorkspaceDescriptions.View).ValidateRow += ViewValidateRow;
        }
        /// <summary>
        /// Sets the Descrioption Item in to the Local Property
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<WorkspaceItemDescription> GetData()
        {
            if (DescriptionListItem == null) return null;
            var obj = new ObservableCollection<WorkspaceItemDescription>(DescriptionListItem.ToList());
            return (obj);
        }
        /// <summary>
        /// Gets the save Item from Description Grid
        /// </summary>
        public void DescriptionSave()
        {
            SavedItemDesc = new ObservableCollection<WorkspaceItemDescription>();

            if (ApplicationName == Constants.ViewNames.AddItem)
            {
                SavedItemDesc = (ObservableCollection<WorkspaceItemDescription>)GrdWorkspaceDescriptions.ItemsSource;
            }
            else
            {
                if (Line == null) return;
                foreach (var workspaceItemProperty in Line.Where(workspaceItemProperty => String.IsNullOrEmpty(workspaceItemProperty.Id)))
                {
                    SavedItemDesc.Add(workspaceItemProperty);
                }
            }


            //Modify
            if (Line != null)
                DescriptionListItem = Line;
            if (_modifyDescription.Count >= 1)
            {
                int index = 0;
                ModifyDescription = new WorkspaceItemDescription[_modifyDescription.Count];
                foreach (var item in _modifyDescription)
                {
                    ModifyDescription[index] = (WorkspaceItemDescription)item;
                    index += 1;
                }
                if (_modifyDescription.Count > 0)
                {
                    ModifyDescription = ModifyDescription;
                    foreach (var modifydesc in ModifyDescription)
                    {
                        if(!SavedItemDesc.Contains(modifydesc))
                        SavedItemDesc.Add(modifydesc);
                    }
                }
            }

            SavedItemDesc = SavedItemDesc;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DeleteDescriptionItem()
        {
            if (GrdWorkspaceDescriptions.Columns["Delete"].IsEnabled)
            {
                var result = MessageBox.Show("Are you sure want to delete?", Constants.ProjectTitle,
                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:

                        if (GrdWorkspaceDescriptions.View.FocusedRowHandle == GridControl.NewItemRowHandle)
                        {
                            GrdWorkspaceDescriptions.View.CancelRowEdit();
                            return;
                        }
                        var descinfo = (WorkspaceItemDescription)GrdWorkspaceDescriptions.View.FocusedRow;
                        if (!string.IsNullOrEmpty(descinfo.Id))
                        {
                            DescriptionId = descinfo.Id;
                            ((TableView)GrdWorkspaceDescriptions.View).DeleteRow(
                                  Convert.ToInt32((GrdWorkspaceDescriptions.View).FocusedRowData.ControllerVisibleIndex.ToString()));
                        }
                        else
                        {
                            ((TableView)GrdWorkspaceDescriptions.View).DeleteRow(
                                 Convert.ToInt32((GrdWorkspaceDescriptions.View).FocusedRowData.ControllerVisibleIndex.ToString()));
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            GrdWorkspaceDescriptions.Columns["Delete"].IsEnabled = true;
        }
        #endregion

        #region "Events"


        /// <summary>
        /// Handle validate row when enter the newrow in Description grid
        /// </summary>
        /// <param name="sender">Description Grid</param>
        /// <param name="e">GridRowValidationEventArgs</param>
        private static void ViewValidateRow(object sender, GridRowValidationEventArgs e)
        {

            if (e.Row == null) return;
            var image = ((WorkspaceItemDescription)e.Row).Image;
            if (image == null)
            {
                e.IsValid = false;
                MessageBox.Show("Image should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }


            var cultureId = ((WorkspaceItemDescription)e.Row).CultureId;
            if (string.IsNullOrEmpty(cultureId))
            {
                e.IsValid = false;
                MessageBox.Show("Language should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }

            var title = ((WorkspaceItemDescription)e.Row).Title;
            if (string.IsNullOrEmpty(title))
            {
                e.IsValid = false;
                MessageBox.Show("Title should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }

            var typeId = ((WorkspaceItemDescription)e.Row).TypeId;
            if (string.IsNullOrEmpty(typeId))
            {
                e.IsValid = false;
                MessageBox.Show("Type should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }

            var uri = ((WorkspaceItemDescription)e.Row).AdditionalInfoUri;
            if (string.IsNullOrEmpty(uri))
            {
                e.IsValid = false;
                MessageBox.Show("AdditionalInfouri should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }
        }
        /// <summary>
        /// Handles the invalid row exception for description view
        /// </summary>
        /// <param name="sender">Description Grid</param>
        /// <param name="e">InvalidRowExceptionEventArgs</param>
        private static void ViewInvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        /// <summary>
        /// Check the validation when edit the existing row
        /// </summary>
        /// <param name="sender">grdWorkspaceDescriptions</param>
        /// <param name="e">ShowingEditorEventArgs</param>
        private void ViewShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle) return;
            if (DescriptionListItem == null) return;
        }

        /// <summary>
        /// Used to get the updated row from the description grid for updating the data into Service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewRowUpdated(object sender, RowEventArgs e)
        {
            if (e.Row == null) return;
            var info = (WorkspaceItemDescription)(e.Row);
            if (string.IsNullOrEmpty(info.Id)) return;

            if (_modifyDescription.Count == 0)
            {
                _modifyDescription.Add(e.Row);
                return;
            }

            if (_modifyDescription.Contains(e.Row))
            {
                _modifyDescription.Remove(e.Row);
                _modifyDescription.Add(e.Row);
            }
            else
            {
                _modifyDescription.Add(e.Row);
            }

        }

        #endregion

        #endregion

        #region "WorkspaceProperty ListView Events"

        #region "Public Method"


        public void DeletePropertyListItem()
        {

            if (WorkspaceItemProperties != null)
            {
                if (WorkspaceItemProperties.Cast<object>().Where(propertyinfo => (GrdListViewProperty.View.FocusedRow) == propertyinfo).Any())
                {
                    GrdListViewProperty.Columns["Delete"].IsEnabled = false;
                }
            }
            if (GrdListViewProperty.Columns["Delete"].IsEnabled)
            {
                var result = MessageBox.Show("Are you sure want to delete?", Constants.ProjectTitle,
                                             MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (GrdListViewProperty.View.FocusedRow != null)
                        {
                            if (WorkspaceItemProperties != null)
                                if (WorkspaceItemProperties.Cast<object>().Where(workspaceProperties => (GrdListViewProperty.View.FocusedRow) != workspaceProperties).Any())
                                {
                                    ((TableView)GrdListViewProperty.View).DeleteRow(Convert.ToInt32((GrdListViewProperty.View).FocusedRowData.ControllerVisibleIndex.ToString()));
                                }
                        }
                        else if (GrdListViewProperty.View.FocusedRowHandle == GridControl.NewItemRowHandle)
                        {
                            GrdListViewProperty.View.CancelRowEdit();
                        }
                        else
                        {
                            ((TableView)GrdListViewProperty.View).DeleteRow(Convert.ToInt32((GrdListViewProperty.View).FocusedRowData.ControllerVisibleIndex.ToString()));
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                if (GrdListViewProperty.View.FocusedRowHandle != GridControl.NewItemRowHandle)
                {
                    var propertyinfo = (WorkspaceItemProperty)GrdListViewProperty.View.FocusedRow;
                    if (string.IsNullOrEmpty(propertyinfo.Id))
                    {
                        var result = MessageBox.Show("Are you sure want to delete?", Constants.ProjectTitle,
                                                MessageBoxButton.YesNo, MessageBoxImage.Question);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                ((TableView)GrdListViewProperty.View).DeleteRow(Convert.ToInt32((GrdListViewProperty.View).FocusedRowData.ControllerVisibleIndex.ToString()));
                                break;
                            case MessageBoxResult.No:
                                break;
                        }
                    }

                }
                else
                {
                    var result = MessageBox.Show("Are you sure want to delete?", Constants.ProjectTitle, MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            GrdListViewProperty.View.CancelRowEdit();
                            break;
                        case MessageBoxResult.No:
                            break;
                    }

                }
            }
            GrdListViewProperty.Columns["Delete"].IsEnabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void HandleWorkspacePropertyEvents()
        {
            ((TableView)GrdListViewProperty.View).InvalidRowException += Propertyview_InvalidRowException;
            ((TableView)GrdListViewProperty.View).ShowingEditor += ViewShowingEditorProperty;
            ((TableView)GrdListViewProperty.View).ValidateRow += Propertyview_ValidateRow;
        }
        /// <summary>
        /// Gets or sets the Local Property Information
        /// </summary>
        /// <returns>Collection of Property Information</returns>
        public ObservableCollection<WorkspaceItemProperty> GetDataProperty()
        {
            var obj = new ObservableCollection<WorkspaceItemProperty>();
            foreach (var workspaceItemDescription in WorkspaceItemProperties)
            {
                obj.Add(workspaceItemDescription);
            }
            return (obj);
        }
        /// <summary>
        /// Gets the save Item from property Grid
        /// </summary>
        public void PropertySave()
        {
            SaveItemProp = new ObservableCollection<WorkspaceItemProperty>();

            if (ApplicationName != Constants.ViewNames.AddItem)
            {
                if (WorkspaceItemProperties != null)
                {
                    for (int i = 1; i <= GrdListViewProperty.VisibleRowCount; i++)
                    {
                        if (i > WorkspaceItemProperties.Count())
                        {
                            SaveItemProp.Add(GrdListViewProperty.GetRowByListIndex(i - 1) as WorkspaceItemProperty);
                        }
                    }
                    SaveItemProperty = SaveItemProp;
                    WorkspaceItemProperties = ListViewProperty;
                }
            }
            else
            {
                for (int i = 1; i <= GrdListViewProperty.VisibleRowCount; i++)
                {
                    SaveItemProp.Add(GrdListViewProperty.GetRowByListIndex(i - 1) as WorkspaceItemProperty);
                }
                SaveItemProperty = SaveItemProp;
                WorkspaceItemProperties = SaveItemProp; //need to check //todo
                GrdListViewProperty.ItemsSource = ListViewProperty;
            }
        }
        #endregion


        #region "Events"

        /// <summary>
        /// Handle validate row when enter the newrow in property grid
        /// </summary>
        /// <param name="sender">Property Gridview</param>
        /// <param name="e">GridRowValidationEventArgs</param>
        private static void Propertyview_ValidateRow(object sender, GridRowValidationEventArgs e)
        {
            if (e.Row == null) return;
            var propname = ((WorkspaceItemProperty)e.Row).PropertyName;
            if (string.IsNullOrEmpty(propname))
            {
                e.IsValid = false;
                MessageBox.Show("PropertyName should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }

            var propvalue = ((WorkspaceItemProperty)e.Row).PropertyValue;
            if (string.IsNullOrEmpty(propvalue))
            {
                e.IsValid = false;
                MessageBox.Show("Property value should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }
        }


        /// <summary>
        /// Does the row editing is available(For Editable).
        /// </summary>
        /// <param name="sender">grdWorkspaceDescriptions Grid</param>
        /// <param name="e">ShowingEditorEventArgs</param>
        private void ViewShowingEditorProperty(object sender, ShowingEditorEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle) return;
            if (WorkspaceItemProperties != null)
            {
                e.Cancel = WorkspaceItemProperties.Count() > (GrdListViewProperty.View).FocusedRowData.ControllerVisibleIndex;
            }
        }



        /// <summary>
        /// Handles the invalid row exception for the property view
        /// </summary>
        /// <param name="sender">Property Grid</param>
        /// <param name="e">InvalidRowExceptionEventArgs</param>
        private static void Propertyview_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        #endregion


        #endregion

        #region Constant Class
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
            _modifyDescription = new ObservableCollection<WorkspaceItemDescription>().ToList();
            _pageLoadCount = 0;
            Agent.RegisterDescriptionCompleted += Agent_RegisterDescriptionCompleted;
            Agent.RegisterPropertyCompleted += Agent_RegisterPropertyCompleted;
        }

        #endregion

        #region Properties

        public int TabctrlSelectedIndex { get; set; }
        public bool IsParentItemEnable { get; set; }
        public bool IsBtnSearchEnable { get; set; }
        public bool IsNameEnable { get; set; }
        public bool IsImageEnable { get; set; }
        public bool IsTypeEnable { get; set; }
        public bool IsOrderOfItemEnable { get; set; }
        public bool IsPropertyGridEnable { get; set; }
        public bool IsDescGridEnable { get; set; }
        public bool IsPropertySelected { get; set; }
        public bool IsDescSelected { get; set; }
        public string ApplicationName { get; set; }

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
        /// Gets or sets the current selected treeview Item.
        /// </summary>
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
                if(value==null)return;
                ParentofItem = CurrentItem.ParentTitle;
                ItemName = CurrentItem.ItemTitle;
                ItemId = CurrentItem.ItemId;
                OrderOfItem = Convert.ToString(CurrentItem.SortOrder);
                TypeId = CurrentItem.TypeId;
            }
        }

        /// <summary>
        /// Gets or sets the selected item from popup treeview.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the Languages
        /// </summary>
        private ObservableCollection<LanguageItem> _languages;
        public ObservableCollection<LanguageItem> Languages
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

        /// <summary>
        /// Gets or sets the types
        /// </summary>
        private WorkspaceItem[] _types;
        public WorkspaceItem[] Types
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
                if (ApplicationName != Constants.ViewNames.AddItem)
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
                if(_pageLoadCount==0)
                if (PropertiesCountBeforeModification < _workspaceItemProperties.ToList().Count)
                {
                    PropertiesCountBeforeModification = _workspaceItemProperties.ToList().Count;
                    _pageLoadCount++;
                }
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
                if (ApplicationName != Constants.ViewNames.AddItem)
                    RegisterProperty();
            }
        }

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

        /// <summary>
        /// Gets or sets the selected typeId
        /// </summary>
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
        public string OrderOfItem
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

        /// <summary>
        /// Gets or sets the selected image.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the Description Id
        /// </summary>
        private string _descriptionId;
        public string DescriptionId
        {
            get
            {
                return _descriptionId;
            }
            set
            {
                _descriptionId = value;
                //Agent.DeleteDescriptionAsync(value);  //need to change in service
            }
        }

        /// <summary>
        /// Gets or sets the Modify descriptions.
        /// </summary>
        //private WorkspaceItemDescription[] _modifyDescription;
        //public WorkspaceItemDescription[] ModifyDescription
        //{
        //    get
        //    {
        //        return _modifyDescription;
        //    }
        //    set
        //    {
        //        _modifyDescription = value;
        //        // Agent.RegisterModifyDescriptionAsync(ModifyDescription);  need to change in service 
        //    }
        //}

        /// <summary>
        /// Gets or sets the resultDescription -partial implementation
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
                Action<WorkspaceItemResult<WorkspaceItemDescription>> action = OnRegisterDescriptionCompleted;
                Agent.GetDescriptionsAsync(ItemId, action);
            }
        }


        /// <summary>
        /// Gets or sets the ItemId
        /// </summary>
        private string _itemId;
        public string ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;

                //if (value != null)
                //{
                //   var result = Agent.GetFullWorkspaceItem(value);
                //    ParentofItem = result.ParentTitle;
                //    //ParentofItem = "ParentTitle Test Value";
                //    ItemName = result.ItemTitle;
                //    OrderOfItem = Convert.ToString(result.SortOrder);
                //    TypeId = result.TypeId;
                //    Type = result.TypeTitle;
                //}
            }
        }

        /// <summary>
        /// Gets or sets the workspace Id
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets and Sets the Description data
        /// </summary>
        public IEnumerable<WorkspaceItemDescription> DescriptionListItem { get; set; }

        # endregion

        #region Protected Methods
        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            GetLanguagesAsync();
            Types = null;
            GetTypesAsync();
            EventBroker.LoadSearchFolder += EventBroker_LoadSearchFolder;
            BtnSearchFolderClick = new DelegateCommand(BtnSearchFolder);

        }
        #endregion

        #region Public Methods


        public void Reset()
        {
            //ParentofItem = string.Empty;
            //ItemName = string.Empty;
            ////Types = null; // No need to reset types
            //OrderOfItem = string.Empty;
            ParentofItem = string.Empty;
            ItemName = string.Empty;
            ItemImage = null;
            OrderOfItem = string.Empty;
            TypeId = string.Empty;
            Type = string.Empty;
            ItemId = ConvertItemHelper.CurrentItemId;
        }

        /// <summary>
        /// Handle IsEnable Property 
        /// </summary>
        /// <param name="processFrom"></param>
        public void HandleIsEnableProperty(string processFrom)
        {
            IsPropertySelected = IsDescSelected = IsDescGridEnable = IsPropertyGridEnable = IsOrderOfItemEnable = IsTypeEnable = IsImageEnable = IsNameEnable = IsBtnSearchEnable = IsParentItemEnable = false;
            ApplicationName = processFrom;
            switch (processFrom)
            {
                case Constants.ViewNames.ModifyDesc:
                    IsDescGridEnable = IsDescSelected = true;
                    break;
                case Constants.ViewNames.ModifyProperty:
                    IsPropertyGridEnable = IsPropertySelected = true;
                    break;
                case Constants.ViewNames.AddItem:
                    ParentofItem = ItemName;
                    IsPropertySelected = IsDescGridEnable = IsPropertyGridEnable = IsOrderOfItemEnable = IsTypeEnable = IsImageEnable = IsNameEnable = IsBtnSearchEnable = true;
                    break;
                case Constants.ViewNames.ModifyItem:
                    IsPropertySelected = IsDescGridEnable = IsPropertyGridEnable = true;
                    break;
            }
        }

        /// <summary>
        /// Calls the Asynchronous Method with callback to get Workspace Item
        /// </summary>
        public void GetLanguagesAsync()
        {
            Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetLanguagesCompleted;
            Agent.GetLanguagesAsync(action);
        }

        /// <summary>
        /// Call the Asynchronous method with callback to get the Description
        /// </summary>
        public void GetDescriptionAsync()
        {
            Action<WorkspaceItemResult<WorkspaceItemDescription>> action = OnGetDescriptionsCompleted;
            Agent.GetDescriptionsAsync(ItemId, action);
        }


        /// <summary>
        /// Asynchronous method with callback to call the types.
        /// </summary>
        public void GetTypesAsync()
        {
            //Partial completion need to call WCF Service
            //Action<WorkspaceItemResult<WorkspaceItem>> action = OnGetTypesCompleted;
            // Agent.GetTypesAsync(action);

            var info = new[]
                           {
                               new WorkspaceItem {TypeId = "BASE_TYPE_UI_TRV_FOLDER",ItemTitle = "BASE_TYPE_UI_TRV_FOLDER"},
                               new WorkspaceItem {TypeId = "BASE_TYPE_UI_TRV_NODE_TEXT",ItemTitle = "BASE_TYPE_UI_TRV_NODE_TEXT"},
                               new WorkspaceItem {TypeId = "BASE_TYPE_WPI_DESCRIPTION",ItemTitle= "BASE_TYPE_WPI_DESCRIPTION"}

                           };
            Types = info;
        }




        /// <summary>
        /// Occurs when click the save button
        /// </summary>
        public void RegisterWorkspaceItem()
        {
            if (string.IsNullOrEmpty(ParentofItem))
            {
                MessageBox.Show("Please select parent of item.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(ItemName))
            {
                MessageBox.Show("Item name should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(TypeId))
            {
                MessageBox.Show("Type should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(OrderOfItem))
            {
                MessageBox.Show("Order of the item should not be empty.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (IsNumeric(OrderOfItem))
            {
                MessageBox.Show("Order of the item should be numeric.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var info = new WorkspaceItem()
            {
                ParentId = SelectedItem.Id,
                ParentTitle=ParentofItem,
                TypeId = TypeId,
                ItemTitle = ItemName,
                ItemImage = ItemImage,
                SortOrder = Convert.ToInt32(OrderOfItem)
            };
            if (SavedItemDesc != null)
                info.Descriptions = ItemDescription(SavedItemDesc);

            if (SaveItemProperty != null)
                info.Properties = ItemProperty(SaveItemProperty);

            info.DateModified = DateTime.Now.Date;


            #region "need to check"

            //todo
            if(info.Properties.Length==0)
            {
                info.Properties=new WorkspaceItemProperty[1];
                info.Properties[0]=new WorkspaceItemProperty();
            }
            info.Properties[0].PropertyTypeId = SelectedItem.Properties.Length>0 ? SelectedItem.Properties[0].PropertyTypeId : "BASE_TYPE_UI_TRV_FOLDER";
            info.Properties[0].ItemId = Guid.NewGuid().ToString();
            

            if(info.Descriptions.Length==0)
            {
                info.Descriptions=new WorkspaceItemDescription[1];
                info.Descriptions[0]=new WorkspaceItemDescription();
            }
            info.Descriptions[0].ItemId = Guid.NewGuid().ToString();

            info.Id = Guid.NewGuid().ToString();
            info.ItemId = Guid.NewGuid().ToString();
            

            #endregion
            Agent.AddItemAsync(info);

            //Commanded once service method created then remove command(Don't Delete).
            //Agent.RegisterWorkspaceAsync(info);
            MessageBox.Show("WorkspaceItem Saved Successfully.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information);
            //EventBroker.RaiseLoadIsRefresh(new LoadDetailViewEventArgs() { IsRefresh = true });

            Reset();
        }

        /// <summary>
        /// Check the given input is numeric.
        /// </summary>
        /// <param name="strTextEntry">Textbox input</param>
        /// <returns>True or False</returns>
        public static bool IsNumeric(string strTextEntry)
        {
            var objNotWholePattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotWholePattern.IsMatch(strTextEntry);
        }
        #endregion

        # region Private Methods

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
        /// BitmapImage are converted into byte[] array. 
        /// </summary>
        /// <param name="imageIn">BitmapImage</param>
        /// <returns>byte[] image</returns>
        private static byte[] ImageToByteArray(BitmapImage imageIn)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new JpegBitmapEncoder();
                if (imageIn != null)
                {
                    encoder.Frames.Add(BitmapFrame.Create(imageIn));
                    encoder.Save(stream);
                }
                return stream.ToArray();
            }
        }
        /// <summary>
        /// Occurs when the register description completed.
        /// </summary>
        /// <param name="action">WorkspaceItemDescription</param>
        private void OnRegisterDescriptionCompleted(WorkspaceItemResult<WorkspaceItemDescription> action)
        {
            if (action.Result == null) return;
            ResultDescription = action.Result;
        }

        /// <summary>
        /// Assigns the workspace item to the WorkspaceItems property 
        /// </summary>
        /// <param name="action"></param>
        private void OnGetLanguagesCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            if (action.Items == null) return;
            var list = new ObservableCollection<WorkspaceItem>(action.Items);
            var item = new ObservableCollection<LanguageItem>();
            foreach (var row in list.Select(info => new LanguageItem
            {
                CultureId = info.ItemId,
                Title = info.ItemTitle
            }))
            {
                item.Add(row);
            }
            Languages = item;
        }

        /// <summary>
        /// Does the gettypes completed.
        /// </summary>
        /// <param name="action"></param>
        private void OnGetTypesCompleted(WorkspaceItemResult<WorkspaceItem> action)
        {
            Types = action.Items;
        }

        /// <summary>
        ///  Does the getdescription Completed.
        /// </summary>
        /// <param name="action"></param>
        private void OnGetDescriptionsCompleted(WorkspaceItemResult<WorkspaceItemDescription> action)
        {
            if (action.Descriptions == null) return;
            DescriptionListItem = action.Descriptions;
            EventBroker.RaiseLoadDescription(new LoadDescriptionEventArgs
            {
                DescriptionListItem = action.Descriptions,
                ItemId = ItemId
            });

            //Need to check--commented by kalai
            //EventBroker.RaiseSaveDescription(new LoadDescriptionEventArgs
            //{
            //    DescriptionListItem = action.Descriptions
            //});
        }

        /// <summary>
        /// Call when select the parent item from popuptreeview
        /// </summary>
        private void BtnSearchFolder()
        {
            EventBroker.RaiseSetPopUpFlag(new LoadWorkspaceItemEventArgs { PopUp = true });
            var pop = new PopUpTreeView();
            pop.ShowDialog();
            EventBroker.RaiseSetPopUpFlag(new LoadWorkspaceItemEventArgs { PopUp = false });
        }

        /// <summary>
        /// Occurs when the treeview item selected and click the ok button.
        /// </summary>
        /// <param name="sender">Popuptreeview</param>
        /// <param name="e">LoadWorkspaceItemEventArgs.SelectedItem</param>
        private void EventBroker_LoadSearchFolder(object sender, LoadWorkspaceItemEventArgs e)
        {
            SelectedItem = e.SelectedItem;
        }

        /// <summary>
        /// Save the newly added Property
        /// </summary>
        private void RegisterProperty()
        {
            foreach (var workspaceItemProperty in SaveItemProperty)
            {
                var info = workspaceItemProperty;
                info.ItemId = ItemId;
                info.PropertyTypeId = "BASE_TYPE_UI_TRV_FOLDER"; //todo
                Agent.RegisterPropertyAsync(info);
            }
        }

        /// <summary>
        /// Gets the properties (refreshed)
        /// </summary>
        /// <param name="obj"></param>
        void Agent_RegisterPropertyCompleted(WorkspaceItemResult<WorkspaceItemProperty> obj)
        {
            if (_pageLoadCount > 0)
            {
                MessageBox.Show("Properties Added Successfully.", Constants.ProjectTitle, MessageBoxButton.OK,
                                MessageBoxImage.Information); //todo
                _pageLoadCount = 0;
            }
        }



        /// <summary>
        /// Save the newly added description item.
        /// </summary>
        private void RegisterDescription()
        {
            foreach (var workspaceItemDescription in SavedItemDesc)
            {
                var info = workspaceItemDescription;
                info.ItemId = ItemId;
                Agent.RegisterDescriptionAsync(info);
            }
        }

        /// <summary>
        /// Gets the descriptions (refreshed)
        /// </summary>
        /// <param name="obj"></param>
        void Agent_RegisterDescriptionCompleted(WorkspaceItemResult<WorkspaceItemDescription> obj)
        {
            if (SavedItemDesc.Count() <= 0) return;
            MessageBox.Show("Item Description Added Successfully.", Constants.ProjectTitle, MessageBoxButton.OK, MessageBoxImage.Information); //todo
            _modifyDescription.Clear();
            // Reassign the description list Item(After saved)
            GetDescriptionAsync();
        }


        /// <summary>
        /// Convert the newly added ItemDescription collection into array 
        /// for registerworkspace.
        /// </summary>
        /// <param name="info">Collections of workspaceItemDescription</param>
        /// <returns>WorkspaceItemDescription[]</returns>
        private WorkspaceItemDescription[] ItemDescription(ObservableCollection<WorkspaceItemDescription> info)
        {
            var item = new WorkspaceItemDescription[info.Count];
            var index = 0;
            foreach (var desc in info)
            {
                item.SetValue(desc, index);
                index += 1;
            }
            return item;
        }

        /// <summary>
        /// Convert the newly added ItemProperty collection into array 
        /// for registerworkspace.
        /// </summary>
        /// <param name="info">Collections of WorkspaceItemproperty</param>
        /// <returns>WorkspaceItemProperty[]</returns>
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