using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Pms.ManageWorkspaces.UI.Controls.Behaviour
{
    public class SelectionBehavior
    {
        /// <summary>
        /// Selectionchanged property for Listview item.
        /// </summary>
        public static DependencyProperty SelectionChangedProperty = DependencyProperty.RegisterAttached("SelectionChanged", typeof(ICommand), typeof(SelectionBehavior),new UIPropertyMetadata(SelectedItemChanged));


        /// <summary>
        /// Set the selection changed property to assign to ICommand.
        /// </summary>
        /// <param name="target">DependencyObject</param>
        /// <param name="value">ICommand</param>
        public static void SetSelectionChanged(DependencyObject target, ICommand value)
        {
            target.SetValue(SelectionChangedProperty, value);
        }

        /// <summary>
        /// Occurs when the selectedItemchanged in listview.
        /// </summary>
        /// <param name="target">DependencyObject</param>
        /// <param name="e">DependencyPropertyChangedEventArgs</param>
        static void SelectedItemChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Selector element = target as Selector;
            if (element == null) throw new InvalidOperationException("This behavior can be attached to Selector item only.");
            if ((e.NewValue != null) && (e.OldValue == null))
            {
                element.SelectionChanged += SelectionChanged;
            }
            else if ((e.NewValue == null) && (e.OldValue != null))
            {
                element.SelectionChanged -= SelectionChanged;
            }
        }

        /// <summary>
        /// Occurs when the selection changed in listview.
        /// </summary>
        /// <param name="sender">Listview</param>
        /// <param name="e">SelectionChangedEventArgs</param>
        static void SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UIElement element = (UIElement)sender;
            var command = (ICommand)element.GetValue(SelectionChangedProperty);
            command.Execute(((Selector)sender).SelectedValue);
        }
    }
}

