using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.SimpleDb.Adapter.Interfaces;

namespace Iris.SimpleDb.Adapter
{
    public static class SimpleDbAgentFactory
    {
        public static ISimpleDbAgent CreateAgent()
        {
            return new SimpleDbAgent();
        }
    }
}
