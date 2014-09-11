// ***********************************************************************
// Assembly         : Broobu.Authentication.Service
// Author           : ON8RL
// Created          : 12-02-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-02-2013
// ***********************************************************************
// <copyright file="AuthenticationServiceHostFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using Broobu.Authentication.Business;
using Broobu.Authentication.Business.Providers;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Networking.Wcf;
using NLog;


namespace Broobu.Authentication.Service
{
    /// <summary>
    /// Class AuthenticationServiceHostFactory.
    /// </summary>
    public class AuthenticationServiceHostFactory : ServiceHostFactory
    {


        private Logger _log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creates the service host.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <returns>ServiceHost.</returns>
        protected override ServiceHost CreateServiceHost(Type t, Uri[] baseAddresses)
        {
            var serviceHost = new ServiceHost(t, baseAddresses);
            
            serviceHost.PrintHostInfo();
            
            var bnd = BindingFactory.CreateBindingFromKey(BindingFactory.Key.CustomValidationBasicHttpBindingTransportAndMessage);
            serviceHost.AddServiceEndpoint(typeof(IAuthentication), bnd, "");

            var scb = new ServiceCredentials();
            scb.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            scb.UserNameAuthentication.CustomUserNamePasswordValidator = new Authentications();
            scb.ServiceCertificate.SetCertificate(CertificateHelper.GetStoreLocation(),
                CertificateHelper.GetStoreName(), 
                X509FindType.FindBySubjectName, 
                CertificateHelper.GetCertificateSubject());

            serviceHost.Description.Behaviors.Add(scb);
            
            serviceHost.MakeAnnouncingService();
            
            serviceHost.PrintListeningEndpoints();
            
            return serviceHost;
        }
    }
}



