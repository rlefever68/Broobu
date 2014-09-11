using System.Windows;
using System.Windows.Input;

namespace Broobu.Desktop.UI
{
    /// <summary>
    /// Interaction logic for MobiGuiderSplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
        }


        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }


        public void SetFeedback(string feedback)
        {
            Feedback.Text = feedback;
        }

    }
}
