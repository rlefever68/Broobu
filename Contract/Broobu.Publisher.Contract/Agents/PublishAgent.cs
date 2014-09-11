// ***********************************************************************
// Assembly         : Broobu.Publisher.Contract
// Author           : Rafael Lefever
// Created          : 08-10-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="PublisherAgent.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Publisher.Contract.Domain;
using Broobu.Publisher.Contract.Interfaces;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;
using NLog;

namespace Broobu.Publisher.Contract.Agents
{
    /// <summary>
    /// Class PublishAgent.
    /// </summary>
    class PublishAgent : DiscoProxy<IPublishSentry>, IPublishAgent
    {
        public PublishAgent(string discoUrl) : base(discoUrl)
        {
        }

        protected override string GetContractNamespace()
        {
            return PublisherConst.ServiceNamespace;
        }

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Publishes the specified information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>PublishInfo.</returns>
        public PublishInfo Publish(PublishInfo info)
        {
            var s = info.Zip();
            try
            {
                return Client
                    .Publish(s)
                    .Unzip<PublishInfo>();
            }
            catch (Exception exception)
            {

                Logger.Error(exception.GetCombinedMessages());
                info.AddError(exception.GetCombinedMessages());
                return info;
            }
            finally
            {
                CloseClient(Client);
            }
        }

      
    }
}
