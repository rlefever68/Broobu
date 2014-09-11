// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="AuthorizationAgentFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.EcoSpace.Contract.Agents;
using Broobu.EcoSpace.Contract.Interfaces;

namespace Broobu.EcoSpace.Contract
{
    /// <summary>
    ///     Class AuthorizationAgentFactory.
    /// </summary>
    public static class EcoSpacePortal
    {
        public static IEcoSpaceAgent EcoSpace
        {
            get { return new EcoSpaceAgent(null); }
        }

        public static IEcoSpaceAgent GetEcoSpace(string discoUrl)
        {
            return new EcoSpaceAgent(discoUrl);
        }
    }
}