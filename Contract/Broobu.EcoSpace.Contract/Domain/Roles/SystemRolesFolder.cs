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




        protected override Wulka.Domain.Interfaces.IDomainObject CreateBranch()
        {
            return null;
        }

        protected override Wulka.Domain.Interfaces.IDomainObject CreateChild()
        {
            return null;
        }

        protected override Wulka.Domain.Interfaces.IDomainObject CreateFolder()
        {
            return null;
        }



    }

}