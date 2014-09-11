// ***********************************************************************
// Assembly         : Broobu.Publisher.Business.Test
// Author           : Rafael Lefever
// Created          : 08-10-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="PublisherTestFixture.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.Publisher.Business.Workers;
using Broobu.Publisher.Contract.Domain;
using Broobu.Publisher.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Publisher.Business.Test
{
    /// <summary>
    /// Class PublisherTestFixture.
    /// </summary>
    [TestClass]
    public class PublisherTestFixture  : IPublish
    {
        /// <summary>
        /// Try_s the publish comfirmation email.
        /// </summary>
        [TestMethod]
        public void Try_PublishConfirmationEmail()
        {
            var em = Factory.CreateTestConfirmationEmail();
            var res = Publish(em);
            Console.WriteLine(res);
        }

        /// <summary>
        /// Publishes the specified information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>PublishInfo.</returns>
        public PublishInfo Publish(PublishInfo info)
        {
            return PublishProvider
                .Emails
                .Publish(info);
        }
        

        public void InflateTestDomain()
        {
            Emails.InflateDomain();
        }

    }
}
