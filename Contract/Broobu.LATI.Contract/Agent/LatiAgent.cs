// ***********************************************************************
// Assembly         : Broobu.LATI.Contract
// Author           : Rafael Lefever
// Created          : 01-23-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-23-2014
// ***********************************************************************
// <copyright file="LatiAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broobu.LATI.Contract.Domain;
using Broobu.LATI.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Extensions;
using Wulka.Networking.Wcf;

namespace Broobu.LATI.Contract.Agent
{
    /// <summary>
    /// Class LatiAgent.
    /// </summary>
    class LatiAgent : DiscoProxy<ILatiSentry>, ILatiAgent
    {
        public LatiAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        /// Registers the location.
        /// </summary>
        /// <param name="logItem">The log item.</param>
        /// <returns>LocationLog.</returns>
        public LocationLog RegisterLocation(LocationLog logItem)
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .RegisterLocation(logItem.Zip())
                    .Unzip<LocationLog>();
            }
            finally
            {
                CloseClient(clt);
            }
            
        }

        /// <summary>
        /// Gets the point of interest.
        /// </summary>
        /// <param name="poIId">The po i identifier.</param>
        /// <returns>PointOfInterest.</returns>
        public PointOfInterest GetPointOfInterest(string poIId)
        {
            var clt = CreateClient();
            try
            {
                return clt
                    .GetPointOfInterest(poIId)
                    .Unzip<PointOfInterest>();
            }
            finally
            {
                CloseClient(clt);
            }
        }


        protected override string GetContractNamespace()
        {
            return LatiServiceConst.Namespace;
        }
    }
}
