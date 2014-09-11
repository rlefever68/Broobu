using System;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Event that can be raised to tell if an instance is dirty or not
    /// </summary>
    public class IsDirtyEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IsDirtyEventArgs" /> class.
        /// </summary>
        /// <param name="isDirty">if set to <c>true</c> [is dirty].</param>
        public IsDirtyEventArgs(bool isDirty)
        {
            IsDirty = isDirty;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is dirty.
        /// </summary>
        /// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
        public bool IsDirty { get; private set; }
    }
}