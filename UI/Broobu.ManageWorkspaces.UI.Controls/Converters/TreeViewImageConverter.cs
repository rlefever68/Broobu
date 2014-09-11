using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Pms.ManageWorkspaces.UI.Controls.Converters
{
    #region HeaderToImageConverter

    [ValueConversion(typeof(string), typeof(bool))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        /// <summary>
        /// Treeview open and close folder coverter. 
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>  A converted image. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
             if((bool) (value))
            {
                Uri uri = new Uri("pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/OpenFolder.png");
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
            else
            {
                Uri uri = new Uri("pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/DefaultCloseFolder.png");
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    #endregion // DoubleToIntegerConverter


}