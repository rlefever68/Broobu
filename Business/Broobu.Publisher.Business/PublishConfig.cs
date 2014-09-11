using System.Configuration;

namespace Broobu.Publisher.Business
{
    internal class PublishConfig
    {
       
        public static string PlatformName = ConfigurationManager.AppSettings["Platform.Name"];
        public static string PlatformMoreInfoUrl = ConfigurationManager.AppSettings["Platform.MoreInfoUrl"];
        public static string PlatformMoreInfoEmail = ConfigurationManager.AppSettings["Platform.MoreInfoEmail"];
    }
}