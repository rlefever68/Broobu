// ***********************************************************************
// Assembly         : Broobu.Authorization.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="AuthorizationProviderFactory.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Business.Interfaces;
using Broobu.EcoSpace.Business.Workers;
using Broobu.EcoSpace.Contract.Domain.Account;

namespace Broobu.EcoSpace.Business
{
    /// <summary>
    /// Class AuthorizationProviderFactory.
    /// </summary>
    public static class EcoSpaceProvider
    {
        /// <summary>
        /// Gets the eco spaces.
        /// </summary>
        /// <value>The eco spaces.</value>
        public static IEcoSpaces EcoSpaces
        {
            get { return new EcoSpaces(); }
        }

        



    }
}
