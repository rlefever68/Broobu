﻿using System;
//using Broobu.Authorization.Contract.Domain;
using System.Collections.Generic;
using Broobu.Boutique.Contract.Domain;
//using Broobu.Taxonomy.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Links;


namespace Broobu.Boutique.Contract.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public interface IBoutiqueAgent 
    {
        UserEnvironmentInfo GetUserEnvironmentInfo();
        /// <summary>
        /// Occurs when [get Boutique user info completed].
        /// </summary>
        /// <remarks></remarks>
        event Action<UserEnvironmentInfo> GetUserEnvironmentInfoCompleted;
        /// <summary>
        /// Gets the Boutique user info async.
        /// </summary>
        /// <param name="act">The act.</param>
        /// <remarks></remarks>
        void GetUserEnvironmentInfoAsync(Action<UserEnvironmentInfo> act=null);


    }


    
}
