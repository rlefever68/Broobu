// ***********************************************************************
// Assembly         : Broobu.Engine.Service
// Author           : Rafael Lefever
// Created          : 12-25-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-26-2013
// ***********************************************************************
// <copyright file="EngineMirrors.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using Broobu.Engine.Contract.Domain;
using Broobu.Engine.Contract.Interfaces;
using NLog;

namespace Broobu.Engine.Contract.Agents
{
    /// <summary>
    /// Class EngineMirrors.
    /// </summary>
    public class MirrorAgent
    {

        /// <summary>
        /// The mirrors
        /// </summary>
        private readonly List<string> _mirrors = new List<string>(EngineConfiguration.MirrorNodes);

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetLogger("MirrorAgent");

        /// <summary>
        /// The _my address
        /// </summary>
        private string _myAddress;


        /// <summary>
        /// The _instance
        /// </summary>
        private static MirrorAgent _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static MirrorAgent Instance
        {
            get { return _instance ?? (_instance = new MirrorAgent()); }
        }


        /// <summary>
        /// Mirrors the specified metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        public void Mirror(EndpointDiscoveryMetadata metadata=null)
        {
            var toBeDeleted = new List<string>();
            Logger.Info("Mirroring...");
            foreach (var mirrorNode in _mirrors)
            {
                try
                {
                    CallSubscribeToUpdates(mirrorNode);
                    if (metadata != null)
                        CallReceiveAnouncement(mirrorNode, metadata);
                }
                catch (Exception)
                {
                    toBeDeleted.Add(mirrorNode);
                }
            }
            foreach (var item in toBeDeleted)
            {
                RemoveMirror(item);
            }
            Logger.Info("Done mirroring...");
        }


        /// <summary>
        /// Calls the receive on mirror.
        /// </summary>
        /// <param name="mirrorNode">The mirror node.</param>
        /// <param name="metadata">The metadata.</param>
        private void CallReceiveAnouncement(string mirrorNode, EndpointDiscoveryMetadata metadata)
        {
            if (mirrorNode == MyAddress) return;
            Logger.Info("Mirroring metadata to {0}", mirrorNode);
            using (var serviceFactory =
                new ChannelFactory<IMirror>(new BasicHttpBinding(), mirrorNode))
            {
                try
                {
                    var c = serviceFactory.CreateChannel();
                   // c.ReceiveAnnouncement(metadata);
                    Logger.Info("{0} -> Success", mirrorNode);
                }
                catch (Exception exception)
                {
                    Logger.Error("");
                    Logger.Error(">>>>>>>>>>>   ERROR   <<<<<<<<<<<<<<<<");
                    Logger.Error("Error mirroring to {0}.",mirrorNode);
                    Logger.Error("--> {0}",  exception.Message);
                    Logger.Error(">>>>>>>>>>> END ERROR <<<<<<<<<<<<<<<<");
                    Logger.Error("");
                }
                finally
                {
                    serviceFactory.Close();
                }
            }
            Logger.Info("Mirroring metadata to {0} ended.", mirrorNode);
        }


        /// <summary>
        /// Gets or sets my address.
        /// </summary>
        /// <value>My address.</value>
        public string MyAddress
        {
            get { return _myAddress; }
            set
            {
                if (value != null && _myAddress != value)
                {
                    _myAddress = value;
                }

            }
        }

        /// <summary>
        /// Propagates the mirror.
        /// </summary>
        /// <param name="absoluteUri">The absolute URI.</param>
        public void PropagateMirror(string absoluteUri)
        {
            if (!EngineConfiguration.Mirror) return;
            RemoveMirror(MyAddress);
            var toBeRemoved = new List<string>();
            Logger.Info("");
            Logger.Info("");
            Logger.Info("*****     Propagating mirrors.   *******");
            foreach (var mirror in _mirrors)
            {
                try
                {
                    CallSubscribeToUpdates(mirror);
                }
                catch (Exception)
                {
                    toBeRemoved.Add(mirror);
                }
            }
            foreach (var item in toBeRemoved)
            {
                RemoveMirror(item);
            }
            Logger.Info("*****  Mirror propagation ended. *******");
            Logger.Info("");
            Logger.Info("");
        }

        /// <summary>
        /// Removes the mirror.
        /// </summary>
        /// <param name="item">The item.</param>
        private void RemoveMirror(string item)
        {
            lock (_mirrors)
            {
                if (!_mirrors.Contains(item)) return;
                _mirrors.Remove(item);
                Logger.Info("Removed [{0}] from known mirrors.", item);
            }
        }

        /// <summary>
        /// Adds the mirror.
        /// </summary>
        /// <param name="item">The absolute URI.</param>
        public void AddMirror(string item)
        {
            lock (_mirrors)
            {
                if (_mirrors.Contains(item)) return;
                _mirrors.Add(item);
                Logger.Info("Added [{0}] to known mirrors.",item);
            }
        }


        /// <summary>
        /// Subscribes the engine.
        /// </summary>
        /// <param name="absoluteUri">The absolute URI.</param>
        private  void CallSubscribeToUpdates(string absoluteUri)
        {
            if(absoluteUri==MyAddress) return;
            Logger.Info("");
            Logger.Info("Subscribing at {0}...", absoluteUri);
            using (var serviceFactory =
                new ChannelFactory<IMirror>(new BasicHttpBinding(), absoluteUri))
            {
                try
                {
                    var c = serviceFactory.CreateChannel();
                    c.SubscribeToUpdates(absoluteUri);
                    Logger.Info("Subscription @ {0} Succeeded.", absoluteUri);
                }
                catch (Exception exception)
                {
                    Logger.Error("");
                    Logger.Error(">>>>>>>>>>>   ERROR   <<<<<<<<<<<<<<<<");
                    Logger.Error("Error subscribing at {0}", absoluteUri);
                    Logger.Error("--> {0}", exception.Message);
                    Logger.Error(">>>>>>>>>>> END ERROR <<<<<<<<<<<<<<<<");
                    Logger.Error("");
                    throw;
                }
                finally
                {
                    serviceFactory.Close();
                }
            }
            Logger.Info("Subscribing at {0} ended.", absoluteUri);
            Logger.Info("");
        }


        /// <summary>
        /// Adds the mirrors.
        /// </summary>
        /// <param name="strings">The strings.</param>
        public void AddMirrors(string[] strings)
        {
            foreach (var s in strings)
            {
                AddMirror(s);
            }
            foreach (var s in _mirrors)
            {
                CallAddMirrors(s, _mirrors.ToArray());
            }
        }


        /// <summary>
        /// Calls the add mirrors.
        /// </summary>
        /// <param name="mirrorEndpoint">The mirror endpoint.</param>
        /// <param name="mirrors">The mirrors.</param>
        private void CallAddMirrors(string mirrorEndpoint, string[] mirrors)
        {
            if(mirrorEndpoint==MyAddress) return;
            Logger.Info("");
            Logger.Info("Adding mirrors at {0}...", mirrorEndpoint);
            using (var serviceFactory =
                new ChannelFactory<IMirror>(new BasicHttpBinding(), mirrorEndpoint))
            {
                try
                {
                    var c = serviceFactory.CreateChannel();
                    c.AddMirrors(mirrors);
                    Logger.Info("Adding mirrors @ {0} Succeeded.", mirrorEndpoint);
                }
                catch (Exception exception)
                {
                    Logger.Error("");
                    Logger.Error(">>>>>>>>>>>   ERROR   <<<<<<<<<<<<<<<<");
                    Logger.Error("Error adding mirrors @ {0}", mirrorEndpoint);
                    Logger.Error("--> {0}", exception.Message);
                    Logger.Error(">>>>>>>>>>> END ERROR <<<<<<<<<<<<<<<<");
                    Logger.Error("");
                    throw;
                }
                finally
                {
                    serviceFactory.Close();
                }
            }
            Logger.Info("Adding mirrors @ {0} ended.", mirrorEndpoint);
            Logger.Info("");

        }

    }
}