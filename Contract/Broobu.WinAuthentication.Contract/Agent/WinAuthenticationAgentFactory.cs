using Iris.WinAuthentication.Contract.Interfaces;

namespace Iris.WinAuthentication.Contract.Agent
{
    public class WinAuthenticationAgentFactory
    {

        


        public static IWinAuthenticationAgent CreateAgent()
        {
            return new WinAuthenticationAgent();
        }
    }
}
