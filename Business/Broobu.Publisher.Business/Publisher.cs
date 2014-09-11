// ***********************************************************************
// Assembly         : Broobu.Publisher.Business
// Author           : Rafael Lefever
// Created          : 08-08-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="PublisherProvider.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Net.Mail;
using Broobu.Publisher.Business.Bags;
using Broobu.Publisher.Business.Smtp;
using Broobu.Publisher.Business.Workers;
using Broobu.Publisher.Contract.Domain;
using Broobu.Publisher.Contract.Interfaces;


namespace Broobu.Publisher.Business
{
    /// <summary>
    /// Class PublisherProvider.
    /// </summary>
    public static class PublishProvider
    {

        /// <summary>
        /// To the mail message.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>MailMessage.</returns>
        internal static MailMessage ToMailMessage(this PublishInfo info)
        {
            var template = Templates
                .Get(x => x.Id == info.TemplateId)
                .First() 
                as Template;
            if (template == null) return null;
            template.Content = info;
            var msg = new MailMessage 
            {
                Subject = info.Subject,
                From= new MailAddress(SmtpConfig.SmtpFrom),
                Body = template.Body
            };
            foreach (var target in info.Targets)
            {
                msg.To.Add(new MailAddress(target));
            }
            return msg;
        }


        /// <summary>
        /// Gets the publications.
        /// </summary>
        /// <value>The publications.</value>
        public static IPublish Emails 
        {
            get
            {
                return new Emails();
            }
        }

        /// <summary>
        /// Gets the templates.
        /// </summary>
        /// <value>The templates.</value>
        public static ITemplateBag Templates
        {
            get
            {
                return TemplateBag.Instance;
            }
        }

        public static void InflateDomain()
        {
            var temp = TemplateBag.Instance;
            var emails = EmailBag.Instance;
        }
    }
}
