using System.Collections;
using System.ComponentModel;
using System.Windows;
using Wulka.Domain.Interfaces;

namespace Broobu.Fx.UI.Fragments
{
    /// <summary>
    ///     Interaction logic for ExplorerFragment.xaml
    /// </summary>
    public partial class ExplorerFragment
    {
        public static DependencyProperty RootProperty =
            DependencyProperty.Register("Root", typeof (IComposedObject), typeof (ExplorerFragment));


        public static DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof (IEnumerable), typeof (ExplorerFragment));

        public ExplorerFragment()
        {
            InitializeComponent();
            DataContextChanged += (s, e) =>
            {
                if (e.NewValue is IComposedObject)
                {
                    Root = e.NewValue as IComposedObject;
                }
            };
        }


        [Bindable(true)]
        public IEnumerable SelectedItems
        {
            get { return PartsFragment.SelectedItems; }
        }


        [Bindable(true)]
        public IComposedObject Root
        {
            get { return GetValue(RootProperty) as IComposedObject; }
            set
            {
                if (value == null) return;
                SetValue(RootProperty, value);
                TreeFragment.DataContext = Root;
                TreeFragment.SelectedItemChanged +=
                    (s, e) => { PartsFragment.DataContext = e.NewItem as IComposedObject; };
            }
        }
    }
}