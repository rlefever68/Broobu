using System;
using System.Windows.Markup;

namespace Wulka.UI.Markup
{
    /// <summary>
    ///     Markup extension used to fetch a localized string.
    /// </summary>
    public class L : MarkupExtension
    {
        private readonly string _id;

        /// <summary>
        /// </summary>
        public L(string id)
        {
            _id = id;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _id;
        }
    }
}