using System;
using System.Drawing;
using System.Windows.Data;
using Pms.Framework.Utils;
using Pms.ManageDiagnostics.Contract.Domain;

namespace Pms.ManageDiagnostics.UI.Controls
{
    public class StatusToColorConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
            if (!String.IsNullOrWhiteSpace((string)value))
            {
                switch(value as string)
                {
                    case DiagnosticsStatus.Valid:
                        return ColorUtils.Convert.ToMediaColor(Color.DarkGreen);
                    case DiagnosticsStatus.Aborted:
                        return ColorUtils.Convert.ToMediaColor(System.Drawing.Color.DarkOrange);
                    case DiagnosticsStatus.Error:
                        return ColorUtils.Convert.ToMediaColor(System.Drawing.Color.Red);
                    case DiagnosticsStatus.Running:
                        return ColorUtils.Convert.ToMediaColor(System.Drawing.Color.DarkBlue);
                    case DiagnosticsStatus.Pending:
                    default:
                        return ColorUtils.Convert.ToMediaColor(System.Drawing.Color.DarkGray);
                }
            }
            return ColorUtils.Convert.ToMediaColor(System.Drawing.Color.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
