namespace Broobu.Desktop.UI.Controls.Dialogs
{
    public class BoutiqueOptionsDialog
    {
        public static bool Execute()
        {
            var f = new BoutiqueOptionsWindow();
            return (f.ShowDialog()==true);
        }
    }
}
