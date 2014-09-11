using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ActiproSoftware.Windows;
using ActiproSoftware.Windows.Controls.Navigation;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.Converters;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for BreadcrumbControl.xaml
    /// </summary>
    public partial class BreadcrumbControl
    {
        #region Field Members
        bool _flag = true;
        public bool Child = true;
        public int Count;
        private bool _isloaded;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public BreadcrumbControl()
        {
            Count = 0;
            _isloaded = true;
            _comboBoxItems = new DeferrableObservableCollection<object>();
            
            SelectedItems = new DeferrableObservableCollection<object>();

            InitializeComponent();

            Vm.EventBroker.GetTreeView += (snd, e) => Treeview = e.Treeview;

            Vm.EventBroker.SetWorkspaceChildItem += (snd, e) =>
            {
                if (_flag)
                    Workspaceitems = e.WorkspaceItems;
                _flag = false;
            };
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets and Sets Vm
        /// </summary>
        public BreadCrumbViewModel Vm
        {
            get { return (BreadCrumbViewModel)FindResource("Vm"); }
        }

        /// <summary>
        /// Gets and Sets ListItem Data
        /// </summary>
        //private static IEnumerable<WorkspaceItem> _listItem;

        /// <summary>
        /// Gets and Sets TreeView Control
        /// </summary>
        public static TreeView Treeview { get; set; }

        public DeferrableObservableCollection<object> SelectedItems { get; set; }

        /// <summary>
        /// Gets or sets the workspace items.
        /// </summary>
        /// <value>The workspace items.</value>
        public ObservableCollection<WorkspaceItem> Workspaceitems
        {
            get
            {
                return Vm.Workspaceitems;

            }
            set
            {
                Vm.Workspaceitems = value;
                #region "Unused Code need to check"



                //Loads the children for the selected breadcrumb menuitem
                //foreach (var item in Workspaceitems)
                //{
                //    if (item.Children != null)
                //        foreach (var childitem in item.Children)
                //        {
                //            if (childitem.Children == null) //|| childitem.Children[0].Id == null - need to check
                //            {
                //                ChildItem.Add(childitem);

                //                //Vm.EventBroker.RaiseGetChild(new LoadWorkspaceItemEventArgs
                //                //{
                //                //    WorkspaceId = childitem.Id,
                //                //    ItemId = childitem.ItemId
                //                //});
                //            }
                //        }
                //}
                //ConvertItemHelper.ChildItem = ChildItem;

                #endregion
            }
        }



        /// <summary>
        /// Gets and Sets BreadCrumbViewModel
        /// </summary>
        public BreadCrumbViewModel[] BreadCrumbViewModel
        {
            get
            {
                return new[] { Vm };
            }
        }

        /// <summary>
        /// Holds the items shown in the ComboBox in the Breadcrumb.
        /// </summary>
        private readonly DeferrableObservableCollection<object> _comboBoxItems;

        /// <summary>
        /// Gets the combo box items.
        /// </summary>
        /// <value>The combo box items.</value>
        public DeferrableObservableCollection<object> ComboBoxItems
        {
            get
            {
                return _comboBoxItems;
            }
        }


        #endregion

        #region Event Handlers
        /// <summary>
        /// Converts the BreadCrumbItems
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnBreadcrumbConvertItem(object sender, BreadcrumbConvertItemEventArgs e)
        {
            if (_isloaded)
            {
                if (breadcrumb.SelectedItem is BreadCrumbViewModel)
                {
                    SelectedItems.Insert(0, breadcrumb.SelectedItem);
                    return;
                }
                ConvertItemHelper.ItemTitle = ((WorkspaceItem)(breadcrumb.SelectedItem)).ItemTitle;
                e.Path = ConvertItemHelper.ItemTitle;
                return;
            }

            if (Vm.Treeviewitem != null)
            {
                if ((Vm.Treeviewitem.Header is WorkspaceItem) &&
                    (Vm.Treeviewitem.Header as WorkspaceItem).ItemImage.Length == 0)
                    (Vm.Treeviewitem.Header as WorkspaceItem).ItemImage = GetLocalItemImageForBreadCrumb();
                ConvertItemHelper.Treeviewitem = Vm.Treeviewitem;
                // ConvertItemHelper.HandleConvertItem(sender, e);
            }

            UpdateSelectedItems();
            ConvertItemHelper.GetTrail(breadcrumb.RootItem, breadcrumb.SelectedItem); 
            ConvertItemHelper.HandleConvertItem(sender, e);

            #region "need to check"

            //Loads dynamically the child item for the selected breadcrumb menu item
            //if (e.Item.GetType().Name == Constants.WorkspaceItem)
            //{
            //    if (((WorkspaceItem)e.Item).Children != null)
            //    {
            //        foreach (var item in ((WorkspaceItem)e.Item).Children)
            //        {
            //            if (item.Children != null)
            //                foreach (var childitem in item.Children)
            //                {
            //                    if (childitem.Children == null || childitem.Children.Length == 0)
            //                    {
            //                        ChildItem.Add(childitem);

            //                        //Vm.EventBroker.RaiseGetChild(new LoadWorkspaceItemEventArgs
            //                        //{
            //                        //    WorkspaceId = childitem.Id,
            //                        //    ItemId = childitem.ItemId
            //                        //});

            //                    }
            //                }
            //        }
            //        ConvertItemHelper.ChildItem = ChildItem;
            //    }
            //  }
            #endregion
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Sets the workspacechilditem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Vm.EventBroker.RaiseSetWorkspaceChildItem(new LoadWorkspaceItemEventArgs());
        }

        /// <summary>
        /// A Method that will be called when no item image is found
        /// </summary>
        /// <returns>A Byte array that contains Image data</returns>
        private static byte[] GetLocalItemImageForBreadCrumb()
        {
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource =
                new Uri(
                    "pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/OpenFolder.png",
                    UriKind.RelativeOrAbsolute);
            bmp.EndInit();
            MemoryStream memStream = null;
            try
            {
                memStream = new MemoryStream();
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(memStream);
                return memStream.GetBuffer();
            }
            finally
            {
                if (memStream != null) memStream.Close();
            }
        }

        /// <summary>
        /// Gets the BreadCrumb selected item
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void BreadcrumbSelectedItemChanged(object sender, ObjectPropertyChangedRoutedEventArgs e)
        {

            if (e.NewValue.GetType().Name == Constants.WorkspaceItem)
            {
                if (!_isloaded)
                {
                    Vm.EventBroker.RaiseGetChild(new LoadWorkspaceItemEventArgs
                    {
                        WorkspaceId = ((WorkspaceItem)e.NewValue).Id,
                        ItemId = ((WorkspaceItem)e.NewValue).ItemId
                    });

                }
                _isloaded = false;

                if (((WorkspaceItem)e.NewValue).Children != null)

                    if (((WorkspaceItem)e.NewValue).Children.Length != 0)
                    {
                        UpdateComboBoxItems();
                        //  UpdateSelectedItems();
                        #region "Unused code"

                        //Raise this event to set the listem to the workspace browser based on selected menu item
                        //Vm.EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs
                        //{
                        //    ListItem =
                        //        Vm.LoadListItem(((WorkspaceItem)e.NewValue).Children)
                        //});
                        //Raise this event to get the listitem
                        // Vm.EventBroker.RaiseGetWorkspaceId(new LoadWorkspaceItemEventArgs { WorkspaceId = ((WorkspaceItem)e.NewValue).Id, ItemId = ((WorkspaceItem)e.NewValue).ItemId });


                        // We will get the trail to the item selected in the Breadcrumb and use that to select the item in the TreeView
                        //IList trail = ConvertItemHelper.GetTrail(breadcrumb.RootItem, breadcrumb.SelectedItem);
                        //if (null != trail && 0 != trail.Count)
                        //    SelectItem(Treeview, trail, 0);
                        #endregion

                    }
            }
        }


        /// <summary>
        /// Updates the <see cref="ComboBoxItems"/>.
        /// </summary>
        private void UpdateComboBoxItems()
        {
            if (null != breadcrumb.SelectedItem)
            {
                ComboBoxItems.BeginUpdate();
                try
                {
                    // Insert it at the beginning
                    ComboBoxItems.Insert(0, breadcrumb.SelectedItem);

                    // Cap the size of the list
                    while (ComboBoxItems.Count > 15)
                        ComboBoxItems.RemoveAt(15);
                }
                finally
                {
                    ComboBoxItems.EndUpdate();
                }

            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Attempts to select a specific node in a TreeView, by recursively drilling down to the item indicated by the specified
        /// trail.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="trail">The trail.</param>
        /// <param name="index">The index.</param>
        public static void SelectItem(ItemsControl control, IList trail, int index)
        {
            // object currentItem = Vm.Workspaceitems[index];

            // If the control has not generated it's containers, then we need to delay our call until it does.
            if (control.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                // Find the current item in the control's Items
                foreach (object item in control.Items)
                {
                    //currentItem
                    if (item == control.Items.CurrentItem)
                    {
                        var container = (TreeViewItem)control.ItemContainerGenerator.ContainerFromItem(item);
                        ConvertItemHelper.Treeviewitem = container;
                        if (++index < trail.Count)
                        {
                            // We have more items to drill down into, so use a recursive call with a new control and index
                            container.IsExpanded = true;
                            SelectItem(container, trail, index);
                        }
                        else
                        {
                            // We found the item, so select it and bring it into view
                            container.IsSelected = true;
                            container.BringIntoView();
                        }
                        break;
                    }
                }
            }
            else
            {
                control.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (DispatcherOperationCallback)delegate
                {
                    SelectItem(control, trail, index);
                    return null;
                }, null);

            }
        }


        private void UpdateSelectedItems()
        {
            var updateSelectedItems = new DeferrableObservableCollection<object>();

            if (null != breadcrumb.SelectedItem)
            {

                SelectedItems.BeginUpdate();
                try
                {
                    if (!(breadcrumb.SelectedItem is BreadCrumbViewModel))
                    {
                        if (((WorkspaceItem) (breadcrumb.SelectedItem)).ItemId == "ROOT")
                        {
                            SelectedItems.Clear();
                            SelectedItems.Insert(0, breadcrumb.SelectedItem);
                            return;
                        }
                        SelectedItems.Insert(SelectedItems.Count, breadcrumb.SelectedItem);
                        if (SelectedItems.Count <= 1)
                        {
                            ConvertItemHelper.SelectedItems = SelectedItems;
                            return;
                        }

                        foreach (var workspaceItem in SelectedItems)
                        {
                            updateSelectedItems.Insert(updateSelectedItems.Count, workspaceItem);
                            if (workspaceItem == breadcrumb.SelectedItem)
                            {
                                ConvertItemHelper.SelectedItems = updateSelectedItems;
                                break;
                            }
                        }
                        SelectedItems.Clear();

                        SelectedItems = updateSelectedItems;
                        ConvertItemHelper.SelectedItems = updateSelectedItems;
                    }
                    else
                    {
                        SelectedItems.Clear();
                        SelectedItems.Insert(0, breadcrumb.SelectedItem);
                        return;
                    }

                    #region unusedcode

                    //for (int i = 0; i < SelectedItems.Count-2; i++)
                    //{
                    //    SelectedItems.RemoveAt(i);//}
                    //ConvertItemHelper.TreeViewItemPath = null;
                    //for (int i = 0; i < SelectedItems.Count; i++)
                    //{
                    //    if (SelectedItems[i] is BreadCrumbViewModel)
                    //    {
                    //        ConvertItemHelper.TreeViewItemPath = "ROOT";
                    //    }
                    //    else
                    //    {
                    //        var itemTitle = ((WorkspaceItem)SelectedItems[i]).ItemTitle;
                    //        ConvertItemHelper.TreeViewItemPath = string.Format("{0} / {1}",
                    //                                                           ConvertItemHelper.TreeViewItemPath,
                    //                                                           itemTitle);
                    //    }
                    //}
                    #endregion

                }
                finally
                {
                    SelectedItems.EndUpdate();

                }
            }

        }
        #endregion



    }
}
