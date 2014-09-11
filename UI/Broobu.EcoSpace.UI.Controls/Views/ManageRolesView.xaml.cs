using Broobu.EcoSpace.Contract.Domain.Roles;
using DevExpress.Mvvm;

namespace Broobu.EcoSpace.UI.Controls.Views
{
    /// <summary>
    ///     Interaction logic for RolesFragment.xaml
    /// </summary>
    public partial class ManageRolesView
    {
        public ManageRolesView()
        {
            InitializeComponent();
        }

        private void RolesTreeFragment_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            e.Handled = true;
            var role = (IRole)e.NewItem;
            if (role == null) return;
            
        }
    }
}