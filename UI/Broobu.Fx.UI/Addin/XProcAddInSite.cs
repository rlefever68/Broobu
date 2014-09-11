// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-31-2014
// ***********************************************************************
// <copyright file="XProcAddInSite.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Runtime.Remoting.Lifetime;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using Broobu.Fx.UI.Addin.Interfaces;
using Broobu.Fx.UI.Addin.Utils;

namespace Broobu.Fx.UI.Addin
{
    /// <summary>
    ///     The AddIn object attaches itself to this "site" object. It is separate from XProcAddInHost because
    ///     it needs to be derived from MBR to be remotable.
    /// </summary>
    internal class XProcAddInSite : MarshalByRefObject, IXProcAddInSite
    {
        /// <summary>
        ///     The _host
        /// </summary>
        private readonly XProcAddInHost _host;

        /// <summary>
        ///     Initializes a new instance of the <see cref="XProcAddInSite" /> class.
        /// </summary>
        /// <param name="host">The host.</param>
        internal XProcAddInSite(XProcAddInHost host)
        {
            _host = host;
        }

        /// <summary>
        ///     Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        ///     An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease" /> used to control the lifetime policy
        ///     for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new
        ///     lifetime service object initialized to the value of the
        ///     <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime" /> property.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="RemotingConfiguration, Infrastructure" />
        /// </PermissionSet>
        public override object InitializeLifetimeService()
        {
            // Set up the host as the sponsor of the lease.
            var lease = (ILease) base.InitializeLifetimeService();
            if (lease != null && lease.CurrentState == LeaseState.Initial)
            {
                //lease.RenewOnCallTime = TimeSpan.FromSeconds(7); //Just for testing
                //lease.InitialLeaseTime = TimeSpan.FromSeconds(7); //
                lease.Register(_host);
            }
            return lease;
        }

        #region IXProcAddInSite implemenentation

        // Note: These calls arrive on thread pool threads. UI work must be done on the UI thread.
        // We switch easily via the Dispatcher.

        /// <summary>
        ///     Gets the host process identifier.
        /// </summary>
        /// <value>The host process identifier.</value>
        public int HostProcessId
        {
            get { return Process.GetCurrentProcess().Id; }
        }

        /// <summary>
        ///     Sets the add in.
        /// </summary>
        /// <param name="addin">The addin.</param>
        public void SetAddIn(IXProcAddIn addin)
        {
            _host.SetAddIn(addin);
        }

        /// <summary>
        ///     Tabs the out.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TabOut(TraversalRequest request)
        {
            return (bool) _host.Dispatcher.Invoke((DispatcherOperationCallback) (tr =>
                _host.MoveFocus((TraversalRequest) tr)), request);
        }

        /// <summary>
        ///     Translates the accelerator.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TranslateAccelerator(MSG msg)
        {
            return (bool) _host.Dispatcher.Invoke((DispatcherOperationCallback) delegate(object m)
            {
                // We delegate key processing to the containing HwndSource, via IKIS. It will see that 
                // a child window ("sink") has focus and will do special routing of the input events using
                // that child window as the forced target. Thus, any element up to the root visual has a 
                // chance to see and handle the events.
                Debug.Assert(((IKeyboardInputSink) _host).HasFocusWithin());
                var hostSink = (IKeyboardInputSink) PresentationSource.FromVisual(_host);

                var m2 = (MSG) m;
                // - IKIS has special rules about which messages are passed to which method.
                // Here we assume the add-in bubbles only raw key messages plus mnemonic keys (Alt+something).
                // - Even though the call has hopped from thread to thread, Keyboard.Modifiers produces
                // correct result here because the input queue and states of the host's and add-in's UI
                // threads are synchronized. (The window manager automatically attaches thread input when
                // a window is parented to a cross-thread one.)
                if (m2.message == Win32.WM_SYSCHAR || m2.message == Win32.WM_SYSDEADCHAR)
                    return hostSink != null && hostSink.OnMnemonic(ref m2, Keyboard.Modifiers);
                return hostSink != null && hostSink.TranslateAccelerator(ref m2, Keyboard.Modifiers);
            }, msg);
        }

        #endregion
    };
}