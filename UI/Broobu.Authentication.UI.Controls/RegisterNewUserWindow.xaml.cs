using System;
using Broobu.Authentication.Contract;
using Broobu.Authentication.Contract.Domain;
using Broobu.Fx.UI.Dialogs;
using Iris.Fx.Domain;

namespace Broobu.Authentication.UI.Controls
{
    /// <summary>
    /// Interaction logic for RegisterNewUserWindow.xaml
    /// </summary>
    public partial class RegisterNewUserWindow 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNewUserWindow"/> class.
        /// </summary>
        public RegisterNewUserWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            vwRegisterNewUser.TxtError.Text = "";
            bool valid = vwRegisterNewUser.Validate();
            var it = (UserRegistrationInfo)DataContext;
            if (valid)
            {
                //Check UserName for duplicate
                var result = AuthenticationPortal
                    .Authentication
                    .UserNameExists(it.UserName);
                if (!result.Id)
                {
                    vwRegisterNewUser.UnbindPasswords();
                    
                    it.UserName = vwRegisterNewUser.EdEmailAddr.Text;
                    it.Email = it.UserName;
                    if (!it.HasErrors)
                    {
                        PleaseWaitDialog.Show("Registering New User: {0} {1}.", it.FirstName, it.LastName);
                        AuthenticationPortal
                            .Authentication
                            .RegisterNewUserAsync(it, RegisterNewUserCompleted);
                    }
                }
                else
                {
                    vwRegisterNewUser.TxtError.Text = "User name is already in use!";
                }
                
            }
            
        }


        /// <summary>
        /// Registers the new user completed.
        /// </summary>
        /// <param name="item">The item.</param>
        private void RegisterNewUserCompleted(UserRegistrationInfo item)
        {
            PleaseWaitDialog.Close();
            DataContext = item;
            DialogResult = !item.HasErrors;
            if (Convert.ToBoolean(DialogResult))
                Close();
        }

        internal IrisAuthRequest GetAuthRequest()
        {
            var it = (UserRegistrationInfo)DataContext;
            return new IrisAuthRequest() { UserName = it.UserName, Password = it.Password };
        }
    }
}
