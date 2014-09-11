// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-31-2014
// ***********************************************************************
// <copyright file="XProcAddInHost.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using Broobu.Fx.UI.Addin.Interfaces;
using Broobu.Fx.UI.Addin.Utils;
using NLog;

namespace Broobu.Fx.UI.Addin
{
    /// <summary>
    ///     Class XProcAddInHost.
    /// </summary>
    public class XProcAddInHost : HwndHost, IKeyboardInputSink, ISponsor
    {
        /// <summary>
        ///     The _addin counter
        /// </summary>
        private static int _addinCounter;

        /// <summary>
        ///     The worker thread
        /// </summary>
        private static readonly DispatcherWorkerThread WorkerThread = new DispatcherWorkerThread();

        /// <summary>
        ///     The _addin available event
        /// </summary>
        private readonly ManualResetEvent _addinAvailableEvent = new ManualResetEvent(false);


        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The _addin
        /// </summary>
        private IXProcAddIn _addin;

        /// <summary>
        ///     Called when one of the mnemonics (access keys) for this sink is invoked.
        /// </summary>
        /// <param name="msg">
        ///     The message for the mnemonic and associated data. Do not modify this message structure. It is passed
        ///     by reference for performance reasons only.
        /// </param>
        /// <param name="modifiers">Modifier keys.</param>
        /// <returns>true if the message was handled; otherwise, false.</returns>
        bool IKeyboardInputSink.OnMnemonic(ref MSG msg, ModifierKeys modifiers)
        {
            //TODO: Optionally, forward mnemonics "down" to the add-in's HwndSource (via IKIS).
            // This would look much like TranslateAccelerator but going in the opposite direction.
            return false;
        }

        /// <summary>
        ///     Sets focus on either the first tab stop or the last tab stop of the sink.
        /// </summary>
        /// <param name="request">Specifies whether focus should be set to the first or the last tab stop.</param>
        /// <returns>true if the focus has been set as requested; false, if there are no tab stops.</returns>
        bool IKeyboardInputSink.TabInto(TraversalRequest request)
        {
            // Same problem as in AddIn.IKeyboardInputSite.OnNoMoreTabStops(): The UI threads deadlock because
            // of IPC's hard blocking and because focus change entails sending window messages. 
            // Workaround is to do the call through a worker thread while this one remains responsive to 
            // window messages (thanks to the DispatcherSynchonizationContext).
            return
                (bool)
                    WorkerThread.Dispatcher.Invoke(
                        (DispatcherOperationCallback)
                            delegate(object tr) { return _addin.TabInto((TraversalRequest) tr); }, request);
        }

        /// <summary>
        ///     Requests a sponsoring client to renew the lease for the specified object.
        /// </summary>
        /// <param name="lease">The lifetime lease of the object that requires lease renewal.</param>
        /// <returns>The additional lease time for the specified object.</returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="Infrastructure" />
        /// </PermissionSet>
        TimeSpan ISponsor.Renewal(ILease lease)
        {
            return Handle == IntPtr.Zero ? TimeSpan.Zero : lease.RenewOnCallTime;
        }


        /// <summary>
        ///     Occurs when [add in available asynchronous].
        /// </summary>
        public event EventHandler AddInAvailableAsync;

        /// <summary>
        ///     Sets the add in.
        /// </summary>
        /// <param name="addin">The addin.</param>
        internal void SetAddIn(IXProcAddIn addin)
        {
            _addin = addin;
            _addinAvailableEvent.Set();
            if (AddInAvailableAsync != null)
                AddInAvailableAsync(this, null);
        }

        /// <summary>
        ///     When overridden in a derived class, creates the window to be hosted.
        /// </summary>
        /// <param name="hwndParent">The window handle of the parent window.</param>
        /// <returns>The handle to the child Win32 window to create.</returns>
        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            _addinAvailableEvent.WaitOne();

            IntPtr addinWindow = _addin.AddInWindow;
            Win32.SetParent(addinWindow, hwndParent.Handle);

            Action onAttached = _addin.OnAddInAttached;
            onAttached.BeginInvoke(null, null);

            return new HandleRef(this, addinWindow);
        }

        /// <summary>
        ///     When overridden in a derived class, destroys the hosted window.
        /// </summary>
        /// <param name="hwnd">A structure that contains the window handle.</param>
        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            _logger.Info("Destroying window core for Hwnd {0}", hwnd.Handle);
            _addin.ShutDown();
        }

        /// <summary>
        ///     Called when the hosted window's position changes.
        /// </summary>
        /// <param name="rcBoundingBox">The window's position.</param>
        protected override void OnWindowPositionChanged(Rect rcBoundingBox)
        {
            Win32.SetWindowPos(Handle, IntPtr.Zero,
                (int) rcBoundingBox.X,
                (int) rcBoundingBox.Y,
                (int) rcBoundingBox.Width,
                (int) rcBoundingBox.Height,
                Win32.SWP_ASYNCWINDOWPOS
                | Win32.SWP_NOZORDER
                | Win32.SWP_NOACTIVATE);
        }
    };
}