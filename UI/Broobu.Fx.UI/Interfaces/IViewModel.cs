using Broobu.Fx.UI.MVVM;

namespace Broobu.Fx.UI.Interfaces
{
    /// <summary>
    ///     Exposes the methods and properties that must be implemented by a ViewModel
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        bool IsBusy { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        TransitionState State { get; set; }

        /// <summary>
        ///     Initializes this instance.
        ///     This method will make sure the initialization is only done
        ///     once and is not run at DesignTime, this to make sure
        ///     that the development environment does not crash when initializing
        ///     certain certain database or service connections.
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel.</param>
        void Initialize(params object[] parameters);
    }
}