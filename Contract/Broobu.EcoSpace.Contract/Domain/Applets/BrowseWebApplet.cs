using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public class BrowseWebApplet : CloudApplet
    {
        public static string ID = "CA_BROWSE";
        public BrowseWebApplet()
        {
            Id = ID;
            DisplayName = "Browse the Web";
            Icon = Resources.InspectCloud;
            PublishUrl = "http://www.broobu.com/clickonce/broobu/browseweb/broobu.browseweb.ui.application";
        }
    }
}