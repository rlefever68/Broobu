using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Account
{
    [DataContract]
    public class GuestAccountPointer : EcoSpaceMembership
    {
        public GuestAccountPointer()
        {
            DisplayName = "Guest";
            TargetId = "ACCOUNT_GUEST";
            Icon = Resources.Guest;
        }
    }
}