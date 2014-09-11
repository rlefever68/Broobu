using System;
using System.Windows;

namespace Broobu.Fx.UI
{
    /// <summary>
    /// </summary>
    public class ThemeUtil
    {
        /// <summary>
        ///     Applies the default theme.
        /// </summary>
        public static void ApplyDefaultTheme(Uri source)
        {
            var theme = new ResourceDictionary
            {
                Source = source
            };
            Application.Current.Resources = theme;
        }
    }
}