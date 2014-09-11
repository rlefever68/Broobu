using System.Runtime.Serialization;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public sealed class SystemRolesFolder : RoleFolder
    {
        [DataMember]
        public string SystemId { get; set; }

        public const string ID = "SYSTEM_ROLES_FOLDER";
        public SystemRolesFolder()
        {
            Id = ID;
            DisplayName = "System Roles";
            SystemId = "Jupiter";
        }
    }

}