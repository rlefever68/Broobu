using System.Collections;
using System.ComponentModel;
using System.Windows;
using NLog;
using Wulka.Domain.Interfaces;
using Wulka.Exceptions;

namespace Broobu.Fx.UI.Fragments
{
    /// <summary>
    ///     Interaction logic for PartsFragment.xaml
    /// </summary>
    public partial class PartsFragment
    {
        public static DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof (IEnumerable), typeof (PartsFragment));


        public static readonly DependencyProperty RootProperty =
            DependencyProperty.Register("Root", typeof (IComposedObject), typeof (PartsFragment),
                new FrameworkPropertyMetadata());

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public PartsFragment()
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
            get { return PartsGrid.SelectedItems; }
        }

        [Bindable(true)]
        public IComposedObject Root
        {
            get { return GetValue(RootProperty) as IComposedObject; }
            set
            {
                if (value == null) return;
                SetValue(RootProperty, value);
                PartsGrid.ItemsSource = value.Parts;
            }
        }

        private void Image_OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            _logger.Error(e.ErrorException.GetCombinedMessages());
        }
    }
}