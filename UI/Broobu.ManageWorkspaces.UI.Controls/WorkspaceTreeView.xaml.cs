using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pms.ManageWorkspaces.Contract.Domain;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pms.ManageWorkspaces.Resources;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class WorkspaceTreeView
    {
        #region  Fields /Members

        public const String Detail = "Detail";
        public const String List = "List";
        private Point _lastMouseDown;
        private TreeViewItem _draggedItem, _target;
        private ObservableCollection<WorkspaceItem> _list;
        private ObservableCollection<WorkspaceItem> _parentlist;
        private TreeViewItem _parentItem = new TreeViewItem();
        private readonly TreeViewItem _targetItem = new TreeViewItem();
        private readonly WorkspaceItem _targetworkspace = new WorkspaceItem();
        private readonly WorkspaceItem _previousworkspace = new WorkspaceItem();
        private bool _expanded;
        public bool Selected = true;
        private bool _isexpanded;
        public TextBlock Loadingtext;
        public List<TextBlock> Loadingtextlist = new List<TextBlock>();
        private const string NamedObject = "NamedObject";
        public object SelectedTreeviewItem;
        private DragDropEffects _dragDropEffects;
        #endregion

        #region Class

        /// <summary>
        /// Class Property Declaration
        /// </summary>
        public new class Property
        {
            public const string WorkspaceItems = "WorkspaceItems";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Dependency Property for WorkspaceItems. 
        /// </summary>
        public static readonly DependencyProperty WorkspaceItem =
            DependencyProperty.Register(Property.WorkspaceItems,
            typeof(ObservableCollection<WorkspaceItem>),
            typeof(WorkspaceTreeView),
            new PropertyMetadata((o, e) =>
            {
                ((WorkspaceTreeView)o).WorkspaceItems = (ObservableCollection<WorkspaceItem>)(e.NewValue);

            }));

        /// <summary>
        /// Gets or sets the workspace items.
        /// </summary>
        /// <value>The workspace items.</value>
        private ObservableCollection<WorkspaceItem> _workspaceItems;
        public ObservableCollection<WorkspaceItem> WorkspaceItems
        {
            get
            {
                return _workspaceItems;
            }
            set
            {
                _workspaceItems = value;

                if (Treeviewitem != null)
                {
                    Treeviewitem.IsSelected = false;
                    Treeviewitem = null;
                    TreeviewitemList = new List<TreeViewItem>();
                }
                MyTreeView.ItemsSource = _workspaceItems;

                if (MyTreeView.Items.Count <= 0) return;
                Vm.WorkspaceId = ((WorkspaceItem)MyTreeView.Items[0]).Id;
                Vm.ItemId = ((WorkspaceItem)MyTreeView.Items[0]).ItemId;
                //commented by bharathi
                //Vm.AsyncMethod();

            }
        }

        /// <summary>
        /// Gets and Sets the boolean value for load text
        /// </summary>
        private bool _loadText;
        public bool LoadText
        {
            get
            {
                return _loadText;
            }
            set
            {
                _loadText = value;
                if (Loadingtext != null) Loadingtext.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Gets or sets the workspace items.
        /// </summary>
        /// <value>The workspace items.</value>
        private ObservableCollection<WorkspaceItem> _workspaceItemsChild;
        public ObservableCollection<WorkspaceItem> WorkspaceItemsChild
        {
            get
            {
                return _workspaceItemsChild;
            }
            set
            {
                _workspaceItemsChild = value;

                if (Treeviewitem != null)
                    if (Treeviewitem.Header != null)
                    {
                        bool drag = true;
                        if (_list != null)
                        {
                            if (_list.Count > 0 && _parentlist.Count > 0)
                            {
                                if (_workspaceItemsChild.Count != 0)
                                    if ((_workspaceItemsChild[0].ParentId == _list[0].ParentId) ||
                                        (_workspaceItemsChild[0].ParentId == _parentlist[0].ParentId))
                                    {
                                        drag = false;

                                        _targetItem.ItemsSource = _targetworkspace.Children = _list.ToList().Where(item => item.Children != null).Where(item => item.Children.Count() > 0).ToArray();
                                    }
                            }
                            else if (_list.Count > 0 && _parentItem.Header != null)
                            {
                                if (_workspaceItemsChild.Count != 0)
                                    if ((_workspaceItemsChild[0].ParentId == _list[0].ParentId) ||
                                        (_workspaceItemsChild[0].ParentId == ((WorkspaceItem)_parentItem.Header).Id))
                                    {
                                        drag = false;

                                        _targetItem.ItemsSource = _targetworkspace.Children = _list.ToList().Where(item => item.Children != null).Where(item => item.Children.Count() > 0).ToArray();
                                    }
                            }
                        }


                        if (drag)
                            if (_workspaceItemsChild.Count != 0)
                            {
                                if (TreeviewitemList.Count() == 0)
                                {
                                    TreeviewitemList.Add(Treeviewitem);
                                }
                                foreach (var treeitem in TreeviewitemList)
                                {
                                    if (treeitem.Header.GetType().Name != NamedObject)
                                        if (((WorkspaceItem)treeitem.Header).Id == _workspaceItemsChild[0].ParentId)
                                        {
                                            //var data = _workspaceItemsChild.ToList().Where(item => item.Children != null).Where(item => item.Children.Count() > 0).ToList();
                                            var data = _workspaceItemsChild.ToList();

                                            var list = new ObservableCollection<WorkspaceItem>();
                                            foreach (var item in data)
                                            {

                                                var info = new WorkspaceItem
                                                {
                                                    AdditionalInfoUri = item.AdditionalInfoUri,
                                                    Children = item.Children,
                                                    DateModified = item.DateModified,
                                                    Descriptions = item.Descriptions,
                                                    Id = item.Id,
                                                    IsFolder = item.IsFolder,
                                                    ItemId = item.ItemId,
                                                    ItemImage = item.ItemImage,
                                                    ItemTitle = item.ItemTitle,
                                                    ParentId = item.ParentId,
                                                    Properties = item.Properties,
                                                    SortOrder = item.SortOrder,
                                                    TypeId = item.TypeId,
                                                    TypeImage = item.TypeImage,
                                                    TypeTitle = item.TypeTitle
                                                };
                                                //info.ItemImage = item.ItemImage.Count() == 0
                                                //                     ? Constants.GetEmbeddedFile("Pms.ManageWorkspaces.Resources",
                                                //                                       "CloseFolder.png")
                                                //                     : item.ItemImage;
                                                list.Add(info);
                                            }

                                            var workspace = treeitem.Header as WorkspaceItem;
                                            if (workspace.Id != _previousworkspace.Id)

                                                if (!treeitem.IsExpanded || _expanded)
                                                    treeitem.ItemsSource = null;

                                            treeitem.ItemsSource = workspace.Children = list.ToArray();
                                            if (Loadingtextlist != null)
                                                if (Loadingtextlist.Count() != 0)
                                                    foreach (var loadtext in Loadingtextlist)
                                                    {
                                                        if (loadtext != null) loadtext.Visibility = Visibility.Collapsed;
                                                    }
                                        }
                                }
                               // Vm.EventBroker.RaiseLoadWorkspaceItemCount(new LoadDetailViewEventArgs() { WorkspaceItemCount = WorkspaceItems.Count });
                            }
                    }
                _expanded = false;
            }
        }

      

        /// <summary>
        /// Gets or sets the Treeviewitem.
        /// </summary>
        /// <value>The TreeViewItem .</value>
        private TreeViewItem _treeViewItem;
        public TreeViewItem Treeviewitem
        {
            get
            {
                return _treeViewItem;
            }
            set
            {
                if (value == null) return;
                _treeViewItem = value;
                var parentItem = ItemsControl.ItemsControlFromItemContainer(_treeViewItem) as TreeViewItem;
                if (WorkspaceItems != null)
                    Vm.EventBroker.RaiseGetModifyItem(parentItem != null ? new LoadWorkspaceItemEventArgs { ModifyItem = parentItem.Header as WorkspaceItem }
                                                          : new LoadWorkspaceItemEventArgs { ModifyItem = WorkspaceItems[0] });
            }
        }

        /// <summary>
        /// Gets ans Sets the TreeViewList
        /// </summary>
        public List<TreeViewItem> TreeviewitemList { get; set; }

        /// <summary>
        /// Gets and Sets the Woekspacepreviousitem
        /// </summary>
        public WorkspaceItem Workspacepreviousitem { get; set; }


        /// <summary>
        /// Declares View Model
        /// </summary>
        public WorkspaceTreeViewViewModel Vm
        {
            get { return (WorkspaceTreeViewViewModel)FindResource("vm"); }
        }

        #endregion

        #region  Constructor

        /// <summary>
        /// Constructor declaration
        /// </summary>
        public WorkspaceTreeView()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            InitializeComponent();
            _dragDropEffects = DragDropEffects.None;
            TreeviewitemList = new List<TreeViewItem>();
            Vm.SelectedWorkspace = Selected;
            Vm.EventBroker.SetWorkspaceChildItem -= EventBroker_SetWorkspaceChildItem;
            Vm.EventBroker.SetWorkspaceChildItem += EventBroker_SetWorkspaceChildItem;
            Vm.EventBroker.LoadText += (snd, e) =>
            {
                LoadText = e.BlnLoad;
            };
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Loads the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Vm.LoadPage();
        }

        /// <summary>
        /// My Tree view expanded and Collapsed event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void MyTreeViewExpanded(object sender, RoutedEventArgs e)
        {
            var item = (e.OriginalSource) as TreeViewItem; 
            if (item == null) return;
            Mouse.OverrideCursor = Cursors.Wait;

            if (!item.IsExpanded && !_isexpanded)
            {
                item.IsExpanded = true;
                item.IsSelected = true;
                _isexpanded = true;

                // to select first element on load
                ThreadPool.QueueUserWorkItem(
                    a =>
                    {
                        Thread.Sleep(100);
                        item.Dispatcher.Invoke(
                            new Action(() => item.IsSelected = true));
                    });
            }

            Workspacepreviousitem = item.Header as WorkspaceItem;

            //if (item.IsExpanded)
            //{
            //    if (Loadingtext != null) Loadingtext.Visibility = Visibility.Visible;
            //    Loadingtextlist.Add(Loadingtext);
            //}

            if (Workspacepreviousitem != null)
            {
                if (Workspacepreviousitem.Id != "")
                {
                    Treeviewitem = item;
                    if (Treeviewitem.Header as WorkspaceItem != null) TreeviewitemList.Add(Treeviewitem);
                    var workspaceId = Workspacepreviousitem.Id;
                    var itemId = Workspacepreviousitem.ItemId;
                    Vm.SelectedWorkspace = true;
                    Vm.EventBroker.RaiseGetWorkspaceId(new LoadWorkspaceItemEventArgs
                                                           {WorkspaceId = workspaceId, ItemId = itemId});
                }

                item.IsSelected = true;
            }
        }

        /// <summary>
        /// My Tree View Selected event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void MyTreeViewSelected(object sender, RoutedEventArgs e)
        {
            try
            {
                Vm.SelectedWorkspace = Selected = true;

                MyTreeView.Tag = e.OriginalSource as TreeViewItem;
                Treeviewitem = e.OriginalSource as TreeViewItem;
                if (Treeviewitem != null)
                    if (Treeviewitem.Header != null)
                    {
                        Workspacepreviousitem = Treeviewitem.Header as WorkspaceItem;
                        Vm.EventBroker.RaiseBreabCrumbTreeViewItem(new LoadWorkspaceItemEventArgs { BreadCrumbtreeviewitem = Treeviewitem });
                    }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, Constants.ProjectTitle, MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Assigns the expanded bool variable true on click of expand image
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TestMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _expanded = true;

        }


        #region Private Method

        /// <summary>
        /// Sets the Workspacechilditem
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LoadWorkspaceItemEventArgs"/> instance containing the event data.</param>
        private void EventBroker_SetWorkspaceChildItem(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (Vm.PopUp) return;
            WorkspaceItemsChild = e.WorkspaceItems;
            Mouse.OverrideCursor = null;
        }



        #endregion

        #endregion

        #region "Unused Methods- DragandDrop"
        /// <summary>
        /// Gets the embedded file.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Byte[]</returns>
        //public static Byte[] GetEmbeddedFile(string assemblyName, string fileName)
        //{
        //    var r = new WorkspaceBrowserResource();
        //    return r.GetEmbeddedFile(assemblyName, fileName);
        //}

        #region Public Methods

        /// <summary>
        /// Gets the selected treeviewItem parent
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ItemsControl GetSelectedTreeViewItemParent(TreeViewItem item)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(item);

            while (!(parent is TreeViewItem || parent is TreeView))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as ItemsControl;
        }


        /// <summary>
        /// Bytestoes the image.
        /// </summary>
        /// <param name="imgByte">The img byte.</param>
        /// <returns></returns>
        public BitmapImage BytestoImage(Byte[] imgByte)
        {
            var bitImg = new BitmapImage();
            if (imgByte != null && imgByte.Length > 0)
            {
                bitImg.BeginInit();
                var ms = new MemoryStream(imgByte);
                bitImg.StreamSource = ms;
                bitImg.EndInit();
            }
            return bitImg;

        }



        #endregion

        /// <summary>
        /// Gets the target and source workspaceitem  in this event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TreeViewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point currentPosition = e.GetPosition(MyTreeView);


                    if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 10.0) ||
                        (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 10.0))
                    {
                        _draggedItem = (TreeViewItem)MyTreeView.Tag;
                        if (_draggedItem != null)
                        {
                            DragDropEffects finalDropEffect = DragDrop.DoDragDrop(MyTreeView, MyTreeView.SelectedValue, DragDropEffects.Move);
                            //Checking target is not null and item is dragging(moving)
                            if ((finalDropEffect == DragDropEffects.Move) && (_target != null))
                            {
                                // A Move drop was accepted
                                if (!_draggedItem.Header.ToString().Equals(_target.Header.ToString()))
                                {
                                    CopyItem(_draggedItem, _target);
                                    _target = null;
                                    _draggedItem = null;
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, Constants.ProjectTitle, MessageBoxButton.OK);
            }
        }


        /// <summary>
        /// Checks the drop and store the drop target
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TreeViewDragOver(object sender, DragEventArgs e)
        {
            try
            {
                Point currentPosition = e.GetPosition(MyTreeView);

                if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 10.0) ||
                    (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 10.0))
                {
                    // Verify that this is a valid drop and then store the drop target
                    TreeViewItem item = GetNearestContainer(e.OriginalSource as UIElement);
                    _dragDropEffects = e.Effects = CheckDropTarget(_draggedItem, item) ? DragDropEffects.Move : DragDropEffects.None;
                }
                e.Handled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, Constants.ProjectTitle, MessageBoxButton.OK);
            }
        }


        /// <summary>
        /// Adding dragged TreeViewItem in target TreeViewItem
        /// </summary>
        /// <param name="sourceItem"></param>
        /// <param name="targetItem"></param>
        public void AddChild(TreeViewItem sourceItem, TreeViewItem targetItem)
        {
            // add item in target TreeViewItem 

            var targetworkspace = targetItem.Header as WorkspaceItem;
            var sourceworkspace = sourceItem.Header as WorkspaceItem;
        //  Vm.SourceWorkspace = sourceworkspace;
           // Vm.Targetworkspace = targetworkspace;
            Vm.SaveDraggedDataAsync();
            //_list = new ObservableCollection<WorkspaceItem>();
            //foreach (var workspaceItem in ((WorkspaceItem)targetItem.Header).Children.ToList())
            //{

            //    _list.Add(workspaceItem);
            //}

            //_list.Add(sourceworkspace);
            //_targetItem = targetItem;
            //_targetworkspace = targetworkspace;
            //if (targetworkspace != null) targetItem.ItemsSource = targetworkspace.Children = _list.ToArray();

        }

        /// <summary>
        /// Checks the target and saves the drop target 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TreeViewDrop(object sender, DragEventArgs e)
        {
            try
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
                // Verify that this is a valid drop and then store the drop target
                TreeViewItem targetItem = GetNearestContainer(e.OriginalSource as UIElement);
                if (targetItem != null && _draggedItem != null)
                {
                    _target = targetItem;
                    e.Effects = DragDropEffects.Move;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, Constants.ProjectTitle, MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Gets Nearest Container
        /// </summary>
        /// <param name="element">The Name of the UIElement</param>
        /// <returns>TreeViewItem</returns>
        private static TreeViewItem GetNearestContainer(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item.
            var container = element as TreeViewItem;
            while ((container == null) && (element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
            }
            return container;
        }
        /// <summary>
        /// Check whether the target item is meeting the below condition
        /// </summary>
        /// <param name="sourceItem">The Name of the sourceitem</param>
        /// <param name="targetItem">The Name of the targetitem</param>
        /// <returns>bool</returns>
        private static bool CheckDropTarget(TreeViewItem sourceItem, TreeViewItem targetItem)
        {
            //Check whether the target item is meeting your condition
            bool isEqual = false;
            if (!sourceItem.Header.ToString().Equals(targetItem.Header.ToString()))
            {
                isEqual = true;
            }
            return isEqual;

        }

        /// <summary>
        /// Copies the source workspace item
        /// </summary>
        /// <param name="sourceItem">The Name of the sourceitem</param>
        /// <param name="targetItem">The Name of the targetitem</param>
        private void CopyItem(TreeViewItem sourceItem, TreeViewItem targetItem)
        {
            if (_dragDropEffects != DragDropEffects.Move) return;
            //Asking user wether he want to drop the dragged TreeViewItem here or not
            if (
                MessageBox.Show(
                    "Are you sure you want to move the folder from " + ((WorkspaceItem)sourceItem.Header).ItemTitle +
                    " to " + ((WorkspaceItem)targetItem.Header).ItemTitle + "", "", MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes)
            {
                try
                {
                    //adding dragged TreeViewItem in target TreeViewItem
                    AddChild(sourceItem, targetItem);

                    //finding Parent TreeViewItem of dragged TreeViewItem 
                    _parentItem = FindVisualParent<TreeViewItem>(sourceItem);
                    // if parent is null then remove from TreeView else remove from Parent TreeViewItem
                    if (_parentItem == null)
                    {
                        // MyTreeView.Items.Remove(_sourceItem);

                    }
                    else
                    {
                        // can be removed when the drag drop refreshed data got fron service
                        var parentworkspace = _parentItem.Header as WorkspaceItem;
                        _parentlist = new ObservableCollection<WorkspaceItem>();
                        foreach (var item in ((WorkspaceItem)_parentItem.Header).Children.ToList())
                        {
                            if (item.Id != (sourceItem.Header as WorkspaceItem).Id)
                            {
                                _parentlist.Add(item);
                            }
                        }
                        if (parentworkspace != null)
                        {
                            _parentItem.ItemsSource = parentworkspace.Children = new WorkspaceItem[] { };
                            parentworkspace.Children = _parentlist.ToArray();

                            _parentItem.ItemsSource = parentworkspace.Children;
                        }
                        Treeviewitem.IsExpanded = true;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, Constants.ProjectTitle, MessageBoxButton.OK);
                }
            }
        }


       
        /// <summary>
        /// Finds the Visual Parent of Treeview item
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="child"></param>
        /// <returns>TObject</returns>
        static TObject FindVisualParent<TObject>(UIElement child) where TObject : UIElement
        {
            if (child == null)
            {
                return null;
            }

            var parent = VisualTreeHelper.GetParent(child) as UIElement;

            while (parent != null)
            {
                var found = parent as TObject;
                if (found != null)
                {
                    return found;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return null;
        }
        #endregion
        
    }
}
