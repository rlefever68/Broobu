// ***********************************************************************
// Assembly         : Iris.WinAuthentication.Service
// Author           : ON8RL
// Created          : 12-02-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-02-2013
// ***********************************************************************
// <copyright file="WinAuthenticationServiceHostFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using Iris.Fx.Configuration;
using Iris.Fx.Networking.Wcf;


namespace Iris.WinAuthentication.Service
{
    /// <summary>
    /// Class WinAuthenticationServiceHostFactory.
    /// </summary>
    public class WinAuthenticationServiceHostFactory : ServiceHostFactory
    {

        /// <summary>
        /// Creates the service host.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <returns>ServiceHost.</returns>
        protected override ServiceHost CreateServiceHost(Type t, Uri[] baseAddresses)
        {
            var serviceHost = new ServiceHost(t, baseAddresses);

            serviceHost.MakeAnnouncingService();            

            serviceHost.AddServiceEndpoint("Iris.WinAuthentication.Contract.Interfaces.IWinAuthentication",
                BindingFactory.CreateBindingFromKey(BindingFactory.Key.WsWinHttpBinding), "") ;

            return serviceHost;
        }
    }
}
