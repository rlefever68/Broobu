// ***********************************************************************
// Assembly         : Broobu.Publisher.Business
// Author           : Rafael Lefever
// Created          : 08-08-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="ConfigHelper.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Configuration;

namespace Broobu.Publisher.Business.Smtp
{
    /// <summary>
    /// Class ConfigHelper.
    /// </summary>
    public class SmtpConfig
    {
        /// <summary>
        /// Gets the SMTP host.
        /// </summary>
        /// <value>The SMTP host.</value>
        public static string SmtpHost 
        { 
            get
            {
                return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Smtp.Host"]) 
                    ? "smtp.telenet.be" 
                    : Convert.ToString(ConfigurationManager.AppSettings["Smtp.Host"]);
            }
        }

        /// <summary>
        /// Gets the SMTP port.
        /// </summary>
        /// <value>The SMTP port.</value>
        public static int SmtpPort 
        {
            get
            {
                return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Smtp.Port"]) 
                    ? 587 
                    : Convert.ToInt32(ConfigurationManager.AppSettings["Smtp.Port"]);
            }
        }



        /// <summary>
        /// Gets the SMTP user.
        /// </summary>
        /// <value>The SMTP user.</value>
        /// <exception cref="System.Exception">Smtp.User is not specified.</exception>
        public static string SmtpUser
        {
            get
            {
                if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Smtp.User"]))
                    throw new Exception("Smtp.User is not specified.");
                return Convert.ToString(ConfigurationManager.AppSettings["Smtp.User"]);
            }
        }

        /// <summary>
        /// Gets the SMTP password.
        /// </summary>
        /// <value>The SMTP password.</value>
        /// <exception cref="System.Exception">Smtp.Pwd is not specified.</exception>
        public static string SmtpPwd
        {
            get
            {
                if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Smtp.Pwd"]))
                    throw new Exception("Smtp.Pwd is not specified.");
                return Convert.ToString(ConfigurationManager.AppSettings["Smtp.Pwd"]);
            }
        }


        /// <summary>
        /// Gets a value indicating whether [SMTP use SSL].
        /// </summary>
        /// <value><c>true</c> if [SMTP use SSL]; otherwise, <c>false</c>.</value>
        public static bool SmtpUseSsl
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["Smtp.UseSSL"]);
            }
        }



        public static string SmtpFrom
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["Smtp.From"]);
            }
        }







    }
}