using Broobu.ManageTaxo.Contract.Agent;
using Broobu.ManageTaxo.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.ManageTaxo.Contract
{
    public class ManageTaxoPortal
    {
        public static IManageTaxoAgent Agent
        {
            get { return new ManageTaxoAgent();}
        }
    }
}
