// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.UI.Controls
// Author           : Rafael Lefever
// Created          : 12-25-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-25-2013
// ***********************************************************************
// <copyright file="StatusToColorConverter.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Windows.Data;
using Broobu.Fx.UI.Utils;
using Broobu.MonitorDisco.Contract.Domain;

namespace Broobu.MonitorDisco.Contract.Converters
{
    /// <summary>
    /// Class StatusToColorConverter.
    /// </summary>
    public class StatusToColorConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value == null) || (!(value is string)))
                return ColorUtils.Convert.ToMediaColor(Color.White);
            var s = (value as string);
            switch(s)
            {
                case DiscoStatus.Discovered:
                    return ColorUtils.Convert.ToMediaColor(Color.Navy);
                case DiscoStatus.Offline:
                    return ColorUtils.Convert.ToMediaColor(Color.DarkOrange);
                case DiscoStatus.Online:
                    return ColorUtils.Convert.ToMediaColor(Color.DarkGreen);
                case DiscoStatus.Error:
                    return ColorUtils.Convert.ToMediaColor(Color.DarkRed);
                case DiscoStatus.Unknown:
                default:
                    return ColorUtils.Convert.ToMediaColor(Color.Gray);
            }
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
