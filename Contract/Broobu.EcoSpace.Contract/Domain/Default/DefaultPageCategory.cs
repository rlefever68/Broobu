using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Wulka.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Default
{
    [DataContract]
    public sealed class PlatformPageCategory : PageCategory
    {
        public const string ID = "PLATFORM_PAGE_CATEGORY";
        public PlatformPageCategory()
        {
            Id = ID;
            DisplayName = "Platform";
        }
    }
}