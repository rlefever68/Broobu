using System.Threading;
using System.Windows.Threading;

namespace AddIn
{
    /// <summary>
    /// Wrapper for a worker thread that has a Dispatcher running on it. This helps us solve some
    /// re-entrancy and deadlock problems.
    /// </summary>
    public class DispatcherWorkerThread
    {
        public Dispatcher Dispatcher { get; private set; }

        public DispatcherWorkerThread()
        {
            Thread workerThread = new Thread((ThreadStart)delegate
            {
                this.Dispatcher = Dispatcher.CurrentDispatcher;
                Dispatcher.Run();
            });
            workerThread.IsBackground = true;
            workerThread.Name = "Dispatcher worker";
            workerThread.Start();
        }
    };
}