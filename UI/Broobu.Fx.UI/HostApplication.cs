// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-24-2014
// ***********************************************************************
// <copyright file="HostApplication.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Windows;
using System.Windows.Threading;
using Broobu.Fx.UI.Deamons;
using NLog;
using Wulka.Utils;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Class HostApplication.
    /// </summary>
    public class HostApplication : Application
    {
        /// <summary>
        ///     The _launcher identifier
        /// </summary>
        public static readonly string LauncherId = GuidUtils.NewCleanGuid;

        #region DoEvents Plumbing

        private static readonly DispatcherOperationCallback ExitFrameCallback = ExitFrame;

        /// <summary>
        ///     Processes all UI messages currently in the message queue.
        /// </summary>
        public static void DoEvents()
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
            frame.Continue = false;
            return null;
        }

        #endregion DoEvents Plumbing

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            _logger.Info("Starting Application [{0}]", GetType().Name);
            ComSink.Instance.StartHostDeamon(LauncherId);
            base.OnStartup(e);
        }


        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Application.Exit" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.ExitEventArgs" /> that contains the event data.</param>
        protected override void OnExit(ExitEventArgs e)
        {
            LauncherDeamon.CloseDeamon();
            base.OnExit(e);
        }
    }
}