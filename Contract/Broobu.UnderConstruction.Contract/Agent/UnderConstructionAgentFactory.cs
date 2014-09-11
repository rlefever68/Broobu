using Pms.UnderConstruction.Contract.Interfaces;

namespace Pms.UnderConstruction.Contract.Agent
{
    public class UnderConstructionAgentFactory
    {
      
        public static IUnderConstructionAgent CreateAgent()
        {
           return new UnderConstructionAgent();
        }
    }
}
