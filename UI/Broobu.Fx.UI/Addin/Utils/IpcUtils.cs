// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-31-2014
// ***********************************************************************
// <copyright file="IpcUtils.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization.Formatters;

namespace Broobu.Fx.UI.Addin.Utils
{
    /// <summary>
    ///     Class IpcUtils.
    /// </summary>
    public static class IpcUtils
    {
        /// <summary>
        ///     Registers the server channel.
        /// </summary>
        /// <param name="baseServerName">Name of the base server.</param>
        /// <returns>IpcServerChannel.</returns>
        public static IpcServerChannel RegisterServerChannel(string baseServerName)
        {
            var provider = new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full};
            string channelName = baseServerName + "-" + Process.GetCurrentProcess().Id;
            var channel = new IpcServerChannel(null, channelName, provider);
            ChannelServices.RegisterChannel(channel, false);
            return channel;
        }
    };
}