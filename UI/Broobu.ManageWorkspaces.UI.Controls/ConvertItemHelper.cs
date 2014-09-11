using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ActiproSoftware.Windows.Controls.Navigation;
using Pms.WorkspaceBrowser.Contract.Domain;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    /// <summary>
    /// This class includes helper methods for working with the Breadcrumb ConvertItem event.
    /// </summary>
    public static class ConvertItemHelper
    {
       
        #region Field Members
        private static BreadCrumbViewModel[] _breadCrumbViewModelitem;
        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the TreeviewItem
        /// </summary>
        private static TreeViewItem _treeviewitem;
        public static TreeViewItem Treeviewitem
        {
            get { return _treeviewitem; }
            set
            {
                _treeviewitem = value;

            }
        }

        /// <summary>
        /// Gets and Sets the BreadCrumbViewModel
        /// </summary>
        /// <param name="viewModels"></param>
        public static void GetBreadCrumbViewModel(BreadCrumbViewModel[] viewModels)
        {
            _breadCrumbViewModelitem = viewModels;
        }

        /// <summary>
        /// Gets and Sets ListItem Data
        /// </summary>
        private static IEnumerable<WorkspaceItem> _listItem;
        public static IEnumerable<WorkspaceItem> ListItem
        {
            get
            {
                return _listItem;
            }
            set
            {
                _listItem = value;

            }
        }

        /// <summary>
        /// Gets and Sets the TreeViewItemPath
        /// </summary>
        public static string TreeViewItemPath
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
        /// <returns></returns>
        public static string GetPath(object item)
        {
            if (item is BreadCrumbViewModel)
            {
                return "ROOT";
            }
            else
            {
                var driveData = item as WorkspaceItem;
                if (null != driveData)
                {
                    return driveData.ItemTitle;
                }
                else
                {
                    var directoryData = item as WorkspaceItem[];
                    if (null != directoryData)
                        return directoryData[0].ItemTitle;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the trail for the specified item.
        /// </summary>
        /// <param name="rootItem">The root item.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static IList GetTrail(object rootItem, object item)
        {
            string path = GetPath(item);
            return GetTrail(rootItem, path);
        }

        /// <summary>
        /// Gets the trail for the specified path.
        /// </summary>
        /// <param name="rootItem">The root item.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static IList GetTrail(object rootItem, string path)
        {
            // Make sure the specified path is valid
            if (string.IsNullOrEmpty(path))
                return null;
            
            var parentItem = new TreeViewItem();
            var parentItem2 = new TreeViewItem();
            var treeviewitemlist = new List<TreeViewItem>();
            var trail = new List<object> {_breadCrumbViewModelitem};
            if (_breadCrumbViewModelitem != null)
            {
                if (Treeviewitem != null)
                    if (Treeviewitem.Header != null)
                    {
                       
                        string header = string.Empty;
                        parentItem2 = Treeviewitem;
                        while (header != "ROOT")
                        {

                            parentItem = ItemsControl.ItemsControlFromItemContainer(Treeviewitem) as TreeViewItem;
                            if (parentItem != null)
                            {
                                header = ((WorkspaceItem) parentItem.Header).Id;
                                if (((WorkspaceItem)parentItem.Header).Id != "ROOT")
                                {
                                    Treeviewitem = parentItem;
                                    treeviewitemlist.Add(parentItem);
                                }
                                else
                                {
                                    TreeViewItemPath = header;
                                }
                            }
                        }
                      
                        for (int i = treeviewitemlist.Count - 1; i >= 0; i--)
                        {
                            TreeViewItemPath = TreeViewItemPath + " / " + ((WorkspaceItem)treeviewitemlist[i].Header).ItemTitle;
                            trail.Add(treeviewitemlist[i].Header as WorkspaceItem);
                        }
                        trail.Add(parentItem2.Header as WorkspaceItem);
                        TreeViewItemPath = TreeViewItemPath + " / " + ((WorkspaceItem)parentItem2.Header).ItemTitle;
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
                e.Path = TreeViewItemPath;
               
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

                e.Trail = trail;
            }
            else
            {
                throw new NotImplementedException("Unsupported Breadcrumb target type");
            }
        }

        #endregion
    }
}
