using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Menu;

namespace Broobu.EcoSpace.Contract.Domain
{
    [DataContract]
    public class LearnMoreMenuButton : MenuButton
    {
        public LearnMoreMenuButton() 
        {
            GroupHeader = "Insoft";
            DisplayName = "Your Cloud App Here!";
            Subtitle = "Your Cloud App Here!";
            Title = "Learn more!";
            Description = "Click here to find out more about Boutique Applets";
            IsFlowBreak = true;
            AppletId =LearnMoreApplet.ID;                
        }
    }
}