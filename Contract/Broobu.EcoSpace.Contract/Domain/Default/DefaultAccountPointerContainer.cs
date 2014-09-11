using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Account;

namespace Broobu.EcoSpace.Contract.Domain.Default
{
    [DataContract]
    public sealed class DefaultAccountPointerContainer : AccountPointerContainer
    {
        public DefaultAccountPointerContainer()
        {
            AddPart(new SystemAccountsFolder());
            AddPart(new AccountPointerFolder() { DisplayName = "User Accounts" });
        }
    }
}
