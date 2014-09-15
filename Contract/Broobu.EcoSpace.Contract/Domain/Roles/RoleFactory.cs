using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    public class RoleFactory
    {

        public static Team CreateTeam()
        {
            var res = new Team();
            {
                var sv = new Supervisor();
                res.AddPart(sv);
            }
            return res;
        }

    }
}
