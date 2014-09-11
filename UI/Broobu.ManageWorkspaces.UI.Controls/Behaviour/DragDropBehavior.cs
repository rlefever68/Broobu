using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls.Behaviour
{
    public class DragDropBehavior : WorkspaceBrowserViewModelBase
    {

        public DragDropBehavior()
        {
            _dragDropEffects = DragDropEffects.None;
        }

        private static Point _lastMouseDown;
        private static TreeView _treeView;
        private static ObservableCollection<WorkspaceItem> _parentlist;
        private static ObservableCollection<WorkspaceItem> _list;

        protected override void InitializeInternal(object[] parameters)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        public static DragDropBehavior Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static DragDropBehavior instance= new DragDropBehavior();


        public static WorkspaceItem SourceWorkspace
        {
            get;
            set;
        }

        public static WorkspaceItem Targetworkspace
        {
            get;
            set;
        }


        #region Attached Properties

        private static TreeViewItem _draggedItem, _target;
        private static DragDropEffects _dragDropEffects;
        private static TreeViewItem _parentItem = new TreeViewItem();

        public static DependencyProperty EnableDragProperty =
            DependencyProperty.RegisterAttached("EnableDrag", typeof(bool), typeof(DragDropBehavior),
            new PropertyMetadata(OnEnableDragDropChanged));

        public static DependencyProperty EnableDropProperty =
            DependencyProperty.RegisterAttached("EnableDrop", typeof(bool), typeof(DragDropBehavior),
            new PropertyMetadata(OnEnableDragDropChanged));

        public static DependencyProperty ConfirmDropProperty =
            DependencyProperty.RegisterAttached("ConfirmDrop", typeof(bool), typeof(DragDropBehavior),
            new PropertyMetadata(true));


        public static bool GetEnableDrag(DependencyObject target)
        {
            return (bool)target.GetValue(EnableDragProperty);
        }

        public static void SetEnableDrag(DependencyObject target, bool value)
        {
            target.SetValue(EnableDragProperty, value);
        }

        public static bool GetEnableDrop(DependencyObject target)
        {
            return (bool)target.GetValue(EnableDropProperty);
        }

        public static void SetEnableDrop(DependencyObject target, bool value)
        {
            target.SetValue(EnableDropProperty, value);
        }

        public static bool GetConfirmDrop(DependencyObject target)
        {
            return (bool)target.GetValue(ConfirmDropProperty);
        }

        public static void SetConfirmDrop(DependencyObject target, bool value)
        {
            target.SetValue(ConfirmDropProperty, value);
        }

        public static void OnEnableDragDropChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == EnableDragProperty)
            {
                #region EnableDrag
                if ((bool)e.NewValue)
                {
                    if (s is TreeView)
                    {
                        UIElement ele = s as UIElement;
                        ele.PreviewMouseDown += new MouseButtonEventHandler(TreeView_MouseDown);
                        ele.MouseMove += new MouseEventHandler(TreeView_MouseMove);
                    }
                    else

                        throw new ArgumentException("Support ListView or TreeView only.");
                }
                else
                {
                    if (s is TreeView)
                    {
                        UIElement ele = s as UIElement;
                        ele.PreviewMouseDown -= new MouseButtonEventHandler(TreeView_MouseDown);
                        ele.MouseMove -= new MouseEventHandler(TreeView_MouseMove);
                    }
                }
                #endregion
            }
            else
            {
                #region EnableDrag
                if ((bool)e.NewValue)
                {
                    if (s is TreeView)
                    {
                        UIElement ele = s as UIElement;
                        ele.AllowDrop = true;
                        ele.DragOver += new DragEventHandler(TreeViewDragOver);
                        ele.Drop += new DragEventHandler(TreeViewDrop);
                    }
                    else throw new ArgumentException("Support ListView or TreeView only.");
                }
                else
                {
                    if (s is TreeView)
                    {
                        UIElement ele = s as UIElement;
                        ele.DragOver -= new DragEventHandler(TreeViewDragOver);
                        ele.Drop -= new DragEventHandler(TreeViewDrop);
                    }
                }
                #endregion
            }

        }
      

        private static void TreeView_MouseDown(object sender, MouseButtonEventArgs e)
        {
             if(e.ChangedButton==MouseButton.Left)
             {
                 _lastMouseDown = e.GetPosition(_treeView);
             }
        }

        private static void TreeView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(_treeView);

                // Note: This should be based on some accessibility number and not just 2 pixels
                if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 2.0) ||
                    (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 2.0))
                {
                    TreeView treeView = sender as TreeView;
                    _treeView = treeView;

                    _draggedItem = (TreeViewItem)_treeView.Tag;
                    if ((_draggedItem != null))
                    {
                        TreeViewItem container = GetNearestContainer(_draggedItem);
                        if (container != null)
                        {
                            DragDropEffects finalDropEffect = DragDrop.DoDragDrop(_treeView, _treeView.SelectedValue, DragDropEffects.Move);
                   
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
        }


        /// <summary>
        /// Checks the drop and store the drop target
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private static void TreeViewDragOver(object sender, DragEventArgs e)
        {
            try
            {

                Point currentPosition = e.GetPosition(_treeView);


                if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 10.0) ||
                    (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 10.0))
                {
                    // Verify that this is a valid drop and then store the drop target
                    TreeViewItem item = GetNearestContainer(e.OriginalSource as UIElement);
                    _dragDropEffects = e.Effects = CheckDropTarget(_draggedItem, item) ? DragDropEffects.Move : DragDropEffects.None;

                }
                e.Handled = true;
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Checks the target and saves the drop target 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private static void TreeViewDrop(object sender, DragEventArgs e)
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
            catch (Exception)
            {
            }
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
        /// Copies the source workspace item
        /// </summary>
        /// <param name="sourceItem">The Name of the sourceitem</param>
        /// <param name="targetItem">The Name of the targetitem</param>
        private static void CopyItem(TreeViewItem sourceItem, TreeViewItem targetItem)
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
                        // coded by bharathi
                        // can be removed when the drag drop refreshed data got fron service
                        //start
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

                        //TheTreeView.IsExpanded = true;
                        //end
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        /// <summary>
        /// Adding dragged TreeViewItem in target TreeViewItem
        /// </summary>
        /// <param name="sourceItem"></param>
        /// <param name="targetItem"></param>
        private static void AddChild(TreeViewItem sourceItem, TreeViewItem targetItem)
        {
            // add item in target TreeViewItem 
            var targetworkspace = Targetworkspace = targetItem.Header as WorkspaceItem;
            var sourceworkspace = SourceWorkspace = sourceItem.Header as WorkspaceItem;

            instance.TargetWorkspace();

            _list = new ObservableCollection<WorkspaceItem>();
            foreach (var workspaceItem in ((WorkspaceItem)targetItem.Header).Children.ToList())
            {

                _list.Add(workspaceItem);
            }

            _list.Add(sourceworkspace);
            //_targetItem = targetItem;
            //_targetworkspace = targetworkspace;
            if (targetworkspace != null) targetItem.ItemsSource = targetworkspace.Children = _list.ToArray();

        }

        public void TargetWorkspace()
        {
            instance.EventBroker.RaiseLoadTreeViewDropEnable(new LoadWorkspaceItemEventArgs() {TreeViewDropEnable = true} );
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
