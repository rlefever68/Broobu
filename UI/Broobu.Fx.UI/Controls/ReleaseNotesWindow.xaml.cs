using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace Broobu.Fx.UI.Controls
{
    /// <summary>
    ///     Interaction logic for ReleaseNotesWindow.xaml
    /// </summary>
    public partial class ReleaseNotesWindow : Window
    {
        private readonly ICommand _closeWindow;

        public ReleaseNotesWindow()
        {
            InitializeComponent();
            _closeWindow = new DelegateCommand(Close);
            InputBindings.Add(new InputBinding(_closeWindow, new KeyGesture(Key.F12)));
        }


        /// <summary>
        ///     Loads the release notes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        public void LoadReleaseNotes(Stream s)
        {
            TextRange range;
            if (s != null)
            {
                try
                {
                    range = new TextRange(rtReleaseNotes.Document.ContentStart, rtReleaseNotes.Document.ContentEnd);
                    range.Load(s, DataFormats.Text);
                }
                finally
                {
                    s.Close();
                }
            }
        }
    }
}