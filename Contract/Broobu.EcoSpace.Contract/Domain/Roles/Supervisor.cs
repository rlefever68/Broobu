using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class Supervisor : Role
    {
        protected override Wulka.Domain.Interfaces.IDomainObject CreateChild()
        {
            return new Role() {DisplayName="New Team Member"};
        }
    }
}
