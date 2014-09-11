namespace Broobu.Authentication.UI.Controls
{
    /// <summary>
    /// Exposes the different states of the LoginView
    /// </summary>
    public class LoginViewState
    {
        /// <summary>
        /// List of states
        /// </summary>
        public class State
        {
            ///<summary>
            /// Login Normal State
            ///</summary>
            public const string Normal = "Normal";
            /// <summary>
            /// Login Connecting State
            /// </summary>
            public const string ShowProgress = "ShowProgress";
            /// <summary>
            /// Login Error State
            /// </summary>
            public const string ShowErrorMessage = "ShowErrorMessage";
        }

        /// <summary>
        /// List of transition states
        /// </summary>
        public class UseTransition
        {
            /// <summary>
            /// Normam Transition State
            /// </summary>
            public const bool Normal = false;
            /// <summary>
            /// Connecting Transition State
            /// </summary>
            public const bool ShowProgress = false;
            /// <summary>
            /// Error Transition State
            /// </summary>
            public const bool ShowErrorMessage = false;
        }

        /// <summary>
        /// Exposes the different state groups
        /// </summary>
        public class StateGroup
        {
            /// <summary>
            /// Login States
            /// </summary>
            public const string LoginStates = "LoginStates";
        }

    }
}