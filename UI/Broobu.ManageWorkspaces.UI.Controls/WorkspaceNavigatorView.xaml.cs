using System.Windows.Input;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for WorkspaceNavigator.xaml
    /// </summary>
    public partial class WorkspaceNavigator
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
        /// Initializes a new instance of the <see cref="WorkspaceNavigator"/> class.
        /// </summary>
        public WorkspaceNavigator()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Treeview Event for Refresh
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> instance containing the event data.</param>
        private void WsTreeViewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.F5)
            {
                //Vm.GetFoldersAsync();
            }
        }

        #endregion
    }
}
