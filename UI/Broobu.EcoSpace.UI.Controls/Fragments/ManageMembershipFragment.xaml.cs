using Broobu.EcoSpace.Contract.Domain.Roles;

namespace Broobu.EcoSpace.UI.Controls.Fragments
{
    /// <summary>
    ///     Interaction logic for MembershipFragment.xaml
    /// </summary>
    public partial class ManageMembershipFragment
    {
        private IRole _role;


        public ManageMembershipFragment()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { _role = e.NewValue as IRole; };
        }
    }
}