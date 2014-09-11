// ***********************************************************************
// Assembly         : Broobu.CloudEngine.WinService
// Author           : ON8RL
// Created          : 12-13-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-13-2013
// ***********************************************************************
// <copyright file="CloudEngineHost.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using Broobu.Engine.Contract.Agents;
using Broobu.Engine.Service;
using NLog;


namespace Broobu.CloudEngine.WinService
{
    /// <summary>
    /// Class CloudEngineHost.
    /// </summary>
    public partial class CloudEngineHost : ServiceBase
    {


        private readonly MirrorAgent _mirrors = MirrorAgent.Instance;
        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The _service host
        /// </summary>
        private ServiceHost _serviceHost = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEngineHost"/> class.
        /// </summary>
        public CloudEngineHost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            _logger.Info("Broobu CloudEngine Starting....");
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }
            _serviceHost = new ServiceHost(typeof(Engine.Service.CloudEngine));
            _serviceHost.Open();
            // Iterate through the endpoints contained in the ServiceDescription 
            var sb = new System.Text.StringBuilder(string.Format("Active Service Endpoints:{0}", Environment.NewLine), 128);
            foreach (ServiceEndpoint se in _serviceHost.Description.Endpoints)
            {
                _logger.Info("Endpoint:");
                _logger.Info("\tAddress\t\t: {0}", se.Address);
                _logger.Info("\tBinding\t\t: {0}", se.Binding);
                _logger.Info("\tContract\t: {0}", se.Contract.Name);
                foreach (var behavior in se.Behaviors)
                {
                    _logger.Info("\tBehavior\t: {0}", behavior);
                }
                if (se.Contract.Name == "IMirror")
                {
                    MirrorAgent.Instance.MyAddress = se.Address.Uri.ToString();
                    _mirrors.PropagateMirror(se.Address.Uri.ToString());
                }
                _logger.Info("");
            }
            _logger.Info(Environment.NewLine);
            _logger.Info("***************************************************");
            _logger.Info("*           Broobu Cloud Forming...               *");
            _logger.Info("***************************************************");
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            if (_serviceHost == null) return;
            _serviceHost.Close();
            _serviceHost = null;
        }
    }
}
