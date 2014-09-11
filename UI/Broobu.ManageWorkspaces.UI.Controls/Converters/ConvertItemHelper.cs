using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ActiproSoftware.Windows;
using ActiproSoftware.Windows.Controls.Navigation;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls.Converters
{
    /// <summary>
    /// This class includes helper methods for working with the Breadcrumb ConvertItem event.
    /// </summary>
    public static class ConvertItemHelper
    {

        #region Field Members

        private static List<object> _lastTrail = new List<object>();
        private static List<object> _comboTrail;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Treeviewitem
        /// </summary>
        public static TreeViewItem Treeviewitem { get; set; }

        /// <summary>
        /// Gets and Sets the ListItem
        /// </summary>
        public static IEnumerable<WorkspaceItem> ListItem { get; set; }

        /// <summary>
        /// Gets and Sets the TreeViewItemPath
        /// </summary>
        public static string TreeViewItemPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets the currently selected item's ItemId
        /// </summary>
        public static string CurrentItemId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and Sets the Listitem
        /// </summary>
        public static List<WorkspaceItem> ChildItem { get; set; }

        public static DeferrableObservableCollection<object> SelectedItems
        {
            get;
            set;
        }
        public static string ItemTitle
        {
            get;
            set;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Reports an error to the user.
        /// </summary>
        /// <param name="text">The text.</param>
        private static void ReportError(string text)
        {
            MessageBox.Show(text, "Breadcrumb Sample", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the path for the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>string</returns>
        public static string GetPath(object item)
        {
            if (item is BreadCrumbViewModel)
            {
                return Constants.Root;
            }
            var driveData = item as WorkspaceItem;
            if (null != driveData)
            {
                return driveData.ItemTitle;
            }
            var directoryData = item as WorkspaceItem[];
            if (null != directoryData)
                return directoryData[0].ItemTitle;

            return string.Empty;
        }

        /// <summary>
        /// Gets the trail for the specified item.
        /// </summary>
        /// <param name="rootItem">The root item.</param>
        /// <param name="item">The item.</param>
        /// <returns>IList</returns>
        public static IList GetTrail(object rootItem, object item)
        {
            string path = GetPath(item);
            return GetTrail(rootItem, path, item);
        }


        /// <summary>
        /// Gets the trail for the specified path.
        /// </summary>
        /// <param name="rootItem">The root item.</param>
        /// <param name="path">The path.</param>
        /// <param name="lastitem">The lastitem</param>
        /// <returns>IList</returns>
        public static IList GetTrail(object rootItem, string path, object lastitem)
        {
            // Make sure the specified path is valid
            if (string.IsNullOrEmpty(path))
                return null;
            string root = string.Empty;
            TreeViewItem parentItem;
            new TreeViewItem();
            TreeViewItem parentItem2;
            new TreeViewItem();
            new WorkspaceItem();
            var lastItemroot = lastitem as WorkspaceItem;
            var treeviewitemlist = new List<TreeViewItem>();
            var item = rootItem as BreadCrumbViewModel;
            var blnitem = true;
            var trail = new List<object> { item };
            _comboTrail = new List<object>();
            if (item != null)
            {
                if (Treeviewitem != null)
                {
                    if (Treeviewitem.Header != null)
                    {
                        if (lastItemroot != Treeviewitem.Header as WorkspaceItem)
                        {
                            #region "lastItemroot"

                            if (lastItemroot != null)
                            {
                                if (_lastTrail.Count > 1)
                                {
                                    foreach (var trailitem in _lastTrail)
                                    {
                                        if (blnitem)
                                        {
                                            if (trailitem == lastItemroot)
                                                blnitem = false;
                                            _comboTrail.Add(trailitem);
                                        }
                                    }
                                    if (blnitem)
                                    {
                                        if (lastItemroot.ParentId != ((WorkspaceItem)_lastTrail[1]).ParentId)
                                        {
                                            if (((WorkspaceItem)_lastTrail[_lastTrail.Count - 1]).Id != lastItemroot.Id)
                                            {
                                                if (((WorkspaceItem)_lastTrail[_lastTrail.Count - 1]).Id ==
                                                    ((WorkspaceItem)lastItemroot).ParentId)
                                                {
                                                    _lastTrail.Add(lastItemroot);
                                                    if (ListItem != null)
                                                        ((WorkspaceItem)_lastTrail[_lastTrail.Count - 1]).Children =
                                                            ListItem.ToArray();
                                                }
                                            }

                                        }
                                        else
                                        {
                                            //  _lastTrail = new List<object> { item, lastItemroot }; // Need to check
                                            _lastTrail.Add(lastItemroot);
                                        }
                                        trail = _lastTrail;
                                        LoadTreeViewPath(_lastTrail); //need to check
                                    }
                                    else
                                    {
                                        trail = _comboTrail;
                                        LoadTreeViewPath(_comboTrail);
                                    }

                                }
                                else
                                {
                                    _lastTrail = new List<object> { item, lastItemroot };
                                }
                                LoadTreeViewPath(_lastTrail);

                            }

                            #endregion
                        }
                        else
                        {
                            #region "ParentItem"

                            string header = string.Empty;
                            parentItem2 = Treeviewitem;
                            while (header != Constants.Root)
                            {

                                parentItem = ItemsControl.ItemsControlFromItemContainer(Treeviewitem) as TreeViewItem;
                                if (parentItem != null)
                                {
                                    header = ((WorkspaceItem)parentItem.Header).Id;
                                    if (((WorkspaceItem)parentItem.Header).Id != Constants.Root)
                                    {
                                        Treeviewitem = parentItem;
                                        treeviewitemlist.Add(parentItem);
                                    }
                                    else
                                    {
                                        TreeViewItemPath = header;
                                    }
                                }
                                else
                                {
                                    root = header = Constants.Root;
                                }
                            }

                            for (int i = treeviewitemlist.Count - 1; i >= 0; i--)
                            {
                                TreeViewItemPath = string.Format("{0} / {1}", TreeViewItemPath,
                                                                 ((WorkspaceItem)treeviewitemlist[i].Header).ItemTitle);
                                trail.Add(treeviewitemlist[i].Header as WorkspaceItem);
                            }
                            if (root == string.Empty)
                            {
                                trail.Add(parentItem2.Header as WorkspaceItem);
                                TreeViewItemPath = string.Format("{0} / {1}", TreeViewItemPath,
                                                                 ((WorkspaceItem)parentItem2.Header).ItemTitle);
                            }
                            _lastTrail = trail;

                            #endregion
                        }
                    }
                }
                else
                {
                    _lastTrail = trail;
                    if (SelectedItems != null)
                    {
                        TreeViewItemPath = null;
                        foreach (var listViewItem in SelectedItems)
                        {
                            if (listViewItem is BreadCrumbViewModel)
                            {
                                TreeViewItemPath = ItemTitle;
                            }
                            else
                            {
                                string itemTitle = ((WorkspaceItem)(listViewItem)).ItemTitle;
                                TreeViewItemPath = string.Format("{0} / {1}", TreeViewItemPath, itemTitle);
                                trail.Add(listViewItem);
                            }
                        }
                    }

                }
                return trail;
            }

            return null;
        }

        /// <summary>
        /// Handles the ConvertItem event of a Breadcrumb control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="BreadcrumbConvertItemEventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        public static void HandleConvertItem(object sender, BreadcrumbConvertItemEventArgs e)
        {
            if (BreadcrumbConvertItemTargetType.Path == e.TargetType)
            {
                // Convert either the item or the trail to a path
                object item = e.Item;
                if (null == item && null != e.Trail && 0 != e.Trail.Count)
                    item = e.Trail[e.Trail.Count - 1];

                //  e.Path = GetPath(item);
                //if (TreeViewItemPath == null)
                //  TreeViewItemPath = "Root";
                e.Path = TreeViewItemPath ?? GetPath(item);
            }
            else if (BreadcrumbConvertItemTargetType.Trail == e.TargetType)
            {
                IList trail = null;
                if (null != e.Path)
                    trail = GetTrail(e.RootItem, e.Path);
                else if (null != e.Item)
                    trail = GetTrail(e.RootItem, e.Item);

                if (null == trail)
                {
                    ReportError("The specified path could not be found.");
                    return;
                }
                e.Trail = null;
                e.Trail = trail;

            }
            else
            {
                ReportError("Unsupported Breadcrumb target type.");
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trail"></param>
        private static void LoadTreeViewPath(List<object> trail)
        {
            foreach (var o in trail)
            {
                if (o is BreadCrumbViewModel)
                {
                    TreeViewItemPath = ItemTitle;
                }
                else
                {
                    string itemTitle = ((WorkspaceItem)o).ItemTitle;
                    TreeViewItemPath = string.Format("{0} / {1}", TreeViewItemPath, itemTitle);
                    //    trail.Add(o);
                }
            }
        }
        #endregion
    }
}
