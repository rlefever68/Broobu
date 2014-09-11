
using System.Windows.Input;
using System.Windows.Media;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for PopUpTreeView.xaml
    /// </summary>
    public partial class PopUpTreeView 
    {
        #region Properties

        /// <summary>
        /// Declares View Model
        /// </summary>
        public WorkspaceNavigatorViewViewModel Vm
        {
            get { return (WorkspaceNavigatorViewViewModel)FindResource("vm"); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public PopUpTreeView()
        {
            InitializeComponent();
            wsTreeView.MyTreeView.SelectedItemChanged += MyTreeView_SelectedItemChanged;
            wsTreeView.MyTreeView.Background = new SolidColorBrush(Color.FromRgb(231, 238, 246));
            //Vm.EventBroker.RaiseLoadIsRefresh(new LoadDetailViewEventArgs {IsRefresh = true});
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Occurs when select the treeview item.
        /// </summary>
        /// <param name="sender">Treeview usercontrol</param>
        /// <param name="e">RoutedPropertyChangedEventArgs</param>
        private void MyTreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            if (e.NewValue != null)
            {
                var item = ((WorkspaceItem)(e.NewValue));
                Vm.SelectedItem = item;
                //Mouse.OverrideCursor = null;
                Vm.EventBroker.RaiseGetWorkspaceId(new LoadWorkspaceItemEventArgs { WorkspaceId = item.Id, ItemId = item.ItemId });
            }
        }
        /// <summary>
        /// Call when click the ok button 
        /// </summary>
        /// <param name="sender">Popuptreeview</param>
        /// <param name="e">RoutedEventArgs</param>
        private void BtnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Vm.RaiseEvent();
            Close();
        }

        /// <summary>
        /// call when click the close button
        /// </summary>
        /// <param name="sender">PopUpTreeView</param>
        /// <param name="e">RoutedEventArgs</param>
        private void BtnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        #endregion
        

    }
}
