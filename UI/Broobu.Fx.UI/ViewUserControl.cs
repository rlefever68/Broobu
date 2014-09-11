using System.Windows;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Exposes a StateAware Control to be used with the ViewModelBase.
    ///     By default the control will initialze the ViewModelBase when the currenet
    ///     DataContext changes or when the View is loaded.
    /// </summary>
    public class ViewUserControl : StateAwareControl
    {
        /// <summary>
        ///     Gets or sets the docked template.
        /// </summary>
        /// <value>The docked template.</value>
        public UIElement DockedTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public virtual object Context { get; set; }
    }
}