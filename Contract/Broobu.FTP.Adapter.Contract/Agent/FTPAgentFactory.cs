using System;
using Pms.FTP.Adapter.Contract.Interfaces;

namespace Pms.FTP.Adapter.Contract.Agent
{
    public static class FTPAgentFactory
    {
        public enum AgentType
        {
            Default,
            Mock
        } ;

        public static IFTPAgent CreateAgent(AgentType agentType)
        {
            switch (agentType)
            {
                case AgentType.Default:
                    return new FTPAgent();
                    
                case AgentType.Mock:
                    return new FTPMockAgent();

                default:
                    throw new NotSupportedException();
                    
            }
        }
    }
}
