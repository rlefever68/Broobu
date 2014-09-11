using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Properties;


namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public class MonitorCloudApplet : CloudApplet
    {
        public static string ID = "MONITOR_CLOUD_APPLET";
        public MonitorCloudApplet()
        {
            Id = ID;
            DisplayName = "Inspect Cloud Services";
            Icon = Resources.InspectCloud;
            PublishUrl = "http://www.broobu.com/clickonce/broobu/monitordisco/broobu.monitordisco.ui.application";
        }
    }
}