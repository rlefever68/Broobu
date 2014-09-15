using System;
using Broobu.EcoSpace.Contract.Domain.Account;


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
