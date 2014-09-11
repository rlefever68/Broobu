using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.Authentication.Contract;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;

namespace Broobu.ManageEcoSpace.Contract.Domain
{
    [DataContract]
    public class EcoSpaceAccount : Link
    {
        IEcoSpaceDocument EcoSpace 
        { 
            get; set; 
        }
        IAccount Account 
        { 
            get; set; 
        }

        protected override Type GetSourceFactoryType()
        {
            return typeof(EcoSpacePortal);
        }


        protected override Type GetTargetFactoryType()
        {
            return typeof(AuthenticationPortal);
        }
    }
}
