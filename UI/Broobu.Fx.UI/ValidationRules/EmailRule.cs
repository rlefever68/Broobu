using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Broobu.Fx.UI.ValidationRules
{
    public class EmailRule : ValidationRule
    {
        private const string PatternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                             + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                             + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                             + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                             + @"[a-zA-Z]{2,}))$";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string) value))
                return new ValidationResult(false, "The field is mandatory.");

            var reStrict = new Regex(PatternStrict);
            bool isMatch = reStrict.IsMatch((string) value);

            if (isMatch)
                return ValidationResult.ValidResult;

            return new ValidationResult(false, "This field requires a valid Email Address");
        }
    }
}