using Broobu.LATI.Contract.Agent;
using Broobu.LATI.Contract.Interfaces;

namespace Broobu.LATI.Contract
{
    public static class LatiPortal
    {
        public static ICultureAgent Cultures
        {
            get { return new CultureAgent(null); }
        }


        public static ILatiAgent Latis {
            get {
                return new LatiAgent(null);
            }
        }
    }
}
