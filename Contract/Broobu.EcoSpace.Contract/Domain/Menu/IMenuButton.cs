using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Wulka.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{
    public interface IMenuButton : IMenuItem
    {
        string AppletId { get; set; }
        ICloudApplet Applet { get; }
        string Caption { get; }
        string LaunchUrl { get; }
        bool IsAllowed { get; set; }


        [DataMember]
        string Title { get; set; }

        [DataMember]
        string Content { get; set; }

        [DataMember]
        bool IsFlowBreak { get; set; }

        [DataMember]
        string GroupHeader { get; set; }

        [DataMember]
        string Subtitle { get; set; }

        [DataMember]
        string Description { get; set; }

        
    }
}