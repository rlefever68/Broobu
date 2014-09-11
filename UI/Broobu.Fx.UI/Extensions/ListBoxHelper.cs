using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Broobu.Fx.UI.Extensions
{
    public class ListBoxHelper
    {
        #region SelectedItems

        /// SelectedItems Attached Dependency Property
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached("SelectedItems", typeof (IList), typeof (ListBoxHelper),
                new FrameworkPropertyMetadata(null,
                    OnSelectedItemsChanged));

        private static bool _busy;

        /// Gets the SelectedItems property. This dependency property
        /// indicates ….
        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList) d.GetValue(SelectedItemsProperty);
        }

        /// Sets the SelectedItems property. This dependency property
        /// indicates ….
        public static void SetSelectedItems(DependencyObject d, IList value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }

        /// Called when SelectedItems is set
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listBox = (ListBox) d;
            ListBoxSelectionChanged(listBox);
            IList selectedItems = GetSelectedItems(listBox);
            ((INotifyCollectionChanged) selectedItems).CollectionChanged +=
                delegate { BoundCollectionChanged(listBox); };
            listBox.SelectionChanged += delegate { ListBoxSelectionChanged(listBox); };
        }

        /// Update the listbox
        private static void BoundCollectionChanged(ListBox listBox)
        {
            if (_busy)
                return;

            _busy = true;
            IList selectedItems = GetSelectedItems(listBox);
            listBox.SelectedItems.Clear();
            if (selectedItems != null)
            {
                foreach (object item in selectedItems)
                    listBox.SelectedItems.Add(item);
            }
            _busy = false;
        }

        #endregion

        /// Update the bound collection
        private static void ListBoxSelectionChanged(ListBox listBox)
        {
            if (_busy)
                return;

            _busy = true;
            IList selectedItems = GetSelectedItems(listBox);
            selectedItems.Clear();
            if (listBox.SelectedItems != null)
            {
                foreach (object item in listBox.SelectedItems)
                    selectedItems.Add(item);
            }
            _busy = false;
        }
    }
}