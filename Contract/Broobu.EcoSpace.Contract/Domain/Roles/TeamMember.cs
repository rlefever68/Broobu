using System.Runtime.Serialization;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class TeamMember : Role
    {


        public TeamMember()
        {
            DisplayName = "New Team Member";
            Icon = Properties.Resources.Guest;
        }
    }
}