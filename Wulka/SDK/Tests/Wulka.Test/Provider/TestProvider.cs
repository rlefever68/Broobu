using Iris.Fx.Test.Interfaces;

namespace Iris.Fx.Test.Provider
{
    public class TestProvider
    {
        public static IProviderTest Provider
        {
            get
            {
                return new TestProviderWorker();
            }
        }
    }
}
