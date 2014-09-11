using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace Wulka.UI.Markup
{
    public class Converter : MarkupExtension
    {
        private readonly Type _type;

        public Converter(Type type)
        {
            if (!typeof (IValueConverter).IsAssignableFrom(type))
                throw new Exception(String.Format("{0} is not a IValueConverter.", type));
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Activator.CreateInstance(_type);
        }
    }
}