using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Menu;

namespace Broobu.EcoSpace.Contract.Domain
{
    [DataContract]
    public class BrowseWebMenuButton : MenuButton
    {
        public BrowseWebMenuButton()
        {
            AppletId = BrowseWebApplet.ID;
            GroupHeader = "Broobu";
            IsFlowBreak = true;
            DisplayName = "Browse the Web";
            Subtitle = "Surf the web...";
            Title = "Browse";
            Description = "Your embedded browser.";

        }
    }
}