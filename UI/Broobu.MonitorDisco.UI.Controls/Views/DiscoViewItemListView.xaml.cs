using Broobu.MonitorDisco.UI.Controls.ViewModels;
using DevExpress.Xpf.Grid;

namespace Broobu.MonitorDisco.UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for DiscoViewItemListView.xaml
    /// </summary>
    public partial class DiscoViewItemListView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoViewItemListView"/> class.
        /// </summary>
        public DiscoViewItemListView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Called when [first time show].
        /// </summary>
        protected override void OnFirstTimeRender()
        {
            DataContext = new DiscoInfoViewModel();
            base.OnFirstTimeRender();
            ((DiscoInfoViewModel)DataContext).PropertyChanged += (s, e) =>  
            {
                (GrdDisco.View as TableView).BestFitColumns();
                GrdDisco.ExpandAllGroups();
            };
        }


        
    }
}
