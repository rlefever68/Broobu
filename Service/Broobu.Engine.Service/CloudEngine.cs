// ***********************************************************************
// Assembly         : Broobu.Engine.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-25-2013
// ***********************************************************************
// <copyright file="CloudEngine.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using Broobu.Engine.Contract.Agents;
using Broobu.Engine.Contract.Domain;
using Broobu.Engine.Contract.Interfaces;
using NLog;


namespace Broobu.Engine.Service
{
    /// <summary>
    /// Class DiscoveryProxy.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CloudEngine : DiscoveryProxy, IDisposable, IMirror
    {

        /// <summary>
        /// The _mirrors
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The _sync
        /// </summary>
        private readonly object _sync = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEngine" /> class.
        /// </summary>
        public CloudEngine()
        {
            lock (_sync)
            {
                ServiceHelper.EnableExceptionHandling();
                _logger.Info("");
                _logger.Info("**************************************************");
                _logger.Info("*              Broobu CloudEngine                *");
                _logger.Info("*              Version {0}                 *", Assembly.GetExecutingAssembly().GetName().Version);
                _logger.Info("**************************************************");
                _logger.Info("*  Data Caching        : {0,5}                   ", EngineConfiguration.IsCached);
                _logger.Info("*  Service Negotiation : {0,5}                   ", EngineConfiguration.Negotiate);
                _logger.Info("*  Enable Named Pipes  : {0,5}                   ", EngineConfiguration.EnableNamedPipes);
                _logger.Info("*  Negotiation Timeout : {0,5} milliseconds       ", EngineConfiguration.ServiceNegotiateTimeout);
                _logger.Info("*  Log Registration    : {0,5}                   ", EngineConfiguration.LogRegistration);
                _logger.Info("*  Mirroring           : {0,5}                   ", EngineConfiguration.Mirror);


                if (EngineConfiguration.Mirror)
                {
                    foreach (var mirrorNode in EngineConfiguration.MirrorNodes)
                    {
                        _logger.Info("*\t@\t{0,5}", mirrorNode);
                    }
                }
                _logger.Info("**************************************************");
                _logger.Info("");
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ServiceModel.Discovery.DiscoveryProxy" /> class with the specified <see cref="T:System.ServiceModel.Discovery.DiscoveryMessageSequenceGenerator" />.
        /// </summary>
        /// <param name="messageSequenceGenerator">The message sequence generator.</param>
        protected CloudEngine(DiscoveryMessageSequenceGenerator messageSequenceGenerator)
            : base(messageSequenceGenerator)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ServiceModel.Discovery.DiscoveryProxy" /> class with the specified <see cref="T:System.ServiceModel.Discovery.DiscoveryMessageSequenceGenerator" /> and duplicate message history length.
        /// </summary>
        /// <param name="messageSequenceGenerator">The message sequence generator.</param>
        /// <param name="duplicateMessageHistoryLength">The maximum number of message hashes used by the transport for identifying duplicate messages. The default value is 0.</param>
        protected CloudEngine(DiscoveryMessageSequenceGenerator messageSequenceGenerator, int duplicateMessageHistoryLength)
            : base(messageSequenceGenerator, duplicateMessageHistoryLength)
        {

        }



        ///// <summary>
        ///// Refreshes from cache.
        ///// </summary>
        //public void RefreshFromCache()
        //{
        //    EngineCache.Instance.RefreshData();
        //}




        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            lock (_sync)
            {
                _logger.Info("");
                _logger.Info("********************************************");
                _logger.Info("*        Broobu CloudEngine Terminated     *");
                _logger.Info("*******************************************");
                _logger.Info("");
            }
        }








        /// <summary>
        /// Prints the discovery metadata.
        /// </summary>
        /// <param name="metadata">The endpoint discovery metadata.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="newCount">The new count.</param>
        void PrintDiscoveryMetadata(EndpointDiscoveryMetadata metadata, string verb)
        {
            lock (_sync)
            {
                foreach (var contractName in metadata.ContractTypeNames)
                {
                    var firstContractName = contractName.ToString();
                    if (firstContractName.Contains("/mex:")) continue;
                    _logger.Info("{0} [{1}] @ {2}", verb.ToUpper(), firstContractName, metadata.Address);
                    break;
                }

            }
        }




        /// <summary>
        /// Removes the online service.
        /// </summary>
        /// <param name="metadata">The endpoint discovery metadata.</param>
        private void RemoveOnlineService(EndpointDiscoveryMetadata metadata)
        {
            if (metadata == null) return;
            try
            {
                if (EngineCache.Instance != null)
                {
                    //if (!EngineCache.Instance.ContainsDiscoMetadata(endpointDiscoveryMetadata))
                    //{
                    //    _logger.Info("Service [{0}] is unknown, nothing to remove", endpointDiscoveryMetadata.Address);
                    //}
                    //else
                    //{
                    EngineCache.Instance.UnregisterDiscoMetadata(metadata);
                    PrintDiscoveryMetadata(metadata, "REMOVE");
                    //    EngineCache.Instance.SaveData();
                    //}
                }
                else
                {
                    _logger.Info("EngineCache.Instance is null");
                }
            }
            catch (Exception exception)
            {
                _logger.Info("Error Removing Service {0}", metadata.Address);
                _logger.Info("---> {0}", exception.Message);
                if (exception.InnerException != null)
                    _logger.Info("\t---> {0}", exception.InnerException.Message);
            }
        }




        /// <summary>
        /// Adds the online service.
        /// </summary>
        /// <param name="metadata">The endpoint discovery metadata.</param>
        private void AddOnlineService(EndpointDiscoveryMetadata metadata)
        {

            if (metadata == null) return;
            //if (EngineCache.Instance.ContainsDiscoMetadata(metadata))
            //{
            //    _logger.Info("Service [{0}] already known, nothing to add.", metadata.Address);
            //    return;
            //}
            if (EngineConfiguration.Negotiate)
            {
                ProcessPresentedEndpoint(metadata);
            }
            else
            {
                AddEndpoint(metadata);
            }
        }

        /// <summary>
        /// Processes the presented endpoint.
        /// </summary>
        /// <param name="data">The data.</param>
        private void ProcessPresentedEndpoint(EndpointDiscoveryMetadata data)
        {
            if (UrlIsValid(data))
                AddEndpoint(data);
        }



        /// <summary>
        /// URLs the is valid.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UrlIsValid(EndpointDiscoveryMetadata data)
        {
            string url = data.Address.ToString();
            var uri = new Uri(url);
            if (uri.Scheme == Uri.UriSchemeNetPipe)
            {
                return true;
            }
            else
            {
                try
                {
                    var request = WebRequest.Create(url) as HttpWebRequest;
                    request.Timeout = EngineConfiguration.ServiceNegotiateTimeout;
                    //set the timeout to 5 seconds to keep the user from waiting too long for the page to load
                    request.Method = "OPTIONS"; //Get only the OPTIONS information -- no need to download any content
                    _logger.Info("CHECK... {0}", url);
                    var response = request.GetResponse() as HttpWebResponse;
                    if (response != null)
                    {
                        var statusCode = (int)response.StatusCode;
                        _logger.Info("Status Code: {0,4}", statusCode);
                        if (statusCode >= 100 && statusCode <= 400) //Good requests
                        {
                            _logger.Info("{0} => OK", url);
                            return true;
                        }
                        if (statusCode >= 500 && statusCode <= 510) //Server Errors
                        {
                            _logger.Error(
                                "The remote server has thrown an internal error. Url is not valid: {0}", url);
                            return false;
                        }
                    }
                    _logger.Error("No response from: {0}", url);

                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError) //400 errors
                    {
                        if (ex.Message.Contains("400"))
                            return true;
                        _logger.Error("Protocol Error: {0}", ex.Message);
                        if (ex.InnerException != null)
                            _logger.Error("--> {0}", ex.InnerException.Message);
                        return false;
                    }
                    _logger.Error("Unhandled status [{0}] returned for url: {1}", ex.Status, url);
                }
                catch (Exception ex)
                {
                    _logger.Error("Could not test url {0}. Error: {1}", url, ex.Message);
                    return false;
                }
                return false;
            }

        }



        /// <summary>
        /// Adds the endpoint.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        private void AddEndpoint(EndpointDiscoveryMetadata metadata)
        {
            try
            {
                string address = metadata.Address.ToString();
                var uri = new Uri(address);
                if (uri.Scheme == Uri.UriSchemeNetPipe)
                {
                    //address = address.Replace(uri.Host, "localhost");
                    //metadata.Address = new EndpointAddress(new Uri(address), EndpointIdentity.CreateDnsIdentity("localhost"));
                    _logger.Info("Named Pipe on {0} => OK", address);
                }
                EngineCache.Instance.RegisterDiscoMetadata(metadata);
                PrintDiscoveryMetadata(metadata, "ADD");
                if (EngineConfiguration.Mirror)
                {
                    MirrorAgent.Instance.Mirror(metadata);
                }
            }
            catch (Exception exception)
            {
                _logger.Info("Error adding Service {0}", metadata.Address);
                _logger.Info("---> {0}", exception.Message);
                if (exception.InnerException != null)
                    _logger.Info("\t---> {0}", exception.InnerException.Message);

            }
        }



        /// <summary>
        /// Attempt to match a service with a service in the dictionary
        /// </summary>
        /// <param name="findRequestContext">The find request context.</param>
        void MatchFromOnlineService(FindRequestContext findRequestContext)
        {
            EngineCache.Instance.MatchFromOnlineService(findRequestContext);
        }

        /// <summary>
        /// Attempt to match a service with a service in the dictionary
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>EndpointDiscoveryMetadata.</returns>
        EndpointDiscoveryMetadata MatchFromOnlineService(ResolveCriteria criteria)
        {
            return EngineCache.Instance.MatchFromOnlineService(criteria);
        }










        // OnBeginFind method is called when a Probe request message is received by the Proxy
        /// <summary>
        /// Override this method to handle a find operation.
        /// </summary>
        /// <param name="findRequestContext">The find request context that describes the service to discover.</param>
        /// <param name="callback">The callback delegate to call when the operation is completed.</param>
        /// <param name="state">The user-defined state data.</param>
        /// <returns>A reference to the pending asynchronous operation.</returns>
        protected override IAsyncResult OnBeginFind(FindRequestContext findRequestContext, AsyncCallback callback, object state)
        {
            MatchFromOnlineService(findRequestContext);
            return new OnFindAsyncResult(callback, state);
        }

        /// <summary>
        /// This method is called with the discovery proxy receives an offline announcement message.
        /// </summary>
        /// <param name="messageSequence">The discovery message sequence.</param>
        /// <param name="endpointDiscoveryMetadata">The endpoint discovery metadata.</param>
        /// <param name="callback">The callback delegate to call when the operation is completed.</param>
        /// <param name="state">The user-defined state data.</param>
        /// <returns>A reference to the pending asynchronous operation.</returns>
        protected override IAsyncResult OnBeginOfflineAnnouncement(DiscoveryMessageSequence messageSequence, EndpointDiscoveryMetadata endpointDiscoveryMetadata, AsyncCallback callback, object state)
        {
            // We might wanna just keep all Endpoints once they have announced themselves. 
            // I activated the remove again as it is needed for updating services.
            // If we dont remove it; it will maintain old Endpoints

            _logger.Info("Received GOODBYE from {0}", endpointDiscoveryMetadata.Address);
            RemoveOnlineService(endpointDiscoveryMetadata);
            return new OnOfflineAnnouncementAsyncResult(callback, state);

        }




        /// <summary>
        /// OnBeginOnlineAnnouncement method is called when a Hello message is received by the Proxy
        /// </summary>
        /// <param name="messageSequence">The discovery message sequence.</param>
        /// <param name="metadata">The endpoint discovery metadata.</param>
        /// <param name="callback">The callback delegate to call when the operation is completed.</param>
        /// <param name="state">The user-defined state data.</param>
        /// <returns>A reference to the pending asynchronous operation.</returns>
        protected override IAsyncResult OnBeginOnlineAnnouncement(DiscoveryMessageSequence messageSequence, EndpointDiscoveryMetadata metadata, AsyncCallback callback, object state)
        {
            _logger.Info("Received HELLO from {0}", metadata.Address);
            AddOnlineService(metadata);
            return new OnOnlineAnnouncementAsyncResult(callback, state);
        }



        // OnBeginFind method is called when a Resolve request message is received by the Proxy
        /// <summary>
        /// Override this method to handle a resolve operation.
        /// </summary>
        /// <param name="resolveCriteria">The resolve criteria that describes the service to discover.</param>
        /// <param name="callback">The callback delegate to call when the operation is completed.</param>
        /// <param name="state">The user-defined state data.</param>
        /// <returns>A reference to the pending asynchronous operation.</returns>
        protected override IAsyncResult OnBeginResolve(ResolveCriteria resolveCriteria, AsyncCallback callback, object state)
        {
            return new OnResolveAsyncResult(this.MatchFromOnlineService(resolveCriteria), callback, state);
        }



        /// <summary>
        /// Override this method to handle the completion of a find operation.
        /// </summary>
        /// <param name="result">A reference to the completed asynchronous operation.</param>
        protected override void OnEndFind(IAsyncResult result)
        {
            OnFindAsyncResult.End(result);
        }


        /// <summary>
        /// This method is called when the discovery proxy finishes processing an offline announcement message
        /// </summary>
        /// <param name="result">A reference to the completed asynchronous operation.</param>
        protected override void OnEndOfflineAnnouncement(IAsyncResult result)
        {
            OnOfflineAnnouncementAsyncResult.End(result);
        }


        /// <summary>
        /// This method is called when the discovery proxy finishes processing an announcement message.
        /// </summary>
        /// <param name="result">A reference to the completed asynchronous operation.</param>
        protected override void OnEndOnlineAnnouncement(IAsyncResult result)
        {
            OnOnlineAnnouncementAsyncResult.End(result);
        }

        /// <summary>
        /// Override this method to handle the completion of a resolve operation.
        /// </summary>
        /// <param name="result">A reference to the completed asynchronous operation.</param>
        /// <returns>Endpoint discovery metadata for the resolved service.</returns>
        protected override EndpointDiscoveryMetadata OnEndResolve(IAsyncResult result)
        {
            return OnResolveAsyncResult.End(result);
        }


        #region IMirror Implementation
        /// <summary>
        /// Receives the announcement.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        public void ReceiveAnnouncement(EndpointDiscoveryMetadata metadata)
        {
            _logger.Info("");
            _logger.Info("Incoming Request on {0}", MirrorAgent.Instance.MyAddress);
            _logger.Info("---      Mirror Contract Announcement      -----");
            _logger.Info("");
            AddOnlineService(metadata);
            _logger.Info("");
            _logger.Info("---    End Contract Announcement    -----");
            _logger.Info("");
        }

        /// <summary>
        /// Subscribes to updates.
        /// </summary>
        /// <param name="absoluteUri">The absolute URI.</param>
        public void SubscribeToUpdates(string absoluteUri)
        {
            _logger.Info("");
            _logger.Info("Incoming Request on {0}", MirrorAgent.Instance.MyAddress);
            _logger.Info("------   [Subscription Request]    ----");
            _logger.Info("\tReceived subscription request from: {0}", absoluteUri);
            MirrorAgent.Instance.AddMirror(absoluteUri);
            _logger.Info("\tAdded subscriber: {0}", absoluteUri);
            _logger.Info("---   [End Subscription Request]  -----");
            _logger.Info("");
        }

        /// <summary>
        /// Adds the mirrors.
        /// </summary>
        /// <param name="mirrors">The mirrors.</param>
        public void AddMirrors(string[] mirrors)
        {
            _logger.Info("");
            _logger.Info("Incoming Request on {0}", MirrorAgent.Instance.MyAddress);
            _logger.Info("-------    Request to add mirror engines    -------");
            _logger.Info("Adding mirror engines.");
            MirrorAgent.Instance.AddMirrors(mirrors);
            _logger.Info("------- Request to add mirrir engines ended. ------");
            _logger.Info("");
        }
        #endregion

    }
}




