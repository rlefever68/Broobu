// ***********************************************************************
// Assembly         : Broobu.Publisher.Service
// Author           : Rafael Lefever
// Created          : 08-09-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="PublishSentry.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Broobu.Publisher.Business;
using Broobu.Publisher.Contract.Domain;
using Broobu.Publisher.Contract.Interfaces;
using Wulka.Exceptions;
using Wulka.Extensions;
using Wulka.Networking.Wcf;
using NLog;

namespace Broobu.Publisher.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    /// <summary>
    /// Class PublisherSentry.
    /// </summary>
    public class PublishSentry: SentryBase,IPublishSentry
    {


        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Publishes the specified information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>System.String.</returns>
        public string Publish(string info)
        {
            
            var pi = info.Unzip<PublishInfo>();
            var res = String.Empty;
            try
            {
                pi = PublishProvider
                    .Emails
                    .Publish(pi);
                return pi.Zip();
            }
            catch (Exception exception)
            {
                pi.AddError(exception.GetCombinedMessages());
                _logger.Error(exception.GetCombinedMessages());
                
            }
            return res;
        }

        /// <summary>
        /// You MUST override this method, but you cannot use
        /// Initializing code in the constructor that references itself (since the object is not yet created) - Obsolete remark
        /// REMARK: since the code has been moved to the onOpen method of the servicehost; you can be certain now that
        /// the object has been created.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            PublishProvider.InflateDomain();
        }

    }
}
