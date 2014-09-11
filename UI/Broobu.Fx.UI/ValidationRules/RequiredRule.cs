using System.Globalization;
using System.Windows.Controls;

namespace Broobu.Fx.UI.ValidationRules
{
    public class RequiredRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string) value))
                return new ValidationResult(false, "The field is mandatory.");
            return ValidationResult.ValidResult;
        }
    }
}