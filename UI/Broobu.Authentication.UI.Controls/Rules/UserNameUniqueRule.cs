using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Broobu.Authentication.Contract;
using DevExpress.Xpf.Editors;

namespace Broobu.Authentication.UI.Controls.Rules
{
    public class UserNameUniqueRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var res = AuthenticationPortal
                .Authentication
                .UserNameExists(Convert.ToString(value));
            return !res.Id ? ValidationResult.ValidResult : new ValidationResult(false,String.Format("User {0} already exisits", value));
        }


        public static DependencyProperty IsUniqueProperty =
            DependencyProperty.Register("IsUnique", typeof(bool), typeof(UserNameUniqueRule));

        private bool _isUnique;


        public bool IsUnique
        {
            get { return _isUnique; }
            set { _isUnique = value;}
        }
    }
}
