namespace Broobu.Fx.UI.MVVM
{
    /// <summary>
    ///     The TransitionState is a helper class that contains the configuration to be used for Visual State transitions
    /// </summary>
    public class TransitionState
    {
        /// <summary>
        ///     String indicating the name of the state as used by VisualStateManager
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }

        /// <summary>
        ///     Boolean containing the indicator wheter or not to use state transitions in VisualStateManager
        /// </summary>
        /// <value><c>true</c> if [use transitions]; otherwise, <c>false</c>.</value>
        public bool UseTransitions { get; set; }
    }
}