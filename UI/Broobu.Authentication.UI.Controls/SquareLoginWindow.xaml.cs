using System.Windows;
using Iris.Fx.Crypto;
using Iris.Fx.Domain;

namespace Broobu.Authentication.UI.Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SquareLoginWindow : ILoginWindow
    {
        public SquareLoginWindow()
        {
            InitializeComponent();
            Request = new IrisAuthRequest();
        }


        private IrisAuthRequest _request;
        public IrisAuthRequest Request
        {
            get
            {
                return _request;
            }
            set
            {
                _request = value;
                DataContext = _request;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var ss = new IrisSession() 
            { 
                Username = EdUserName.Text, 
                AuthenticationMode = AuthenticationMode.Native,
                AccountId = EdUserName.Text
            };
            Request = RegisterNewUserDialog.Execute(ss);
            EdPwd.Password = CryptoEngine.Decrypt(Request.Password);
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EdUserName.Text))
            {
                Request.Password = CryptoEngine.Encrypt(EdPwd.Password);
                Request.UserName = EdUserName.Text;
                DialogResult = true;
            }
            
        }


    }
}
