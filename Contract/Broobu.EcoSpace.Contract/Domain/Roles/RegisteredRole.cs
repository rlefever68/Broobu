using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    public sealed class RegisteredRole : Role
    {
        public const string ID = "REGISTERED_ACCOUNT_ROLE";
        public RegisteredRole()
        {
            Id = ID;
            Icon = Resources.RegisteredAccount;
            DisplayName = "Registered Users";
        }
    }
}