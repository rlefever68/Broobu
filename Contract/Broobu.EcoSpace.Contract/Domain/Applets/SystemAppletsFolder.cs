using System.Runtime.Serialization;
using Wulka.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public sealed class SystemAppletFolder : AppletDomain
    {
        public static string ID = "SYSTEM_APPLETS_FOLDER";

        public SystemAppletFolder()
        {
            Id = ID;
            DisplayName = "System Applets";
        }
    }
}