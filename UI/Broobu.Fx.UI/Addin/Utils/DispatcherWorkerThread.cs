using System.Threading;
using System.Windows.Threading;

namespace Broobu.Fx.UI.Addin.Utils
{
    /// <summary>
    ///     Wrapper for a worker thread that has a Dispatcher running on it. This helps us solve some
    ///     re-entrancy and deadlock problems.
    /// </summary>
    public class DispatcherWorkerThread
    {
        public DispatcherWorkerThread()
        {
            var workerThread = new Thread((ThreadStart) delegate
            {
                Dispatcher = Dispatcher.CurrentDispatcher;
                Dispatcher.Run();
            });
            workerThread.IsBackground = true;
            workerThread.Name = "Dispatcher worker";
            workerThread.Start();
        }

        public Dispatcher Dispatcher { get; private set; }
    };
}