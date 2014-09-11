namespace Broobu.Desktop.UI.Controls
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView
    {
        private AboutViewModel Model
        {
            get { return (AboutViewModel)DataContext; }
        }

        public AboutView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => ((AboutViewModel)DataContext).Initialize();
        }
    }
}
