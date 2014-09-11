using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Broobu.Fx.UI.Attributes;

namespace Broobu.Fx.UI.MVVM
{
    /// <summary>
    ///     Exposes methods and events to observe the properties of a class T
    ///     The properties that are observed must raise the PropertyChanged event.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IsDirtyObserver<T> where T : class, INotifyPropertyChanged
    {
        private readonly Dictionary<string, IEnumerable<string>> _properties =
            new Dictionary<string, IEnumerable<string>>();

        /// <summary>
        ///     Registers the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Register(T obj)
        {
            string type = obj.GetType().Name;
            if (!_properties.ContainsKey(type))
            {
                _properties.Remove(type);
                string[] properties = obj.GetType().GetProperties()
                    .Where(IsDirtyProperty)
                    .Select(property => property.Name)
                    .ToArray();

                _properties.Add(type, properties);
            }

            obj.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        ///     Unregisters the specified object from the observer.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public void Unregister(T obj)
        {
            string type = obj.GetType().Name;
            if (_properties.ContainsKey(type))
            {
                obj.PropertyChanged -= OnPropertyChanged;
            }
        }

        /// <summary>
        ///     Called when a property of the object has changed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string type = sender.GetType().Name;
            var obj = sender as T;
            if (obj != null && _properties.ContainsKey(type))
            {
                if (_properties[type].Any(p => p.Equals(e.PropertyName)))
                {
                    RaiseIsDirty(obj);
                }
            }
        }

        /// <summary>
        ///     Creates the dirty property.
        /// </summary>
        /// <param name="property">The property.</param>
        private static bool IsDirtyProperty(PropertyInfo property)
        {
            var properties =
                (IgnoreIsDirtyAttribute[]) property.GetCustomAttributes(typeof (IgnoreIsDirtyAttribute), true);
            return properties.Length == 0;
        }

        /// <summary>
        ///     Occurs when the content of an object T has changed.
        /// </summary>
        public event EventHandler IsDirty;

        /// <summary>
        ///     Raises the is dirty changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void RaiseIsDirty(T sender)
        {
            if (IsDirty != null) IsDirty(sender, EventArgs.Empty);
        }
    }
}