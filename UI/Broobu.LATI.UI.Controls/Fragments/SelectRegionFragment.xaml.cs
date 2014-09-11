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

namespace Broobu.LATI.UI.Controls.Fragments
{
    /// <summary>
    /// Interaction logic for SelectRegion.xaml
    /// </summary>
    public partial class SelectRegionFragment 
    {
        public SelectRegionFragment()
        {
            InitializeComponent();
        }


        public static DependencyProperty SelectedRegionProperty =
            DependencyProperty.Register("SelectedRegion", 
            typeof(string), 
            typeof(SelectRegionFragment),
            new FrameworkPropertyMetadata());


        public string SelectedRegion { get; set; }
    }
}
