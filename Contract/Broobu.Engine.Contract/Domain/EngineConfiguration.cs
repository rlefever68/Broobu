// ***********************************************************************
// Assembly         : Broobu.Engine.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-25-2013
// ***********************************************************************
// <copyright file="EngineConfiguration.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Configuration;

namespace Broobu.Engine.Contract.Domain
{
    /// <summary>
    /// Class EngineConfiguration.
    /// </summary>
    public class EngineConfiguration
    {


        /// <summary>
        /// Class AppSettingKey.
        /// </summary>
        public class AppSettingKey
        {
            /// <summary>
            /// The service must be reachable
            /// </summary>
            public const string ServiceNegotiate = "Service.Negotiate";
            /// <summary>
            /// The engine isc cached
            /// </summary>
            public const string EngineIscCached = "Engine.IsCached";

            /// <summary>
            /// The server check timeout
            /// </summary>
            public const string NegotiateTimeout = "Negotiate.Timeout";

            /// <summary>
            /// The enable named pipes
            /// </summary>
            public const string EnableNamedPipes = "Enable.NamedPipes";
            /// <summary>
            /// The mirror
            /// </summary>
            public const string Mirror = "Enable.Mirror";
            /// <summary>
            /// The mirror nodes
            /// </summary>
            public const string MirrorNodes = "Mirror.Nodes";

            public const string LogRegistration = "Engine.LogRegistration";
        }



        /// <summary>
        /// Gets a value indicating whether this instance is cached.
        /// </summary>
        /// <value><c>true</c> if this instance is cached; otherwise, <c>false</c>.</value>
        public static bool IsCached
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[AppSettingKey.EngineIscCached]); }
        }


        /// <summary>
        /// Gets a value indicating whether [must be reachable].
        /// </summary>
        /// <value><c>true</c> if [must be reachable]; otherwise, <c>false</c>.</value>
        public static bool Negotiate
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingKey.ServiceNegotiate] == null ||
                    Convert.ToBoolean(ConfigurationManager.AppSettings[AppSettingKey.ServiceNegotiate]);
            }
        }

        /// <summary>
        /// Gets the server check timeout.
        /// </summary>
        /// <value>The server check timeout.</value>
        public static int ServiceNegotiateTimeout 
        {
            get
            {
                if (ConfigurationManager.AppSettings[AppSettingKey.NegotiateTimeout] == null) return 5000;
                return Convert.ToInt32(ConfigurationManager.AppSettings[AppSettingKey.NegotiateTimeout]);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [enable named pipes].
        /// </summary>
        /// <value><c>true</c> if [enable named pipes]; otherwise, <c>false</c>.</value>
        public static bool EnableNamedPipes 
        {
            get 
            { 
                if(ConfigurationManager.AppSettings[AppSettingKey.EnableNamedPipes]==null) return false;
                return Convert.ToBoolean(ConfigurationManager.AppSettings[AppSettingKey.EnableNamedPipes]);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="EngineConfiguration"/> is mirror.
        /// </summary>
        /// <value><c>true</c> if mirror; otherwise, <c>false</c>.</value>
        public static bool Mirror 
        {
            get
            {
                if (ConfigurationManager.AppSettings[AppSettingKey.Mirror] == null) return false;
                return Convert.ToBoolean(ConfigurationManager.AppSettings[AppSettingKey.Mirror]);
            }
        }

        /// <summary>
        /// Gets the mirror nodes.
        /// </summary>
        /// <value>The mirror nodes.</value>
        public static string[] MirrorNodes
        {
            get
            {
                if (ConfigurationManager.AppSettings[AppSettingKey.MirrorNodes] == null) return null;
                return ConfigurationManager.AppSettings[AppSettingKey.MirrorNodes].Split(',');
            }
        }


        public static bool LogRegistration 
        {
            get
            {
                if (ConfigurationManager.AppSettings[AppSettingKey.LogRegistration] == null) return false;
                return Convert.ToBoolean(ConfigurationManager.AppSettings[AppSettingKey.LogRegistration]);
            }
        }
    }
}
