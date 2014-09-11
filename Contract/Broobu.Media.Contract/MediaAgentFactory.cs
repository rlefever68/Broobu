// ***********************************************************************
// Assembly         : Broobu.Media.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="MediaAgentFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Media.Contract.Agent;
using Broobu.Media.Contract.Interfaces;

namespace Broobu.Media.Contract
{
    /// <summary>
    /// Class MediaAgentFactory.
    /// </summary>
	public partial class MediaAgentFactory
	{
		#region Methods
        /// <summary>
        /// Creates the media agent.
        /// </summary>
        /// <returns>IMediaAgent.</returns>
		public static IDescriptionAgent CreateDescriptionAgent()
		{
			return new DescriptionAgent();
		}


        /// <summary>
        /// Creates the setting agent.
        /// </summary>
        /// <returns>ISettingAgent.</returns>
	    public static ISettingAgent CreateSettingAgent()
	    {
	        return new SettingAgent();
	    }

        /// <summary>
        /// Creates the enumeration agent.
        /// </summary>
        /// <returns>IEnumerationAgent.</returns>
	    public static IEnumerationAgent CreateEnumerationAgent()
	    {
	        return new EnumerationAgent();
	    }


        /// <summary>
        /// Creates the relation agent.
        /// </summary>
        /// <returns>IRelationAgent.</returns>
	    public static ILinkAgent CreateLinkAgent()
	    {
	        return new LinkAgent();
	    }


       


	    #endregion
	}
}