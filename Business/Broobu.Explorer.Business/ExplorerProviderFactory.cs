using Iris.Explorer.Business.Interfaces;

namespace Iris.Explorer.Business
{
    public class ExplorerProviderFactory
    {
        public class Key
        {
            public const string Instance = "Instance";
            public const string Mock = "Mock";
        }

        public static IExplorerProvider CreateProvider(string key)
        {
            switch (key)
            {
                case Key.Instance:
                    return new ExplorerProvider();
                case Key.Mock:
                default:
                    return new ExplorerMockProvider();
            }
        }
    }
}
