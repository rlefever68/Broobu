using System.Collections.Generic;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    internal class WindowManager
    {
        #region "Members/Fields"

        private static AddItemViewModel _addItemViewModel;
        private static WorkspaceSearchResultViewModel _searchResultViewModel;

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Show "Add Item" Screen
        /// </summary>
        /// <param name="descriptionListItem"></param>
        /// <param name="workspaceItemProperties"></param>
        /// <param name="currentItem"></param>
        /// <param name="processFrom"></param>
        public static void ShowAddItemScreen(IEnumerable<WorkspaceItemDescription> descriptionListItem, IEnumerable<WorkspaceItemProperty> workspaceItemProperties,WorkspaceItem currentItem, string processFrom)
        {
            AddItemViewModel addItemVm = GetAddItemViewModel();
            switch (processFrom)
            {
                case Constants.ViewNames.ModifyDesc:
                    addItemVm.Reset();
                    addItemVm.DescriptionListItem = descriptionListItem;
                    addItemVm.CurrentItem = currentItem;
                    break;
                case Constants.ViewNames.ModifyProperty:
                    addItemVm.Reset();
                    addItemVm.WorkspaceItemProperties = workspaceItemProperties;
                    addItemVm.CurrentItem = currentItem;
                    break;
                case Constants.ViewNames.ModifyItem:
                    addItemVm.Reset();
                    addItemVm.DescriptionListItem = descriptionListItem;
                    addItemVm.WorkspaceItemProperties = workspaceItemProperties;
                    addItemVm.CurrentItem = currentItem;
                    break;
                case Constants.ViewNames.AddItem:
                    addItemVm.Reset();
                    break;
            }

         
            addItemVm.HandleIsEnableProperty(processFrom);
            var addItem = new AddItem();
            addItem.Initialize(addItemVm);
            addItem.ShowDialog();
        }

        /// <summary>
        /// Show "PopUpListView" screen 
        /// </summary>
        /// <param name="items"></param>
        public static void ShowSearchResultScreen(WorkspaceItem[] items)
        {
            var searchVm = GetWorkspaceSearchControlViewModel();
            searchVm.ListItem = items;
            var window = new WorkspaceSearchResultView();
            window.Initialize(searchVm);
            window.ShowDialog();
        }

        #endregion

        #region "Private Methods"

        /// <summary>
        /// Gets the Workspacepopup Listviewmodel
        /// </summary>
        /// <returns></returns>
        private static WorkspaceSearchResultViewModel GetWorkspaceSearchControlViewModel()
        {
            if (_searchResultViewModel == null)
                _searchResultViewModel = new WorkspaceSearchResultViewModel();
            return _searchResultViewModel;
        }

        /// <summary>
        /// Gets the AddItemViewModel
        /// </summary>
        /// <returns></returns>
        private static AddItemViewModel GetAddItemViewModel()
        {
            if(_addItemViewModel==null)
            _addItemViewModel=new AddItemViewModel();
            return _addItemViewModel;
        }

        #endregion

    }
}
