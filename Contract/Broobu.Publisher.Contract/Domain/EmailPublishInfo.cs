// ***********************************************************************
// Assembly         : Broobu.Publisher.Contract
// Author           : Rafael Lefever
// Created          : 08-10-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="EmailPublishInfo.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using Iris.Fx.Domain;

namespace Broobu.Publisher.Contract.Domain
{
    /// <summary>
    /// Class ConfirmEmailPublishInfo.
    /// </summary>
    [DataContract]
    public class EmailPublishInfo : PublishInfo
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailPublishInfo"/> class.
        /// </summary>
        public EmailPublishInfo()
        {
            AddParameter(new Parameter() { Id = "EmailFirstName", Value = EmailFirstName });
            AddParameter(new Parameter() { Id = "ActivationLink", Value = ActivationLink });
        }

        /// <summary>
        /// Gets or sets the platform more information email.
        /// </summary>
        /// <value>The platform more information email.</value>
        
        public string PlatformMoreInfoEmail 
        {
            get 
            {
                return ConfigurationManager.AppSettings["Platform.MoreInfoEmail"];
            }
        }


        /// <summary>
        /// Gets or sets the platform more information URL.
        /// </summary>
        /// <value>The platform more information URL.</value>
        public string PlatformMoreInfoUrl
        {
            get { return ConfigurationManager.AppSettings["Platform.MoreInfoUrl"]; }
        }

        /// <summary>
        /// Gets or sets the activation link.
        /// </summary>
        /// <value>The activation link.</value>
        public string ActivationLink
        {
            get 
            { 
                return Convert.ToString(Find<IParameter>("ActivationLink").Value); 
            }
            set 
            { 
                var res = Find<IParameter>("ActivationLink") 
                    ?? new Parameter() { Id = "ActivationLink"};
                res.Value = value;
                AddParameter(res);
            }
        }

        /// <summary>
        /// Gets or sets the name of the platform.
        /// </summary>
        /// <value>The name of the platform.</value>
        public string PlatformName 
        { 
            get { return ConfigurationManager.AppSettings["Platform.Name"]; }
        }

        /// <summary>
        /// Gets or sets the first name of the email.
        /// </summary>
        /// <value>The first name of the email.</value>
        [DataMember]
        public string EmailFirstName 
        {
            get
            {
                return Convert.ToString(Find<IParameter>("EmailFirstName").Value);
            }
            set
            {
                var res = Find<IParameter>("EmailFirstName")
                    ?? new Parameter() { Id = "EmailFirstName" };
                res.Value = value;
                AddParameter(res);
            }
        }
    }
}
