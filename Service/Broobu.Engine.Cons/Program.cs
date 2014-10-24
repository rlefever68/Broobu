// ***********************************************************************
// Assembly         : BECons
// Author           : Rafael Lefever
// Created          : 10-21-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 10-23-2014
// ***********************************************************************
// <copyright file="Program.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ServiceModel;
using NLog;

namespace Broobu.Engine.Cons
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {


        private static ServiceHost _engine = null;

        /// <summary>
        /// The _logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The _service host
        /// </summary>
        



        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            EngineRunner.Run(args);
        }

    


        /// <summary>
        /// Starts the engine.
        /// </summary>
        private static void StartEngine()
        {
            Logger.Info("Broobu Cloud Engine Console Starting....");
            if (_engine != null)
            {
                _engine.Close();
            }
            _engine = new ServiceHost(typeof(Service.CloudEngine));
            _engine.Open();
            // Iterate through the endpoints contained in the ServiceDescription 
            Logger.Info("Active Service Endpoints:");
            foreach (var se in _engine.Description.Endpoints)
            {
                Logger.Info("Endpoint:");
                Logger.Info("Address\t\t: {0}", se.Address);
                Logger.Info("Binding\t\t: {0}", se.Binding);
                Logger.Info("Contract\t: {0}", se.Contract.Name);
                foreach (var behavior in se.Behaviors)
                {
                    Logger.Info("Behavior\t: {0}", behavior);
                }
                Logger.Info("");
            }
            Logger.Info(Environment.NewLine);
            Logger.Info("***************************************************");
            Logger.Info("*           Broobu Local Cloud Forming...         *");
            Logger.Info("***************************************************");
            Logger.Info(Environment.NewLine);
            Logger.Info(Environment.NewLine);
            Logger.Info(Environment.NewLine);
            Logger.Info(Environment.NewLine);

        }


    }
}
