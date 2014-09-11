using System.Windows;
using System.Windows.Forms;
using System.Windows.Markup;
using UserControl = System.Windows.Controls.UserControl;

namespace Broobu.Fx.UI.UserControls
{
    /// <summary>
    ///     This Control will display a textbox and browse button and can be used to select a file to be opened or saved, or to
    ///     select a folder.
    ///     Use the Type property to choose the desired effect. In case of OpenFile or SaveAs, the Filter property can be used
    ///     to set a filter on the file type.
    /// </summary>
    [ContentProperty("Path")]
    public partial class FilePicker : UserControl
    {
        public enum PickerType
        {
            SaveAs,
            OpenFile,
            FolderBrowser
        }

        public static readonly DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof (string),
            typeof (FilePicker));

        public FilePicker()
        {
            InitializeComponent();
            Type = PickerType.FolderBrowser;
        }

        /// <summary>
        ///     Type of picker
        /// </summary>
        public PickerType Type { get; set; }

        /// <summary>
        ///     In case of OpenFile/SaveAs, the filter can be used to set a file type filter.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        ///     Selected file path or folder path.
        /// </summary>
        public string Path
        {
            get { return (string) GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Type)
            {
                case PickerType.FolderBrowser:
                {
                    var dialog = new FolderBrowserDialog();

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Path = dialog.SelectedPath;
                    }
                    break;
                }
                case PickerType.SaveAs:
                {
                    var saveFileDialog = new SaveFileDialog {Filter = Filter}; //

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Path = saveFileDialog.FileName;
                    }
                    break;
                }
                case PickerType.OpenFile:
                {
                    var openFileDialog = new OpenFileDialog {Filter = Filter}; //"XML|*.xml"

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Path = openFileDialog.FileName;
                    }
                    break;
                }
            }
        }
    }
}