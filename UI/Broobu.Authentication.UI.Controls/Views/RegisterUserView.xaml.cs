using System;
using Broobu.Authentication.Contract.Domain;
using Broobu.Fx.UI.ValidationRules;
using Wulka.Crypto;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using ValidationResult = System.Windows.Controls.ValidationResult;

namespace Broobu.Authentication.UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegisterUserView
    {
        public RegisterUserView()
        {
            InitializeComponent();
        }

        public static string ID = "RegisterUserView";


        /// <summary>
        /// Unbinds the passwords.
        /// </summary>
        public void UnbindPasswords()
        {
            var it = (UserRegistrationInfo)DataContext;
            if (it.AuthMode == AuthenticationMode.Native)
            {
                if (String.IsNullOrWhiteSpace(EdPassword.Password) || String.IsNullOrWhiteSpace(EdConfirmPassWord.Password))
                {
                    it.AddError("Password cannot be empty.");
                    return;
                }
                if (EdPassword.Password != EdConfirmPassWord.Password)
                {
                    it.AddError("Passwords are not the same.");
                    return;
                }
                it.Password = CryptoEngine.Encrypt(EdPassword.Password);
                it.ConfirmedPassword = CryptoEngine.Encrypt(EdConfirmPassWord.Password);
            }
        }


        
    }
}
