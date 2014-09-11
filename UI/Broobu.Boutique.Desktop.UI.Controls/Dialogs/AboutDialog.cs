namespace Broobu.Desktop.UI.Controls.Dialogs
{
    public class AboutDialog
    {
        public static bool Execute()
        {
            var f = new AboutWindow();
            return (f.ShowDialog() == true);
        }
    }
}
