using System;
using System.Globalization;
using System.Windows.Data;

namespace Broobu.Fx.UI.Converters
{
    public class DateTimeToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (TimeSpan) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}