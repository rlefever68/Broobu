namespace Iris.MonitorSession.UI.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SessionViewItemListView
    {
        public SessionViewItemListView()
        {
            InitializeComponent();
            DataContext = new SessionViewItemViewModel();
        }


    }
}
