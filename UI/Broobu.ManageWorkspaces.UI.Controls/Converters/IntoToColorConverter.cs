using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pms.WorkspaceBrowser.UI.Controls.Converters
{
    public class IntoToColorConverter : MarkupExtension, IMultiValueConverter
    {

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
 

        public object Convert(object[] values, Type targetType, object parameter,System.Globalization.CultureInfo culture)
        {
            Brush retVal = Brushes.Transparent;
            var o = values[0];
            if (o == null)
            {
                retVal = new SolidColorBrush(Color.FromRgb(198, 211, 231));
            }
            else
            {
                retVal = new SolidColorBrush(Color.FromRgb(232, 234, 232));
            }
         
            return retVal;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
