using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class AuthenticatedRole : Role
    {
        public  const string ID = "AUTH_ACCOUNT_ROLE";
        public AuthenticatedRole()
        {
            Id = ID;
            Icon = Resources.RegisteredAccount;
            DisplayName = "Authenticated Users";
        }
    }
}
