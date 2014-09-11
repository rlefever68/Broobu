// ***********************************************************************
// Assembly         : Broobu.Publisher.Business
// Author           : Rafael Lefever
// Created          : 08-10-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="ConfirmationEmailTemplate.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace Broobu.Publisher.Contract.Domain
{
    /// <summary>
    /// Class ConfirmationEmailTemplate.
    /// </summary>
    [DataContract]
    public class ConfirmationEmailTemplate : Template
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationEmailTemplate"/> class.
        /// </summary>
        public ConfirmationEmailTemplate()
        {
            Id = ID;
            DisplayName = "Confirmation Email Template";
            TemplateBody = "Hello %EmailFirstName%,\n\n" +
                           "Thank you for signing up with %PlatformName%.\n" +
                           "This message is to confirm your registration.\n" +
                           "Please click the link below to activate your account.\n" +
                           "\n\n%ActivationLink%\n\n" +
                           "This is an automated email message.\n" +
                           "For further information about %PlatformName%, please visit %PlatformMoreInfoUrl% or contact %PlatformMoreInfoEmail%";
                
        }

        /// <summary>
        /// The identifier
        /// </summary>
        public static string ID = "TMP_COMF_EMAIL";
    }
}