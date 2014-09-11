using System;
using Pms.ManageAccount.Contract.Interfaces;

namespace Pms.ManageAccount.Contract.Agent
{
    public class ManageAccountAgentFactory
    {
        public static IManageAccountAgent CreateAgent()
        {
            return new ManageAccountAgent();
        }
    }
}
