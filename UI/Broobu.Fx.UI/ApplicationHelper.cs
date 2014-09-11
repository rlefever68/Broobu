using System;
using System.Windows;
using System.Windows.Threading;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;
using NLog;
using Wulka.Domain.Base;
using Wulka.Exceptions;

namespace Broobu.Fx.UI
{
    public static class ApplicationHelper
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static object _o = new object();

        #region DoEvents Plumbing

        private static readonly DispatcherOperationCallback ExitFrameCallback = ExitFrame;

        /// <summary>
        ///     Processes all UI messages currently in the message queue.
        /// </summary>
        public static void DoEvents(this Application app)
        {
            // Create new nested message pump.
            var nestedFrame = new DispatcherFrame();

            // Dispatch a callback to the current message queue, when getting called,
            // this callback will end the nested message loop.
            // note that the priority of this callback should be lower than the that of UI event messages.
            DispatcherOperation exitOperation = Dispatcher
                .CurrentDispatcher
                .BeginInvoke(DispatcherPriority.Background,
                    ExitFrameCallback, nestedFrame);

            // pump the nested message loop, the nested message loop will
            // immediately process the messages left inside the message queue.
            Dispatcher.PushFrame(nestedFrame);

            // If the "exitFrame" callback doesn't get finished, Abort it.
            if (exitOperation.Status != DispatcherOperationStatus.Completed)
            {
                exitOperation.Abort();
            }
        }

        /// <summary>
        ///     Exits the frame.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        private static Object ExitFrame(Object state)
        {
            var frame = state as DispatcherFrame;

            // Exit the nested message loop.
            if (frame != null) frame.Continue = false;
            return null;
        }

        #endregion DoEvents Plumbing

        /// <summary>
        ///     Enables the exception handling.
        /// </summary>
        /// <param name="act">The act.</param>
        public static void EnableExceptionHandling(Action<ExceptionInfo> act = null)
        {
            if (Application.Current != null)
            {
                Application.Current.DispatcherUnhandledException += (s, e) =>
                {
                    if (e != null)
                    {
                        var nfo = new ExceptionInfo {TheException = e.Exception};
                        _logger.Error(nfo.TheException.GetCombinedMessages());
                        e.Handled = true;
                        Messenger.Default.Send(new ExceptionMvvmMsg
                        {
                            Exception = e.Exception
                        });
                        if (act != null)
                            act(nfo);
                    }
                    else
                    {
                        _logger.Error("No event argument in UnhandledException Event.");
                    }
                };
            }
            else
            {
                _logger.Error("There is no Current Application yet.");
            }
        }
    }
}