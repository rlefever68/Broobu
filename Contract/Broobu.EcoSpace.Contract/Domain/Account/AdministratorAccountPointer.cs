using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Account
{
    [DataContract]
    public class AdministratorAccountPointer : EcoSpaceMembership
    {
        public AdministratorAccountPointer()
        {
            TargetId = "ACCOUNT_ADMINISTRATOR";
            DisplayName = "Administrator";
            Icon = Resources.RootRole;
        }
    }
}