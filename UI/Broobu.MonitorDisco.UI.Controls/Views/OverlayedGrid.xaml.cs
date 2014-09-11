using Broobu.MonitorDisco.UI.Controls.ViewModels;
using DevExpress.Xpf.Grid;

namespace Broobu.MonitorDisco.UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for OverlayedGrid.xaml
    /// </summary>
    public partial class OverlayedGrid 
    {
        public OverlayedGrid()
        {
            InitializeComponent();
        }


        public void OrganizeView()
        {
            var tableView = GrdDisco.View as TableView;
            if (tableView != null) tableView.BestFitColumns();
            GrdDisco.ExpandAllGroups();
        }
    }
}
