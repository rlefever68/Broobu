using System.Runtime.Serialization;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public sealed class DefaultRoleContainer : RoleContainer
    {
        public new const string ID = "DEFAULT_ROLE_CONTAINER";
        public DefaultRoleContainer()
        {
            Id = ID;
            DisplayName = "Default Roles";
        }
    }
}