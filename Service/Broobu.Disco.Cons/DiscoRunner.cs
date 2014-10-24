// ***********************************************************************
// Assembly         : Broobu.Disco.Cons
// Author           : Rafael Lefever
// Created          : 10-24-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 10-24-2014
// ***********************************************************************
// <copyright file="DiscoRunner.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ServiceModel;
using Broobu.Disco.Service;
using Broobu.MonitorDisco.Service;
using NLog;
using Wulka.Exceptions;
using Wulka.Networking.Wcf;

namespace Broobu.Disco.Cons
{
    /// <summary>
    /// Class DiscoRunner.
    /// </summary>
    public class DiscoRunner
    {

        /// <summary>
        /// The _logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The _disco
        /// </summary>
        private static ServiceHost _disco = null;
        /// <summary>
        /// Gets the disco.
        /// </summary>
        /// <value>The disco.</value>
        private static ServiceHost Disco
        {
            get
            {
                return _disco
                       ?? (_disco = SentryHostFactory.CreateAnnouncingHost(typeof(DiscoSentry),
                           new[] { new Uri(ConfigurationHelper.DiscoUrl) }));
            }
        }
        /// <summary>
        /// The _monitor
        /// </summary>
        private static ServiceHost _monitor = null;
        /// <summary>
        /// The _cloud contract
        /// </summary>
        private static ServiceHost _cloudContract;

        /// <summary>
        /// Gets the monitor.
        /// </summary>
        /// <value>The monitor.</value>
        private static ServiceHost Monitor
        {
            get
            {
                return _monitor
                       ?? (_monitor = SentryHostFactory.CreateAnnouncingHost(typeof(MonitorDiscoSentry),
                           new[] { new Uri(ConfigurationHelper.MonitorUrl) }));
            }
        }


        /// <summary>
        /// Gets the cloud contract.
        /// </summary>
        /// <value>The cloud contract.</value>
        private static ServiceHost CloudContract
        {
            get
            {
                return _cloudContract
                    ?? (_cloudContract = SentryHostFactory.CreateAnnouncingHost(typeof(CloudContractSentry),

                    new[] { new Uri(ConfigurationHelper.CloudContractUrl) }));
            }
        }





        /// <summary>
        /// Starts the monitor disco.
        /// </summary>
        private static void StartMonitor()
        {
            try
            {
                Logger.Warn(">>>>>>> Starting Monitor Service <<<<<");
                Monitor.Open();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                throw;
            }
        }

        /// <summary>
        /// Starts the disco.
        /// </summary>
        private static void StartDisco()
        {
            try
            {
                Logger.Warn(">>>>>>> Starting Disco Service <<<<<");
                Disco.Open();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                throw;
            }
        }





        /// <summary>
        /// Stops the cloud contract.
        /// </summary>
        private static void StopCloudContract()
        {
            Logger.Warn(">>>>>>> Terminating CloudContract Service <<<<<");
            CloudContract.Close();
        }

        /// <summary>
        /// Stops the disco.
        /// </summary>
        private static void StopDisco()
        {
            Logger.Warn(">>>>>>> Terminating Disco Service <<<<<");
            Disco.Close();
        }

        /// <summary>
        /// Stops the monitor.
        /// </summary>
        private static void StopMonitor()
        {
            Logger.Warn(">>>>>>> Terminating Monitor Service <<<<<");
            Monitor.Close();
        }

        /// <summary>
        /// Starts the cloud contract.
        /// </summary>
        static void StartCloudContract()
        {
            try
            {
                Logger.Warn(">>>>>>> Starting CloudContract Service <<<<<");
                CloudContract.Open();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                throw;
            }
        }



        /// <summary>
        /// Runs the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Run(string[] args)
        {
            StartCloudContract();
            StartDisco();
            StartMonitor();
        }

        public static void Terminate()
        {
            StopMonitor();
            StopDisco();
            StopCloudContract();
        }
    }
}
