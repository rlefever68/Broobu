using Iris.MonitorSession.Contract.Interfaces;

namespace Iris.MonitorSession.Contract.Agent
{
    public class MonitorSessionAgentFactory
    {
        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        public static IMonitorSessionAgent CreateAgent()
        {
            return new MonitorSessionAgent();
        }
    }
}
