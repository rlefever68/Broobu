using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Menu;

namespace Broobu.EcoSpace.Contract.Domain.Default
{
    [DataContract]
    public class ManageCloudSpaceMenuButton : MenuButton
    {
        public string ID = "BTN_MNG_CLOUDSPACE";
        public ManageCloudSpaceMenuButton()
        {
            Id = ID;
            AppletId = ManageCloudApplet.ID;
            GroupHeader = "Broobu";
            Title = "Manage Ecospace";
            Subtitle = "Modify an Ecospace";
            Description = "A Broobu Ecospace is self-contained workspace in which stakeholders can define their own Broobu platform";
        }
    }
}