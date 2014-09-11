using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    [DataContract]
    public class Organization : Role
    {
        public Organization()
        {
            Icon = Properties.Resources.OrganizationRole;
            DisplayName = "New Organization";
        }

        protected override IDomainObject CreateChild()
        {
            return new Team();
        }

    }
}
