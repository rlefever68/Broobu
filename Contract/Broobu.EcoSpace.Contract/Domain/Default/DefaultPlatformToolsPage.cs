using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Menu;

namespace Broobu.EcoSpace.Contract.Domain.Default
{
    [DataContract]
    public class DefaultPlatformToolsPage : Page
    {
        public const string ID = "PAGE_DEFAULT_PLATFORM_TOOLS";
        public DefaultPlatformToolsPage()
        {
            Id = ID;
            DisplayName = "Tools";
        }
    }
}