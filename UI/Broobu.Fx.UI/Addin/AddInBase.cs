// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-31-2014
// ***********************************************************************
// <copyright file="AddInBase.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Broobu.Fx.UI.Addin.Interfaces;
using Broobu.Fx.UI.Addin.Utils;
using NLog;
using Wulka.Exceptions;
using Wulka.Utils;

namespace Broobu.Fx.UI.Addin
{
    /// <summary>
    ///     Class AddInBase.
    /// </summary>
    public abstract class AddInBase : MarshalByRefObject, IXProcAddIn, IKeyboardInputSite
    {
        /// <summary>
        ///     The worker thread
        /// </summary>
        private static readonly DispatcherWorkerThread WorkerThread = new DispatcherWorkerThread();

        /// <summary>
        ///     The key MSGS to bubble
        /// </summary>
        private static readonly uint[] KeyMsgsToBubble =
        {
            Win32.WM_KEYDOWN, Win32.WM_KEYUP, Win32.WM_SYSKEYDOWN, Win32.WM_SYSKEYUP,
            Win32.WM_SYSCHAR, Win32.WM_SYSDEADCHAR
        };

        /// <summary>
        ///     The _HWND source
        /// </summary>
        private readonly HwndSource _hwndSource; // child window containing the add-in control

        [Import(typeof (IAddInControl))] public IAddInControl AddinControl;

        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The _host site
        /// </summary>
        private IXProcAddInSite _site; // connection to the host


        /// <summary>
        ///     Initializes a new instance of the <see cref="AddInBase" /> class.
        /// </summary>
        /// <param name="site">The site.</param>
        protected AddInBase()
        {
            /*
            Create a window to host the add-in content. The OS allows a window from one process to be parented
            by a window from another. Essentially, native windows let us stitch UI between the two processes.
            (A WPF element tree is contained within an AppDomain and runs all on a single thread.) 
            We have to run a message loop around this window and help with key forwarding and tabbing into&out. 
        
            Keyboard input handling generally works better if MSGs straight off the Win32 message loop are
            "preprocessed", before passing them to DefWinowProc(). This helps with correct handling of
            various accelerators, in particular with some ActiveX controls (like the one WebBrowser wraps),
            and avoids occasional IME translation mishaps. WPF directly exposes its message loop via the
            ComponentDispatcher.ThreadPreprocessMessage event. When HwndSource owns a top-level window,
            it subscribes itself to ThreadPreprocessMessage and does all the correct routing internally
            (largely via its IKeyboardInputSink implementation). But we need a child window for the add-in.
            The trick is to first initialize the HwndSource as a top-level window, while keeping the window
            invisible, and then immediately convert it to a child one. Fortunately, the native window manager
            supports this well.
            */
            string addinName = AppletName.Replace(".", "");
            Logger.Info("Adding addin {0}", addinName);
            var hwsp = new HwndSourceParameters(addinName) {WindowStyle = 0};
            HwndSource hwndSource = _hwndSource = new HwndSource(hwsp);
            Win32.ConvertToChildWindow(hwndSource.Handle);
            if (hwndSource.CompositionTarget != null)
            {
                hwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;
            }
            hwndSource.SizeToContent = SizeToContent.Manual; // The host will do the sizing, via its HwndHost.


            CompositionHelper.ComposeParts(this, GetType());
            if (AddinControl == null)
            {
                Logger.Error("No AddIn control could be found in the package");
            }
            else
            {
                var control = AddinControl as Control;
                if (control != null)
                {
                    Logger.Info("Adding control [{0}]", control.GetType().Name);
                    hwndSource.RootVisual = control;
                    // Enable tabbing out of the add-in. (It is possible to keep Tab cycle within but let only Ctrl+Tab
                    // move the focus out.)
                    KeyboardNavigation.SetTabNavigation(control, KeyboardNavigationMode.Continue);
                    KeyboardNavigation.SetControlTabNavigation(control, KeyboardNavigationMode.Continue);
                }
                ((IKeyboardInputSink) hwndSource).KeyboardInputSite = this;
                // This message loop hook facilitates "bubbling" unhandled keys to the host. We critically rely
                // on HwndSource having already registered its hook so that this one is invoked last.
                ComponentDispatcher.ThreadPreprocessMessage += ThreadPreprocessMessage;
            }
        }

        public static string AppletName
        {
            get
            {
                return Process
                    .GetCurrentProcess()
                    .ProcessName
                    .ToLower()
                    .Replace(".exe", "");
            }
        }


        /// <summary>
        ///     Unregisters a child keyboard input sink from this site.
        /// </summary>
        void IKeyboardInputSite.Unregister()
        {
        }

        /// <summary>
        ///     Gets the keyboard sink associated with this site.
        /// </summary>
        /// <value>The sink.</value>
        IKeyboardInputSink IKeyboardInputSite.Sink
        {
            get { return _hwndSource; }
        }

        /// <summary>
        ///     Called by a contained component when it has reached its last tab stop and has no further items to tab to.
        /// </summary>
        /// <param name="request">Specifies whether focus should be set to the first or the last tab stop.</param>
        /// <returns>
        ///     If this method returns true, the site has shifted focus to another component. If this method returns false,
        ///     focus is still within the calling component. The component should "wrap around" and set focus to its first
        ///     contained tab stop.
        /// </returns>
        bool IKeyboardInputSite.OnNoMoreTabStops(TraversalRequest request)
        {
            // Tabbing out implies focus change. WM_SETFOCUS (and possibly related messages) needs to be sent
            // synchronously to the add-in's window when the host claims focus. To enable dispatching of this
            // message, the UI thread has to be available. (Same issue as in ThreadPreprocessMessage().)
            return (bool) WorkerThread.Dispatcher.Invoke((DispatcherOperationCallback) (tr =>
                _site.TabOut((TraversalRequest) tr)), request);
        }

        public IXProcAddInSite Site
        {
            get { return _site; }
            set
            {
                _site = value;
                if (_site == null) return;
                Logger.Info("Setting the Addin!");
                _site.SetAddIn(this);
            }
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
            // null means a lease that doesn't expire. 
            // IXProcAddIn.ShutDown() will trigger cleanup and process exit.
            return null;
        }

        /// <summary>
        ///     Threads the preprocess message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="handled">if set to <c>true</c> [handled].</param>
        private void ThreadPreprocessMessage(ref MSG msg, ref bool handled)
        {
            var wm = unchecked((uint) msg.message);
            if (!handled && KeyMsgsToBubble.Contains(wm))
            {
                // Because in its handling of a key the host may want to call into the add-in or may trigger
                // a window message that needs to be dispatched synchronously to the add-in's window, we have
                // to keep the UI thread responsive to window messages. This is accomplished thanks to the 
                // semi-permeable managed blocking that the Dispatcher normally allows to happen in an STA.
                // (For deep background, see http://blogs.msdn.com/cbrumme/archive/2004/02/02/66219.aspx.)
                handled = (bool) WorkerThread.Dispatcher.Invoke((DispatcherOperationCallback) (m =>
                    _site.TranslateAccelerator((MSG) m)), msg);
            }
        }

        /// <summary>
        ///     Called when [window message].
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <param name="handled">if set to <c>true</c> [handled].</param>
        /// <returns>IntPtr.</returns>
        private IntPtr OnWindowMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            _logger.Debug("Received WindowMessage msg:{0} wParam:{1} lParam:{2}", msg, wParam, lParam);
            handled = true;
            return IntPtr.Zero;
        }

        #region IXProcAddIn Members

        // All calls to IXProcAddIn arrive on thread pool threads. Access to the HwndSource and its content has
        // to be on the HwndSource's thread. The easiest way to switch is via the Dispatcher. Unfortunately, 
        // this gets a little awkward to do repeadly and especially when it comes to getting results back. 
        // Alternately, this technique can be used to implement a thread-bound remotable object: 
        // http://shevaspace.blogspot.com/2007/03/aop-style-thread-synchronization.html

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Gets the add in window.
        /// </summary>
        /// <value>The add in window.</value>
        IntPtr IXProcAddIn.AddInWindow
        {
            get { return _hwndSource.Handle; }
        }

        /// <summary>
        ///     Called when [add in attached].
        /// </summary>
        void IXProcAddIn.OnAddInAttached()
        {
            _hwndSource.Dispatcher.BeginInvoke(new Action(() => _logger.Info("Add-in attached to host.")));
        }

        /// <summary>
        ///     Tabs the into.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool IXProcAddIn.TabInto(TraversalRequest request)
        {
            return
                (bool)
                    _hwndSource.Dispatcher.Invoke(
                        (DispatcherOperationCallback)
                            (tr => ((IKeyboardInputSink) _hwndSource).TabInto((TraversalRequest) tr)), request);
        }

        /// <summary>
        ///     Shuts down.
        /// </summary>
        void IXProcAddIn.ShutDown()
        {
            _hwndSource.Dispatcher.Invoke((Action) delegate
            {
                try
                {
                    _logger.Info("Shutting down Add-In [{0}]", AppletName);
                    _hwndSource.Dispatcher.InvokeShutdown(); // This will lead to process exit.
                    _hwndSource.Dispose();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.GetCombinedMessages());
                }
            });
        }

        #endregion
    };
} //namespace