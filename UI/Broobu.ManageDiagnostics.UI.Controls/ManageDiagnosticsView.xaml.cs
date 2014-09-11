
using DevExpress.Xpf.Grid;
using Pms.ManageDiagnostics.Contract.Domain;

namespace Pms.ManageDiagnostics.UI.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// <remarks></remarks>
    public partial class ManageDiagnosticsView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageDiagnosticsView"/> class.
        /// </summary>
        /// <remarks></remarks>
        public ManageDiagnosticsView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Called when [first time render].
        /// </summary>
        /// <remarks></remarks>
        protected override void OnFirstTimeRender()
        {
            DataContext = new DiagnosticsViewModel();
            base.OnFirstTimeRender();
            vwBatch.FocusedRowChanged += (s, e) =>
                                             {
                                                 ((DiagnosticsViewModel) DataContext).FocusedBatch =
                                                     (DiagnosticsBatchViewItem) e.NewRow;
                                             };
        }
    }
}
