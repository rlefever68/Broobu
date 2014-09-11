using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for PopUpListView.xaml
    /// </summary>
    public partial class WorkspaceSearchResultView
    {

        public WorkspaceSearchResultView()
        {
            InitializeComponent();
        }

        public void Initialize(WorkspaceSearchResultViewModel searchVm)
        {
            searchVm.EventBroker.ApplicationName += CloseWindow;
            DataContext = searchVm;

        }

        private void CloseWindow(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (e.ApplicationName == Constants.ViewNames.PopuUpListView)
                Close();
        }
    }
}
