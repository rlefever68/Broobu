// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-05-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-09-2014
// ***********************************************************************
// <copyright file="BusyOverlay.xaml.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Windows;
using System.Windows.Controls;

namespace Broobu.Fx.UI.Views
{
    /// <summary>
    ///     Busy Overlay
    /// </summary>
    public class BusyOverlay : ContentControl
    {
        /// <summary>
        ///     IsBusyProperty
        /// </summary>
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(Property.IsBusy,
            typeof (bool),
            typeof (BusyOverlay));

        /// <summary>
        ///     HasNoDataProperty
        /// </summary>
        public static readonly DependencyProperty HasNoDataProperty = DependencyProperty.Register(Property.HasNoData,
            typeof (bool),
            typeof (BusyOverlay));

        /// <summary>
        ///     The _hourglass
        /// </summary>
        private MediaElement _hourglass;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BusyOverlay" /> class.
        /// </summary>
        public BusyOverlay()
        {
            var uri = new Uri("/Broobu.Fx.UI;component/Views/BusyOverlay.xaml", UriKind.Relative);
            Resources = Application.LoadComponent(uri) as ResourceDictionary;
        }


        /// <summary>
        ///     Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has no data.
        /// </summary>
        /// <value><c>true</c> if this instance has no data; otherwise, <c>false</c>.</value>
        public bool HasNoData { get; set; }


        /// <summary>
        ///     Raises the <see cref="E:System.Windows.FrameworkElement.Initialized" /> event. This method is invoked whenever
        ///     <see cref="P:System.Windows.FrameworkElement.IsInitialized" /> is set to true internally.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs" /> that contains the event data.</param>
        protected override void OnInitialized(EventArgs e)
        {
            object h = Template.FindName("hourglass", this);
            _hourglass = h as MediaElement;
            if (_hourglass == null) return;
            _hourglass.MediaEnded += (s, a) =>
            {
                _hourglass.Position = new TimeSpan(0, 0, 1);
                _hourglass.Play();
            };
            base.OnInitialized(e);
        }

        /// <summary>
        ///     Properties
        /// </summary>
        public class Property
        {
            /// <summary>
            ///     The is busy
            /// </summary>
            public const string IsBusy = "IsBusy";

            /// <summary>
            ///     The has no data
            /// </summary>
            public const string HasNoData = "HasNoData";
        }
    }
}