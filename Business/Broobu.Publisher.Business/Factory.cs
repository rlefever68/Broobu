// ***********************************************************************
// Assembly         : Broobu.Publisher.Business
// Author           : Rafael Lefever
// Created          : 08-10-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="Factory.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Publisher.Business.Bags;
using Broobu.Publisher.Contract.Domain;

namespace Broobu.Publisher.Business
{
    /// <summary>
    /// Class Factory.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Creates the test comfirmation email.
        /// </summary>
        /// <returns>PublishInfo.</returns>
        public static PublishInfo CreateTestConfirmationEmail()
        {
            var res = new PublishInfo()
            {
                Source = "mailer@tropus.be",
                Targets = new[] { "rafael.lefever@gmail.com", "rafael.lefever@insoft.com" },
                TemplateId = ConfirmationEmailTemplate.ID,
            };
            res.AddParameter("ActivationLink","http://www.broobu.com/cloudeen/activation/{0}/{1}");
            res.AddParameter("EmailFirstName","Rafael");
            res.AddParameter("PlatformMoreInfoEmail","rafael.lefever@gmail.com");
            res.AddParameter("PlatformMoreInfoUrl","http://www.broobu.com");
            res.AddParameter("PlatformName","Cloudeen");
            return res;
        }

        /// <summary>
        /// Creates the default email bag.
        /// </summary>
        /// <returns>EmailBag.</returns>
        public static EmailBag CreateDefaultEmailBag()
        {
            return EmailBag.Instance;
        }

        public static TemplateBag CreateDefaultTemplateBag()
        {
            return TemplateBag.Instance;

        }
    }
}
