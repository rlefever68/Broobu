// ***********************************************************************
// Assembly         : Broobu.Publisher.Contract
// Author           : Rafael Lefever
// Created          : 08-08-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="PublisherPortal.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Publisher.Contract.Agents;

namespace Broobu.Publisher.Contract
{
    /// <summary>
    /// Class PublisherPortal.
    /// </summary>
    public class PublisherPortal
    {
        /// <summary>
        /// Gets the publisher.
        /// </summary>
        /// <value>The publisher.</value>
        public static IPublishAgent Publisher
        {
            get { return new PublishAgent(null);}
        }

    }
}
