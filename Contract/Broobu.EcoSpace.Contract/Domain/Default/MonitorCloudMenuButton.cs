using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Menu;

namespace Broobu.EcoSpace.Contract.Domain.Default
{
    [DataContract]
    public class MonitorCloudMenuButton : MenuButton
    {
        public const string ID = "BTN_MONTIOR_CLOUD";
        public MonitorCloudMenuButton()
        {
            Id = ID;
            AppletId = MonitorCloudApplet.ID;
            GroupHeader = "Broobu";
            Title = "Cloud Health Monitor";
            Subtitle = "Check platform services' health";
            Description = "The cloud engine closely monitors the availabilty of all services in a Broobu Cloudscape";

        }
    }
}