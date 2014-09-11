using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Broobu.Fx.UI.ValidationRules
{
    public class PasswordRule : ValidationRule
    {
        public const string PatternStrict = @"^.*(?=.{4,24})(?=.*\d)(?=.*[a-zA-Z]).*$";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string) value))
                return new ValidationResult(false, "The field is mandatory.");

            var reStrict = new Regex(PatternStrict);
            bool isMatch = reStrict.IsMatch((string) value);

            if (isMatch)
                return ValidationResult.ValidResult;

            return new ValidationResult(false,
                "A password must be between 4 and 24 characters long, contain at least one digit, one lowercase and one uppercase character");
        }
    }
}