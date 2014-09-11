using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Broobu.ManageTaxonomy.UI.Controls.ViewModels;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.TreeList;

namespace Broobu.ManageTaxonomy.UI.Controls.Fragments
{
    /// <summary>
    /// Interaction logic for EnumerationsView.xaml
    /// </summary>
    public partial class HookItemsFragment 
    {
        public HookItemsFragment()
        {
            InitializeComponent();
        }


        private void TreeListView_OnNodeExpanding(object sender, TreeListNodeAllowEventArgs e)
        {
            ((HookItemsViewModel)DataContext).ExpandHookItem(e.Node.Content);
        }

        private void DataControlBase_OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            ((HookItemsViewModel)DataContext).ExpandHookItem(e.NewItem);
        }
    }
}
