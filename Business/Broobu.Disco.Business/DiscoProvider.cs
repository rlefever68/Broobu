// ***********************************************************************
// Assembly         : Broobu.Disco.Business
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-16-2014
// ***********************************************************************
// <copyright file="DiscoProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Disco.Business.Interfaces;
using Broobu.Disco.Business.Providers;


namespace Broobu.Disco.Business
{
    /// <summary>
    /// Class Disco.
    /// </summary>
    public static class DiscoProvider
    {
        /// <summary>
        /// Gets the discos.
        /// </summary>
        /// <value>The discos.</value>
        public static IDiscos Discos
        {
            get 
            { 
                return new Discos();
            }
        }

        /// <summary>
        /// Gets the contracts.
        /// </summary>
        /// <value>The contracts.</value>
        public static ICloudContracts CloudContracts 
        {
            get 
            {
                return new CloudContracts();
            }
        }

        /// <summary>
        /// Gets the application contracts.
        /// </summary>
        /// <value>The application contracts.</value>
        public static IAppContracts AppContracts 
        {
            get 
            { 
                return new AppContracts();
            }
        }



    }
}
