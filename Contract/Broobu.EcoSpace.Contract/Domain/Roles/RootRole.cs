using System.Reflection;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class RootRole : Role
    {
        public const string ID = "CLOUDSCAPE_ROOT";
        public RootRole()
        {
            Id = ID;
            DisplayName = "Root";
            Icon = Resources.RootRole;
        }
    }
}