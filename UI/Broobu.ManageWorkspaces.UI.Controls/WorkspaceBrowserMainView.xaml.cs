using System.Windows;
using ActiproSoftware.Windows;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{

    /// <summary>
    /// Interaction logic for WorkspaceBrowserMainView.xaml
    /// </summary>
    public partial class WorkspaceBrowserMainView
    {
        #region Member Fields

        /// <summary>
        /// Holds the items shown in the ComboBox in the Breadcrumb.
        /// </summary>
        private readonly DeferrableObservableCollection<object> _comboBoxItems = new DeferrableObservableCollection<object>();
        private bool _flag = true;
        #endregion

        #region Properties

        /// <summary>
        /// Declares View Model
        /// </summary>
        public WorkspaceBrowserMainViewViewModel Vm
        {
            get { return (WorkspaceBrowserMainViewViewModel)FindResource("vm"); }
        }

        #endregion

        #region Events


        /// <summary>
        /// Treeview selected item changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="object"/> instance containing the event data.</param>
        private void MyTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null)
            {
                wsBreadCrumb.breadcrumb.SelectedItem = e.NewValue;
                
                var currentItem = ((WorkspaceItem)(e.NewValue));

                Vm.EventBroker.RaiseSelectedItemChange(new LoadWorkspaceItemEventArgs { SelectedItem = currentItem });
                Vm.SelectedItem = currentItem;
                if (_flag)
                {
                    Vm.EventBroker.RaiseGetWorkspaceId(new LoadWorkspaceItemEventArgs { WorkspaceId = currentItem.Id, ItemId = currentItem.ItemId });
                    _flag = false;
                }
            }
            //UpdateComboBoxItems();
        }

        /// <summary>
        /// Activates the Property Docking Window
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void BtnPropertiesWindowClick(object sender, ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs e)
        {
            twProperties.Activate();
        }

        /// <summary>
        /// Activates the Navigator Docking Window
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void BtnNavigatorWindowClick(object sender, ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs e)
        {
            twNavigator.Activate();
        }

        /// <summary>
        /// Activates the Description Docking Window
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void BtnDescWindowClick(object sender, ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs e)
        {
            twDescriptions.Activate();
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceBrowserMainView"/> class.
        /// </summary>
        public WorkspaceBrowserMainView()
        {
            InitializeComponent();
            Vm.BlnBack = false;
            Vm.EventBroker.GetFolderString += (snd, e) => Vm.NewFolderString = e.NewFolderString;
            wsNavigator.wsTreeView.MyTreeView.SelectedItemChanged += MyTreeViewSelectedItemChanged;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Vm.EventBroker.RaiseGetTreeView(new LoadWorkspaceItemEventArgs { Treeview = wsNavigator.wsTreeView.MyTreeView });
        }
        #endregion

        #region "Usused Methods"

        /// <summary>
        /// Updates the ComboBoxitems for BreadCrumb Control
        /// </summary>
        //private void UpdateComboBoxItems()
        //{
        //    if (null != wsNavigator.wsTreeView.MyTreeView.SelectedItem)
        //    {
        //        ComboBoxItems.BeginUpdate();
        //        try
        //        {
        //            // Insert it at the beginning
        //            ComboBoxItems.Insert(0, wsNavigator.wsTreeView.MyTreeView.SelectedItem);

        //            // Cap the size of the list
        //            while (ComboBoxItems.Count > 15)
        //                ComboBoxItems.RemoveAt(15);
        //        }
        //        finally
        //        {
        //            ComboBoxItems.EndUpdate();
        //        }
        //    }
        //}

        /// <summary>
        /// Gets the combo box items for BreadCrumb Control
        /// </summary>
        /// <value>The combo box items.</value>
        //private DeferrableObservableCollection<object> ComboBoxItems
        //{
        //    get
        //    {
        //        return _comboBoxItems;
        //    }
        //}
        #endregion
    
    }

}
