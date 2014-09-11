using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Pms.ManageWorkspaces.UI.Controls.Behaviour
{
    public static class SelectorDoubleClickCommandBehavior
    {

        //  static WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
        /// <summary>
        /// HandleDoubleClick Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty HandleDoubleClickProperty =
            DependencyProperty.RegisterAttached("HandleDoubleClick", typeof(bool),
            typeof(SelectorDoubleClickCommandBehavior),
                new FrameworkPropertyMetadata(false,
                    new PropertyChangedCallback(OnHandleDoubleClickChanged)));

        /// <summary>
        /// Gets the HandleDoubleClick property.  
        /// </summary>
        public static bool GetHandleDoubleClick(DependencyObject d)
        {
            return (bool)d.GetValue(HandleDoubleClickProperty);
        }

        /// <summary>
        /// Sets the HandleDoubleClick property. 
        /// </summary>
        public static void SetHandleDoubleClick(DependencyObject d, bool value)
        {
            d.SetValue(HandleDoubleClickProperty, value);
        }

        /// <summary>
        /// Occurs when double click the listview.
        /// </summary>
        /// <param name="d">DependencyObject</param>
        /// <param name="e">DependencyPropertyChangedEventArgs</param>
        public static void OnHandleDoubleClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as Selector;
            if (selector != null)
            {
                if ((bool)e.NewValue)
                {
                    selector.MouseDoubleClick -= OnMouseDoubleClick;
                    selector.MouseDoubleClick += OnMouseDoubleClick;
                }
            }
        }


        #region TheCommandToRun

        /// <summary>
        /// TheCommandToRun : The actual ICommand to run
        /// </summary>
        public static readonly DependencyProperty TheCommandToRunProperty =
            DependencyProperty.RegisterAttached("TheCommandToRun",
                typeof(ICommand),
                typeof(SelectorDoubleClickCommandBehavior),
                new FrameworkPropertyMetadata((ICommand)null));

        /// <summary>
        /// Gets the TheCommandToRun property.  
        /// </summary>
        public static ICommand GetTheCommandToRun(DependencyObject d)
        {
            return (ICommand)d.GetValue(TheCommandToRunProperty);
        }

        /// <summary>
        /// Sets the TheCommandToRun property.  
        /// </summary>
        public static void SetTheCommandToRun(DependencyObject d, ICommand value)
        {
            d.SetValue(TheCommandToRunProperty, value);
        }
        #endregion


        #region Private Methods

        /// <summary>
        /// Occurs when double click the listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var listView = sender as ItemsControl;
            DependencyObject originalSender = e.OriginalSource as DependencyObject;
            if (listView == null || originalSender == null) return;

            var container = ItemsControl.ContainerFromElement(sender as ItemsControl, e.OriginalSource as DependencyObject);

            if (container == null || container == DependencyProperty.UnsetValue) return;

            // found a container, now find the item.
            object activatedItem = listView.ItemContainerGenerator.ItemFromContainer(container);

            //  string id = ((Pms.ManageWorkspaces.Domain.WorkspaceItem) (activatedItem)).Id;
            //  workspaceViewModel.selectedID = id;
            if (activatedItem != null)
            {
                var command = (ICommand)(sender as DependencyObject).GetValue(TheCommandToRunProperty);

                if (command != null)
                {
                    if (command.CanExecute(null))
                        command.Execute(null);
                }
                
            }
        }

        #endregion
    }
}
