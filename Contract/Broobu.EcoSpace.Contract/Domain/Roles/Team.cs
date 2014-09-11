using System.Runtime.Serialization;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class Team : Organization
    {
        public Team()
        {
            DisplayName = "New Team";
        }

        protected override IDomainObject CreateChild()
        {
            return new Role() { DisplayName = "New Team Role" };
        }

    }
}