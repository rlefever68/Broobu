using System;
using System.Windows;
using DevExpress.Xpf.Core;

namespace Broobu.Boutique.Hub.UI.Controls.DXSplashScreen
{
    /// <summary>
    /// Interaction logic for HubSplashWindow.xaml
    /// </summary>
    public partial class HubSplashWindow : Window, ISplashScreen
    {
        public HubSplashWindow()
        {
            InitializeComponent();
            this.board.Completed += OnAnimationCompleted;
        }

        #region ISplashScreen
        public void Progress(double value)
        {
            ProgressBar.Value = value;
        }
        public void CloseSplashScreen()
        {
            this.board.Begin(this);
        }
        public void SetProgressState(bool isIndeterminate)
        {
            ProgressBar.IsIndeterminate = isIndeterminate;
        }
        #endregion

        #region Event Handlers
        void OnAnimationCompleted(object sender, EventArgs e)
        {
            this.board.Completed -= OnAnimationCompleted;
            this.Close();
        }
        #endregion
    }
}
