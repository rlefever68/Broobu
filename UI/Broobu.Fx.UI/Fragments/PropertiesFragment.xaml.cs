namespace Broobu.Fx.UI.Fragments
{
    /// <summary>
    ///     Interaction logic for PropertiesFragment.xaml
    /// </summary>
    public partial class PropertiesFragment
    {
        public PropertiesFragment()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { PropertyGridControl.SelectedObject = e.NewValue; };
        }
    }
}