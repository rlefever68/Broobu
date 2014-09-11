using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public class LearnMoreApplet : CloudApplet
    {
        public LearnMoreApplet()
        {
            Id = ID;
            DisplayName = "Learn More";
            Icon = Resources.Cool;
            PublishUrl="http://www.broobu.com/clickonce/broobu/underconstruction/broobu.underconstruction.ui.application";
        }

        public static string ID = "CA_LEARNMORE";
    }


   
}