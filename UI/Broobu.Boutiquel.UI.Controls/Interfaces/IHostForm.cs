using Broobu.EcoSpace.Contract.Domain.Account;

namespace Broobu.Boutique.UI.Controls.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHostForm
    {
        /// <summary>
        /// Configures for user.
        /// </summary>
        /// <param name="info">The info.</param>
        void ConfigureForUser(UserEnvironmentInfo info);

    }
}
