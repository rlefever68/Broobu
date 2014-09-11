using Iris.Explorer.Contract.Interfaces;

namespace Iris.Explorer.Contract.Agent
{
    public class ExplorerAgentFactory
    {
        public class Key
        {
            public const string Instance    = "Instance";
            public const string Mock        = "Mock";
        }

        public static IExplorerAgent CreateAgent(string key)
        {
            switch (key)
            {
                case Key.Instance:
                    return new ExplorerAgent();
                case Key.Mock:
                default:
                    return new ExplorerMockAgent();
            }
        }

        public static IExplorer2Agent CreateAgent2(string key)
        {
            switch (key)
            {
                case Key.Instance:
                    return new Explorer2Agent();
                case Key.Mock:
                default:
                    return new Explorer2MockAgent();
            }
        }


    }
}
