using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.TransactionRouter.Contract.Interface;

namespace Pms.TransactionRouter.Contract.Agent
{
    public class TransactionRouterAgentFactory
    {
        public static ITransactionRouterAgent CreateAgent()
        {
            return new TransactionRouterAgent();
        }

    }
}
