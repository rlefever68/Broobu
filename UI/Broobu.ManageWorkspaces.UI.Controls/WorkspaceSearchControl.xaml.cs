using System.Windows;
using System.Windows.Input;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for WorkspaceSearchControl.xaml
    /// </summary>
    public partial class WorkspaceSearchControl 
    {
       #region Properties

            /// <summary>
            /// Declares View Model
            /// </summary>
            public WorkspaceSearchControlViewModel Vm
            {
                get { return (WorkspaceSearchControlViewModel)FindResource("vm"); }
            }

            #endregion

       #region Events
        
            /// <summary>
            /// Handles the KeyDown event of the SearchText control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> instance containing the event data.</param>
            private void SearchText_KeyDown(object sender, KeyEventArgs e)
            {
                Vm.WorkspaceItemSearchString = SearchText.Text;
                if (e.Key == Key.Enter)
                    Vm.Search();
            }

            /// <summary>
            /// Handles the PreviewKeyDown event of the SearchText control.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SearchText_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key != Key.Back && e.Key != Key.Delete) return;
                if (SearchText.Text.Length == 1)

                    if (WorkspaceBrowserMainViewViewModel.CurrentListItem != null)
                        Vm.EventBroker.RaiseLoadDetailView(new LoadDetailViewEventArgs
                        {
                            ListItem =
                                WorkspaceBrowserMainViewViewModel.CurrentListItem.
                                Children
                        });
            }

            /// <summary>
            /// Handles the GotFocus event of the SearchText control.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SearchText_GotFocus(object sender, RoutedEventArgs e)
            {
                //SearchText.Text = string.Empty;
                Vm.WorkspaceItemSearchString = string.Empty;
            }

        #endregion

       #region Constructor

            /// <summary>
            /// Initializes the component
            /// </summary>
            public WorkspaceSearchControl()
            {
                InitializeComponent();
            }

            #endregion

    }

}
 
