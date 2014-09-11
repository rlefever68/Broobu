using System;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;

namespace Pms.ManageWorkspaces.UI.Controls
{
    public class ApplicationEvents
    {
        #region Fields/Members
        /// <summary>
        /// Declare the class objects
        /// </summary>
        private static readonly ApplicationEvents _instance = new ApplicationEvents();

        #endregion

        #region Events

        /// <summary>
        /// Occurs when raise the RaiseLoadDescription
        /// </summary>
        public event EventHandler<LoadDescriptionEventArgs> LoadDescription;

        /// <summary>
        /// Occurs when raise the RaiseLoadDetailView
        /// </summary>
        public event EventHandler<LoadDetailViewEventArgs> LoadDetailView;

        /// <summary>
        /// Occurs when raise the RaiseLoadWorkspaceItem
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> LoadWorkspaceItem;

        /// <summary>
        /// Occurs when raise the RaiseLoadProperties
        /// </summary>
        public event EventHandler<LoadPropertiesEventArgs> LoadProperties;

        /// <summary>
        /// Occurs when raise the RaiseGetId
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> GetId;

        /// <summary>
        /// Occurs when raise the RaiseGetWorkspaceId
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> GetWorkspaceId;

        /// <summary>
        /// Occurs when raise the RaiseVisibleListOrDetails
        /// </summary>
        public event EventHandler<LoadDetailViewEventArgs> VisibleListOrDetails;

        /// <summary>
        /// Occurs when raise the RaiseSetWorkspaceChildItem
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> SetWorkspaceChildItem;

        /// <summary>
        /// Occurs when raise the RaiseDoubleClickListView
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> DoubleClickListView;

        /// <summary>
        /// Occurs when raise the RaiseGetFolderString
        /// </summary>
        public event EventHandler<LoadDetailViewEventArgs> GetFolderString;

        /// <summary>
        /// Occurs when raise the RaiseGetBlnFolderString
        /// </summary>
        public event EventHandler<LoadDetailViewEventArgs> GetBlnFolderString;

        /// <summary>
        /// Occurs when raise the RaiseGetListItem
        /// </summary>
        public event EventHandler<LoadDetailViewEventArgs> GetListItem;

        /// <summary>
        /// Occurs when raise the RaiseGetSearchString
        /// </summary>
        //   public event EventHandler<LoadWorkspaceItemEventArgs> GetSearchString;

        /// <summary>
        /// Occurs when raise the RaiseGetPreviousListItem
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> GetPreviousListItem;

        /// <summary>
        /// Occurs when raise the RaiseSaveDescription
        /// </summary>
        public event EventHandler<LoadDescriptionEventArgs> SaveDescription;

        /// <summary>
        /// Occurs when raise the RaiseSetPopUpFlag
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> SetPopUpFlag;

        /// <summary>
        /// Occurs when raise the RaiseLoadText
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> LoadText;

        /// <summary>
        /// Occurs when raise the RaiseLoadSearchFolder
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> LoadSearchFolder;

        /// <summary>
        /// Occurs when raise the RaiseLoadBreadCrumb
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> LoadBreadCrumb;

        /// <summary>
        /// Occurs when raise the RaiseSelectedItemChange
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> SelectedItemChange;

        /// <summary>
        /// Occurs when raise the RaiseBreabCrumbTreeViewItem
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> BreabCrumbTreeViewItem;

        /// <summary>
        /// Occurs when raise the RaiseGetTreeView
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> GetTreeView;

        /// <summary>
        /// Occurs when raise the RaiseGetChild
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> GetChild;

        /// <summary>
        /// Occurs when raise the RaiseLoadDetailView
        /// </summary>
        public event EventHandler<LoadDetailViewEventArgs> LoadChild;

        /// <summary>
        /// Occurs when raise the RaiseGetModifyItem
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> GetModifyItem;

        /// <summary>
        ///  Occurs when raise the RaiseSaveGrdOverview
        /// </summary>
        public event EventHandler SaveGrdOverview;

        /// <summary>
        /// Occurs when raise the RaiseGetSearchItem
        // </summary>
        //public event EventHandler<LoadDetailViewEventArgs> GetSearchItem;

        /// <summary>
        /// Occurs when raise the RaiseWorkspaceItemCount
        /// </summary>
        //public event EventHandler<LoadDetailViewEventArgs> WorkspaceItemCount;

        /// <summary>
        /// Occurs when raise the RaiseIsrefresh
        /// </summary>
        //public event EventHandler<LoadDetailViewEventArgs> IsRefresh;

        /// <summary>
        /// Occurs when raise the RaiseTeeviewdropEnable
        /// </summary>
        public event EventHandler<LoadWorkspaceItemEventArgs> TreeViewDropEnable;



        public event EventHandler<LoadWorkspaceItemEventArgs> ApplicationName;
        public event Action StartRefresh;
        public event Action Refreshed;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the all method from applicationevents class
        /// </summary>
        public static ApplicationEvents Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Occurs when the Asyn method invoked
        /// </summary>
        public void RaiseStartRefresh()
        {
            Action handler = StartRefresh;
            if (handler != null) handler();
        }
        /// <summary>
        /// Occurs when the Asyn EventsCompleted
        /// </summary>
        public void RaiseRefreshed()
        {
            Action handler = Refreshed;
            if (handler != null) handler();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void RaiseApplicationName(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = ApplicationName;
            if (handler != null) handler(this, e);
        }


        /// <summary>
        /// Occurs when the TreeviewDrop Enabled
        /// </summary>
        /// <param name="e"></param>
        public void RaiseLoadTreeViewDropEnable(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = TreeViewDropEnable;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when the load IsRefresh
        /// </summary>
        /// <param name="e"></param>
        ////public void RaiseLoadIsRefresh(LoadDetailViewEventArgs e)
        ////{
        ////    EventHandler<LoadDetailViewEventArgs> handler = IsRefresh;
        ////    if (handler != null) handler(this, e);
        ////}
        /// <summary>
        /// Occurs when the Load the WorkspaceItemcount 
        /// </summary>
        /// <param name="e"></param>
        //public void RaiseLoadWorkspaceItemCount(LoadDetailViewEventArgs e)
        //{
        //    EventHandler<LoadDetailViewEventArgs> handler = WorkspaceItemCount;
        //    if (handler != null) handler(this, e);
        //}

        /// <summary>
        /// Occurs when the Load the Description Grid
        /// </summary>
        /// <param name="e">Description Information</param>
        public void RaiseLoadDescription(LoadDescriptionEventArgs e)
        {
            EventHandler<LoadDescriptionEventArgs> handler = LoadDescription;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when click the DetailView button
        /// </summary>
        /// <param name="e">Description Information</param>
        public void RaiseLoadDetailView(LoadDetailViewEventArgs e)
        {
            EventHandler<LoadDetailViewEventArgs> handler = LoadDetailView;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when Load the workspace Items
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseLoadWorkspaceItem(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = LoadWorkspaceItem;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when open the Popup additem window
        /// </summary>
        /// <param name="e">LoadDetailViewEventArgs</param>
        public void RaiseVisibleList(LoadDetailViewEventArgs e)
        {
            EventHandler<LoadDetailViewEventArgs> handler = VisibleListOrDetails;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when Load the Properties Items
        /// </summary>
        /// <param name="e">LoadPropertiesEventArgs</param>
        public void RaiseLoadProperties(LoadPropertiesEventArgs e)
        {
            EventHandler<LoadPropertiesEventArgs> handler = LoadProperties;
            if (handler != null) handler(this, e);
        }
        /// <summary>
        /// Occurs when Load the ID 
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseGetId(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = GetId;
            if (handler != null) handler(this, e);
        }
        /// <summary>
        /// Occurs when Load the workspaceID 
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseGetWorkspaceId(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = GetWorkspaceId;
            if (handler != null) handler(this, e);
        }
        /// <summary>
        /// Occurs when assign the child items 
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseSetWorkspaceChildItem(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = SetWorkspaceChildItem;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when assign the ListviewItems
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseDoubleClickListView(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = DoubleClickListView;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Call getfolderstring from wcf service
        /// </summary>
        /// <param name="e">LoadDetailViewEventArgs</param>
        public void RaiseGetFolderString(LoadDetailViewEventArgs e)
        {
            EventHandler<LoadDetailViewEventArgs> handler = GetFolderString;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Called for sets the boolean flag when get folderstring
        /// </summary>
        /// <param name="e">LoadDetailViewEventArgs</param>
        public void RaiseGetBlnFolderString(LoadDetailViewEventArgs e)
        {
            EventHandler<LoadDetailViewEventArgs> handler = GetBlnFolderString;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Call when get the new listitem for binding in listview
        /// </summary>
        /// <param name="e">LoadDetailViewEventArgs</param>
        public void RaiseGetListItem(LoadDetailViewEventArgs e)
        {
            EventHandler<LoadDetailViewEventArgs> handler = GetListItem;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when assign the child items 
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        //public void RaiseGetSearchString(LoadWorkspaceItemEventArgs e)
        //{
        //    EventHandler<LoadWorkspaceItemEventArgs> handler = GetSearchString;
        //    if (handler != null) handler(this, e);
        //}

        /// <summary>
        /// Occurs when assign the previous items 
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseGetPreviousListItem(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = GetPreviousListItem;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs once the save completed then to get the new description 
        /// and properties for binding.
        /// </summary>
        /// <param name="e">LoadDescriptionEventArgs</param>
        public void RaiseSaveDescription(LoadDescriptionEventArgs e)
        {
            EventHandler<LoadDescriptionEventArgs> handler = SaveDescription;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when the popuptreeview window open to set the popupflag true.
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseSetPopUpFlag(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = SetPopUpFlag;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Call to load the fields in add item
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseLoadText(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = LoadText;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when enter the search control
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseLoadSearchFolder(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = LoadSearchFolder;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Call to load the breadcrumb control
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseLoadBreadCrumb(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = LoadBreadCrumb;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when select the treeviewitem change to get the current item
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseSelectedItemChange(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = SelectedItemChange;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Call to pass the current treeview items
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseBreabCrumbTreeViewItem(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = BreabCrumbTreeViewItem;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Call to pass the current treeview items
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseGetTreeView(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = GetTreeView;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when Load the workspaceID 
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseGetChild(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = GetChild;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when click the DetailView button
        /// </summary>
        /// <param name="e">Description Information</param>
        public void RaiseLoadChild(LoadDetailViewEventArgs e)
        {
            EventHandler<LoadDetailViewEventArgs> handler = LoadChild;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Occurs when Treeviewitem is assigned
        /// </summary>
        /// <param name="e">LoadWorkspaceItemEventArgs</param>
        public void RaiseGetModifyItem(LoadWorkspaceItemEventArgs e)
        {
            EventHandler<LoadWorkspaceItemEventArgs> handler = GetModifyItem;
            if (handler != null) handler(this, e);
        }


        /// <summary>
        /// Occurs when the application close 
        /// </summary>
        public void RaiseSaveGrdOverView()
        {
            EventHandler eventHandler = SaveGrdOverview;
            if (eventHandler != null) eventHandler(this, null);
        }

        /// <summary>
        /// Ocurrs when the SearchResult obtained
        /// </summary>
        /// <param name="e"></param>
        //public void RaiseGetSearchItem(LoadDetailViewEventArgs e)
        //{
        //    EventHandler<LoadDetailViewEventArgs> handler = GetSearchItem;
        //    if (handler != null) handler(this, e);
        //}



        #endregion
    }
}
