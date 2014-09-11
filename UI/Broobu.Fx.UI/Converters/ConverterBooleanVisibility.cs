using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Broobu.Fx.UI.Converters
{
    /// <summary>
    ///     Implements a <see cref="IValueConverter" /> that converts a boolean to <see cref="Visibility" />
    /// </summary>
    public class ConverterBooleanVisibility : IValueConverter
    {
        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof (Visibility)) return null;
            if (!(value is bool)) return null;

            //var param = true;
            //if (parameter is string)
            //    param = bool.Parse(parameter as string);

            return (bool) value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility) value == Visibility.Visible;
        }
    }
}