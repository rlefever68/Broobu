using Broobu.Boutique.Contract.Agent;
using Broobu.Boutique.Contract.Interfaces;

namespace Broobu.Boutique.Contract
{
    /// <summary>
    /// Exposes methods to create an agent
    /// </summary>
    public static class BoutiquePortal
    {
        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static IBoutiqueAgent Boutique
        {
            get
            {
                return new BoutiqueAgent(null);
            }
        }


       


    }
}