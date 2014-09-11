// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.UI
// Author           : ON8RL
// Created          : 12-17-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-17-2013
// ***********************************************************************
// <copyright file="MonitorDiscoPlugin.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Fx.UI;
using Broobu.Fx.UI.Interfaces;

namespace Broobu.MonitorDisco.UI
{
    /// <summary>
    /// Class MonitorDiscoPlugin.
    /// </summary>
    public class MonitorDiscoPlugin :PluginBase
    {
        /// <summary>
        /// Creates the plugin form internal.
        /// </summary>
        /// <returns>IPluginForm.</returns>
        protected override IPluginForm CreatePluginFormInternal()
        {
           // return new MonitorDiscoWindow();
            return new MonitorCloudWindow();
           
        }

    }
}
