using System;
using System.Threading;
using System.Windows;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for WorkspaceDescriptionsView.xaml
    /// </summary>
    public partial class WorkspaceDescriptionsView
    {

        #region Properties

        /// <summary>
        /// Declares View Model
        /// </summary>
        public WorkspaceDescriptionsViewViewModel Vm
        {
            get { return (WorkspaceDescriptionsViewViewModel)FindResource("vm"); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceDescriptionsView()
        {
            // unloaded event is not triggered in all Application exit cases, this event however is (see
            Dispatcher.ShutdownStarted += DispatcherShutdownStarted;
            InitializeComponent();
        }


        /// <summary>
        /// Saves the grid's column size & order when exiting the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcherShutdownStarted(object sender, EventArgs e)
        {
            DxgItems.SaveUserSettings();
        }
        #endregion

        #region Event Handler

        /// <summary>
        /// Deletes the particular description selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RoutedEventArgs</param>
        private void BtnDeleteDescription_Click(object sender, RoutedEventArgs e)
        {
            Vm.DeleteDescription.Execute(null);
        }

        /// <summary>
        ///  Click to open popup for add a new descritpion and modify existing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RoutedEventArgs</param>
        private void AddDescription_Click(object sender, RoutedEventArgs e)
        {
            Vm.ShowAddDescriptionPopUp.Execute(null);
        }
       #endregion

    }
}
