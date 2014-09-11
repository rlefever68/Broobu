// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 05-04-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-15-2014
// ***********************************************************************
// <copyright file="PluginHost.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Broobu.Fx.UI.Interfaces;
using Broobu.Fx.UI.Verbs;
using Wulka.Core;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Class PluginHost.
    /// </summary>
    public abstract class AppletHost : IPluginHost
    {
        /// <summary>
        ///     Delegate NoArgsDelegate
        /// </summary>
        public delegate void NoArgsDelegate();

        /// <summary>
        ///     The _current
        /// </summary>
        private static IPluginHost _current;

        /// <summary>
        ///     The _executable
        /// </summary>
        private static string _executable;

        /// <summary>
        ///     The _plugins
        /// </summary>
        private readonly Dictionary<object, IPlugin> _plugins = new Dictionary<object, IPlugin>();

        /// <summary>
        ///     The _shell context
        /// </summary>
        public readonly WulkaContext _shellContext = WulkaContext.Current;

        private string _appletName;

        #region IPluginHost Members

        /// <summary>
        ///     Unloads the plugin.
        /// </summary>
        /// <param name="Id">The id.</param>
        public void UnloadPlugin(string Id)
        {
        }

        #endregion

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        protected AppletHost()
        {
            _current = this;
        }

        /// <summary>
        ///     Gets or sets the launcher identifier.
        /// </summary>
        /// <value>The launcher identifier.</value>
        public string LauncherId { get; set; }

        /// <summary>
        ///     Gets the current.
        /// </summary>
        /// <value>The current.</value>
        public static IPluginHost Current
        {
            get { return _current; }
        }


        /// <summary>
        ///     Returns the .
        /// </summary>
        /// <value>The local applet dir.</value>
        protected string LocalAppletFolder
        {
            get { return String.Format("{0}\\{1}", PathUtils.PersonalDir(), "applets"); }
        }

        /// <summary>
        ///     Executes the applet.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="mode">The mode.</param>
        public void Broadcast(VerbInfo verbInfo)
        {
            //DeamonHelper.BroadCast(verbInfo);
        }


        /// <summary>
        ///     Gets the shell context.
        /// </summary>
        /// <returns>WulkaContext.</returns>
        public WulkaContext GetShellContext()
        {
            return _shellContext;
        }
    }
}