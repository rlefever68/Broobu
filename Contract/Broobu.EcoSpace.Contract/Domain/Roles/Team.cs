using System.Linq;
using System.Runtime.Serialization;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class Team : Role
    {
        public Team()
        {
            DisplayName = "New Team";
            Icon = Properties.Resources.TeamRole;
        }




        public Supervisor Supervisor
        {
            get
            {
                return Parts.OfType<Supervisor>().Any() 
                    ? Parts.OfType<Supervisor>().First() 
                    : null;
            }
        }

        protected override IDomainObject CreateChild()
        {
            return new TeamMember();
        }


        protected override IDomainObject CreateFolder()
        {
            return RoleFactory.CreateTeam();
        }

    }
}