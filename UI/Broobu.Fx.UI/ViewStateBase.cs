using System.ComponentModel;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Exposes a base class implementation for a ViewState
    /// </summary>
    public abstract class ViewStateBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}