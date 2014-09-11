// ***********************************************************************
// Assembly         : Broobu.Disco.Business
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-25-2013
// ***********************************************************************
// <copyright file="DiscoProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Xml;
using Broobu.Disco.Business.Interfaces;
using Wulka.Configuration;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Interfaces;
using Wulka.Logging;
using Wulka.Networking.Wcf;


namespace Broobu.Disco.Business.Providers
{
    /// <summary>
    /// Class DiscoProvider.
    /// </summary>
    class Discos : IDiscos
    {


        /// <summary>
        /// Creates the discovery client.
        /// </summary>
        /// <returns>DiscoveryClient.</returns>
        private static DiscoveryClient CreateDiscoveryClient()
        {
            var discoveryEndpoint = new DiscoveryEndpoint(
                BindingFactory.CreateBindingFromKey(BindingFactory.Key.WsHttpBindingNoSecurity),
                new EndpointAddress(new Uri(ConfigurationHelper.CloudProbe)));
            return new DiscoveryClient(discoveryEndpoint);
        }


        /// <summary>
        /// Gets the endpoint discovery metadata.
        /// </summary>
        /// <param name="contractTypeName">Name of the contract type.</param>
        /// <returns>SerializableEndpoint[][].</returns>
        public SerializableEndpoint[] GetEndpoints(string contractTypeName)
        {

            using (var clt = CreateDiscoveryClient())
            {
                try
                {
                    var lst = new List<XmlQualifiedName>() {new XmlQualifiedName(contractTypeName)};
                    var criteria = FindCriteria.CreateMetadataExchangeEndpointCriteria(lst);
                    var resp = clt.Find(criteria);
                    var serviceEndpoints = new List<SerializableEndpoint>();
                    foreach (var it in resp.Endpoints)
                        serviceEndpoints.AddRange(MetadataHelper
                            .GetEndpoints(it.Address.Uri.AbsoluteUri)
                            .Select(ep => new SerializableEndpoint(ep, 0)));
                    return serviceEndpoints.ToArray();
                }
                catch (Exception ex)
                {
                    FxLog<Discos>.LogException(ex);
                    return null;
                }
                finally
                {
                    CloseClient(clt);
                }

            }

        }



       


        /// <summary>
        /// Closes the client
        /// </summary>
        /// <param name="client">The client.</param>
        private static void CloseClient(DiscoveryClient client)
        {
            if (client.InnerChannel.State == CommunicationState.Opened)
            {
                client.Close();
            }
            else
            {
                client.InnerChannel.Abort();
            }
        }








        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>SerializableEndpoint[][].</returns>
        public SerializableEndpoint[] GetAllEndpoints()
        {
            using (var clt = CreateDiscoveryClient())
            {
                try
                {
                    var criteria = FindCriteria.CreateMetadataExchangeEndpointCriteria();
                    var resp = clt.Find(criteria);
                    var serviceEndpoints = new List<SerializableEndpoint>();
                    foreach (var it in resp.Endpoints)
                    {
                        try
                        {
                            var sep = MetadataHelper.GetEndpoints(it.Address.Uri.AbsoluteUri);
                            serviceEndpoints.AddRange(sep.Select(ep => new SerializableEndpoint(ep, 0)));
                        }
                        catch (Exception e)
                        {
                            FxLog<Discos>.LogException(e);
                        }
                    }
                    return serviceEndpoints.ToArray();
                }
                catch (Exception ex)
                {
                    FxLog<Discos>.LogException(ex);
                    return null;
                }
                finally
                {
                    CloseClient(clt);
                }
            }

        }



        #region IDiscoProvider Members


        /// <summary>
        /// Gets all endpoint addresses.
        /// </summary>
        /// <returns>DiscoItem[][].</returns>
        public DiscoItem[] GetAllEndpointAddresses()
        {
            using (var clt = CreateDiscoveryClient())
            {
                try
                {
                    var criteria = FindCriteria.CreateMetadataExchangeEndpointCriteria();
                    var resp = clt.Find(criteria);
                    var addresses = new List<DiscoItem>();

                    foreach (var it in resp.Endpoints.Where(i => (i.Address.Uri.Scheme == Uri.UriSchemeHttp))) // only consider http mex endpoints
                    {
                        try
                        {
                            var sep = MetadataHelper.GetEndpoints(it.Address.Uri.AbsoluteUri);
                            foreach (var ep in sep)
                            {
                                if (!ep.IsSystemEndpoint)
                                {
                                    addresses.Add(new DiscoItem()
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        Endpoint = ep.Address.Uri.OriginalString,
                                        Contract = String.Format("{0}:{1}", ep.Contract.Namespace, ep.Contract.Name)
                                    });
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            FxLog<Discos>.LogException(exp);
                        }
                    }
                    return addresses.ToArray();
                }
                finally
                {
                    CloseClient(clt);
                }
            }
        }


        /// <summary>
        /// Creates the error address.
        /// </summary>
        /// <param name="it">It.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>DiscoItem.</returns>
        private DiscoItem CreateErrorAddress(EndpointDiscoveryMetadata it, Exception exp)
        {
            try
            {
                var edi = new DiscoItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    Endpoint = exp.Message,
                    Contract = "Error in Service",
                };
                edi.AddError(exp.Message);
                if (exp.InnerException != null)
                    edi.AddError(String.Format("Inner: {0}", exp.InnerException.Message));
                return edi;
            }
            catch (Exception exep)
            {
                FxLog<Discos>.LogException(exep);
                return null;
            }

        }

        #endregion







    }
}

