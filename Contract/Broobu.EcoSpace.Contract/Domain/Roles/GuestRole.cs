using System.Runtime.Serialization;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class GuestRole : Role
    {
        public GuestRole()
        {
            Id = "GUEST_ROLE";
            Icon = Properties.Resources.Guest;
            DisplayName = "Guest";
        }
    }
}