using System;
using System.Globalization;
using System.Windows.Data;

namespace Broobu.Fx.UI.Converters
{
    /// <summary>
    ///     Converter that can be used to check the value of an enumeration.
    /// </summary>
    public class ConverterIsEnumSelected : IValueConverter
    {
        /// <summary>
        ///     Gets or sets the type of the enum.
        /// </summary>
        /// <value>The type of the enum.</value>
        public Type EnumType { get; set; }

        #region Implementation of IValueConverter

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">
        ///     The value produced by the binding source.
        /// </param>
        /// <param name="targetType">
        ///     The type of the binding target property.
        /// </param>
        /// <param name="parameter">
        ///     The converter parameter to use.
        /// </param>
        /// <param name="culture">
        ///     The culture to use in the converter.
        /// </param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (EnumType != null && EnumType.IsEnum)
            {
                if (value.GetType().Equals(EnumType) == false) return false;
                if (string.IsNullOrEmpty(parameter as string)) return false;

                try
                {
                    object enumRef = Enum.Parse(EnumType, (string) parameter);
                    return (int) value == (int) enumRef;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return value;
        }

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">
        ///     The value that is produced by the binding target.
        /// </param>
        /// <param name="targetType">
        ///     The type to convert to.
        /// </param>
        /// <param name="parameter">
        ///     The converter parameter to use.
        /// </param>
        /// <param name="culture">
        ///     The culture to use in the converter.
        /// </param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (EnumType != null && EnumType.IsEnum)
            {
                if (value is Boolean)
                {
                    if (string.IsNullOrEmpty(parameter as string)) return value;

                    if ((Boolean) value)
                    {
                        return Enum.Parse(EnumType, (string) parameter);
                    }
                }
            }

            return value;
        }

        #endregion
    }
}