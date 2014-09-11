// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 12-25-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-25-2013
// ***********************************************************************
// <copyright file="RefreshableViewModelBase.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Class RefreshableViewModelBase.
    /// </summary>
    public abstract class RefreshableViewModelBase : FxViewModelBase
    {
        /// <summary>
        ///     The sw request
        /// </summary>
        private readonly Stopwatch swRequest;

        /// <summary>
        ///     The TMR
        /// </summary>
        private readonly DispatcherTimer tmr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscoViewItemViewModel" /> class.
        /// </summary>
        protected RefreshableViewModelBase()
        {
            Refresh = new DelegateCommand(DoRefresh);
            tmr = CreateRefreshTimer();
            swRequest = new Stopwatch();
        }


        /// <summary>
        ///     Gets the duration of the request.
        /// </summary>
        /// <value>The duration of the request.</value>
        public string RequestDuration
        {
            get { return String.Format("{0:F1} seconds", swRequest.Elapsed.TotalSeconds); }
        }


        /// <summary>
        ///     Gets or sets the refresh.
        /// </summary>
        /// <value>The refresh.</value>
        public ICommand Refresh { get; set; }

        /// <summary>
        ///     Gets or sets the refresh time span.
        /// </summary>
        /// <value>The refresh time span.</value>
        public TimeSpan RefreshTimeSpan
        {
            get { return tmr.Interval; }
            set { tmr.Interval = value; }
        }


        /// <summary>
        ///     Does the refresh.
        /// </summary>
        private void DoRefresh()
        {
            swRequest.Start();
            tmr.Stop();
            ExecuteRefresh(DoRefreshCompleted);
        }


        /// <summary>
        ///     Executes the refresh.
        /// </summary>
        /// <param name="doRefreshCompleted">The do refresh completed.</param>
        private void ExecuteRefresh(Action<bool> doRefreshCompleted)
        {
            RefreshAsync(doRefreshCompleted);
        }

        /// <summary>
        ///     Does the refresh completed.
        /// </summary>
        /// <param name="obj">if set to <c>true</c> [object].</param>
        private void DoRefreshCompleted(bool obj)
        {
            IsBusy = false;
            tmr.Start();
            swRequest.Stop();
            RaisePropertyChanged(Property.RequestDuration);
            swRequest.Reset();
            OnRefreshCompleted();
        }

        /// <summary>
        ///     Called when [refresh completed].
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected abstract void OnRefreshCompleted();


        /// <summary>
        ///     Refreshes the asynchronous.
        /// </summary>
        /// <param name="doRefreshCompleted">The do refresh completed.</param>
        protected abstract void RefreshAsync(Action<bool> doRefreshCompleted);


        /// <summary>
        ///     Initializes the ViewModel the first time it is called.
        ///     This method will be called from the View that implements the
        ///     ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            DoRefresh();
        }


        /// <summary>
        ///     Creates the refresh timer.
        /// </summary>
        /// <returns>DispatcherTimer.</returns>
        private DispatcherTimer CreateRefreshTimer()
        {
            var tmr = new DispatcherTimer();
            tmr.Tick += (s, e) => OnRefresh();
            tmr.Interval = TimeSpan.FromSeconds(1*60);
            return tmr;
        }

        private void OnRefresh()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Class Property.
        /// </summary>
        public new class Property
        {
            /// <summary>
            ///     The request duration
            /// </summary>
            public const string RequestDuration = "RequestDuration";
        }
    }
}