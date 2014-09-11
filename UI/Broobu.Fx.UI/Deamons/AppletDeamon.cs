// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-24-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-28-2014
// ***********************************************************************
// <copyright file="AppletDeamon.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ServiceModel;
using Broobu.Fx.UI.Interfaces;
using Broobu.Fx.UI.Verbs;
using Wulka.Core;

namespace Broobu.Fx.UI.Deamons
{
    /// <summary>
    ///     Class AppletDeamon.
    /// </summary>
    public class AppletDeamon : ServiceHost, IPlugin
    {
        /// <summary>
        ///     Delegate ProcessVerbEvent
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProcessVerbEventArgs" /> instance containing the event data.</param>
        public delegate void ProcessVerbEvent(object sender, ProcessVerbEventArgs e);

        /// <summary>
        ///     Delegate SetContextEvent
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SetContextEventArgs" /> instance containing the event data.</param>
        public delegate void SetContextEvent(object sender, SetContextEventArgs e);

        /// <summary>
        ///     Delegate TerminateEvent
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        public delegate void TerminateEvent(object sender, EventArgs e);

        /// <summary>
        ///     The _applet deamon
        /// </summary>
        private static AppletDeamon _appletDeamon;


        /// <summary>
        ///     Initializes a new instance of the <see cref="AppletDeamon" /> class.
        /// </summary>
        public AppletDeamon()
            : base(typeof (AppletDeamon))
        {
        }

        /// <summary>
        ///     Terminates this instance.
        /// </summary>
        public void Terminate()
        {
            if (OnTerminate != null)
            {
                OnTerminate(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Processes the verb.
        /// </summary>
        /// <param name="verbInfo">The verb information.</param>
        public void ProcessVerb(VerbInfo verbInfo)
        {
            if (OnProcessVerb != null)
            {
                OnProcessVerb(this, new ProcessVerbEventArgs {VerbInfo = verbInfo});
            }
        }

        /// <summary>
        ///     Sends the shell context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void SetContext(WulkaContext context)
        {
            if (OnSetContext != null)
            {
                OnSetContext(this, new SetContextEventArgs {Context = context});
            }
        }

        /// <summary>
        ///     Occurs when [terminate received].
        /// </summary>
        public static event TerminateEvent OnTerminate;

        /// <summary>
        ///     Occurs when [process verb received].
        /// </summary>
        public static event ProcessVerbEvent OnProcessVerb;

        /// <summary>
        ///     Occurs when [send shell context received].
        /// </summary>
        public static event SetContextEvent OnSetContext;

        /// <summary>
        ///     Opens the specified applet address.
        /// </summary>
        /// <param name="appletAddress">The applet address.</param>
        internal static void Open(string appletAddress)
        {
            _appletDeamon = new AppletDeamon();
            var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            _appletDeamon.AddServiceEndpoint(typeof (IPlugin), binding, appletAddress);
            _appletDeamon.Open();
        }


        /// <summary>
        ///     Closes the deamon.
        /// </summary>
        internal static void CloseDeamon()
        {
            _appletDeamon.Close();
        }
    }
}