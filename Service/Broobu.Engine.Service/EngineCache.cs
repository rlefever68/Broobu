// ***********************************************************************
// Assembly         : Broobu.Engine.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-26-2013
// ***********************************************************************
// <copyright file="EngineCache.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using Broobu.Engine.Contract.Domain;
using NLog;


namespace Broobu.Engine.Service
{
    /// <summary>
    /// Class EngineCache.
    /// </summary>
    class EngineCache
    {


        /// <summary>
        /// The _online services
        /// </summary>
        private readonly Dictionary<EndpointAddress, EndpointDiscoveryMetadata> _onlineServices = new Dictionary<EndpointAddress, EndpointDiscoveryMetadata>();

        /// <summary>
        /// The _instance
        /// </summary>
        private static EngineCache _instance;



        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static EngineCache Instance
        {
            get { return _instance ?? (_instance = new EngineCache()); }
        }


        ///// <summary>
        ///// The helper
        ///// </summary>
        //private static readonly CacheHelper Helper = new CacheHelper("discoproxy", "services");

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        


        ///// <summary>
        ///// Reads the data.
        ///// </summary>
        ///// <param name="key">The key.</param>
        ///// <returns>System.Object.</returns>
        //static object ReadData(string key)
        //{
        //    _logger.Info("Reading data from AppFabric cache key={0}", key);
        //    return Helper.ReadData(key);
        //}


        ///// <summary>
        ///// Writes the data.
        ///// </summary>
        ///// <param name="key">The key.</param>
        ///// <param name="data">The data.</param>
        //void WriteData(string key, object data)
        //{
        //    lock (Helper)
        //    {
        //        _logger.Info("Writing data to AppFabric cache: key={0} value={1}", key, data);
        //        Helper.WriteData(key, data);
        //    }
        //}

        ///// <summary>
        ///// Removes the data.
        ///// </summary>
        ///// <param name="key">The key.</param>
        ///// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        //void RemoveData(string key)
        //{
        //    lock (Helper)
        //    {
        //        Helper.RemoveData(key);
        //    }
        //}

        ///// <summary>
        ///// Gets the data.
        ///// </summary>
        //private void GetDataFromCache()
        //{
        //    _logger.Info("Getting from cache");
        //    if (!EngineConfiguration.IsCached) return;
        //    var res = (ReadData("onlineservices") as Dictionary<EndpointAddress, EndpointDiscoveryMetadata>);
        //    if (res != null)
        //        _onlineServices = res;
        //}

        /// <summary>
        /// Determines whether [contains] [the specified metadata].
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns><c>true</c> if [contains] [the specified metadata]; otherwise, <c>false</c>.</returns>
        public bool ContainsDiscoMetadata(EndpointDiscoveryMetadata metadata)
        {
            return (_onlineServices.ContainsKey(metadata.Address));
        }

        /// <summary>
        /// Registers the online service.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        public void RegisterDiscoMetadata(EndpointDiscoveryMetadata metadata)
        {
            if (EngineConfiguration.LogRegistration)
                Logger.Info("Caching : {0}", metadata.Address);
            _onlineServices[metadata.Address] = metadata;                                
        }

        /// <summary>
        /// Unregisters the online service.
        /// </summary>
        /// <param name="metadata">The endpoint discovery metadata.</param>
        public void UnregisterDiscoMetadata(EndpointDiscoveryMetadata metadata)
        {
            //var uri = new Uri(metadata.Address.ToString());
            //if (uri.Scheme == Uri.UriSchemeNetPipe)
            //{ 
            //    var newUrl = metadata.Address.ToString().Replace(uri.Host,"localhost");
            //    metadata.Address = new EndpointAddress(newUrl);
            //}
            if(EngineConfiguration.LogRegistration)
                Logger.Info("Unregistering metadata : {0}", metadata.Address);
            _onlineServices.Remove(metadata.Address);                
        }

        /// <summary>
        /// Matches from online service.
        /// </summary>
        /// <param name="findRequestContext">The find request context.</param>
        public void MatchFromOnlineService(FindRequestContext findRequestContext)
        {
            foreach (var metadata in _onlineServices.Values
                .Where(data => findRequestContext.Criteria.IsMatch(data)))
            {
                findRequestContext.AddMatchingEndpoint(metadata);
            }
        }

        /// <summary>
        /// Matches from online service.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>EndpointDiscoveryMetadata.</returns>
        internal EndpointDiscoveryMetadata MatchFromOnlineService(ResolveCriteria criteria)
        {
            EndpointDiscoveryMetadata matchingEndpoint = null;
            foreach (EndpointDiscoveryMetadata metadata in 
                _onlineServices.Values.Where(x => criteria.Address == x.Address))
            {
                matchingEndpoint = metadata;
            }
            return matchingEndpoint;
        }

        ///// <summary>
        ///// Refreshes the data.
        ///// </summary>
        //public void RefreshData()
        //{
        //    GetDataFromCache();
        //}

        ///// <summary>
        ///// Saves the data.
        ///// </summary>
        //internal void SaveData()
        //{
        //    _logger.Info("Saving to cache");
        //    if (!EngineConfiguration.IsCached) return;
        //    RemoveData("onlineservices");
        //    WriteData("onlineservices", _onlineServices);
        //}
    }
}
