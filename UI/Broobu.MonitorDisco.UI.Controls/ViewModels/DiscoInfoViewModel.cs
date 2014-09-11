// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.UI.Controls
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 07-05-2014
// ***********************************************************************
// <copyright file="DiscoViewItemViewModel.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using Broobu.Authentication.UI.Controls;
using Broobu.Fx.UI.MVVM;
using Broobu.MonitorDisco.Contract;
using Broobu.MonitorDisco.Contract.Domain;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using NLog;
using Wulka.Exceptions;


namespace Broobu.MonitorDisco.UI.Controls.ViewModels
{
    /// <summary>
    /// Class DiscoViewItemViewModel.
    /// </summary>
    [POCOViewModel]
    public class DiscoInfoViewModel  : AuthenticatedViewModel
    {


        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>DiscoInfoViewModel.</returns>
        public static DiscoInfoViewModel Create()
        {
            return ViewModelSource.Create<DiscoInfoViewModel>();
        }


        /// <summary>
        /// Class Property.
        /// </summary>
        public new class Property
        {
            /// <summary>
            /// The discovered services
            /// </summary>
            public const string DiscoveredServices = "DiscoveredServices";
            /// <summary>
            /// The request duration
            /// </summary>
            public const string RequestDuration = "RequestDuration";
        }


        /// <summary>
        /// The sw request
        /// </summary>
        private readonly Stopwatch swRequest;


        /// <summary>
        /// Gets the duration of the request.
        /// </summary>
        /// <value>The duration of the request.</value>
        public string RequestDuration
        {
            get
            {
                return String.Format("{0:F1} seconds", swRequest.Elapsed.TotalSeconds);
            }
        }




        /// <summary>
        /// Gets or sets the refresh.
        /// </summary>
        /// <value>The refresh.</value>
        public TimeSpan RefreshTimeSpan
        {
            get
            {
                return _timer.Interval;
            }
            set
            {
                _timer.Interval = value;
            }
        }

        /// <summary>
        /// The TMR
        /// </summary>
        private readonly DispatcherTimer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoInfoViewModel" /> class.
        /// </summary>
        public DiscoInfoViewModel()
        {
            Messenger.Default.Register<ExceptionMvvmMsg>(this, m => {
                if (m == null) return;
                if (m.Exception == null) return;
                _logger.Error(m.Exception.GetCombinedMessages());
                ExceptionMessage = m.Exception.Message;
            });
            //Refresh = new DelegateCommand(GetAllEndpoints);
            DiscoveredServices = CreateDiscoveryServicesCollection();
            _timer = CreateRefreshTimer();
            swRequest = new Stopwatch();
        }

        public string ExceptionMessage
        {
            get { return _exceptionMessage; }
            set { _exceptionMessage = value; RaisePropertyChanged("ExceptionMessage"); }
        }

        /// <summary>
        /// Creates the refresh timer.
        /// </summary>
        /// <returns>DispatcherTimer.</returns>
        private DispatcherTimer CreateRefreshTimer()
        {
            var tmr = new DispatcherTimer();
            tmr.Tick += (s, e) => GetAllEndpoints();
            tmr.Interval = TimeSpan.FromSeconds(1*60);
            return tmr;
        }

        /// <summary>
        /// Creates the discovery services collection.
        /// </summary>
        /// <returns>ObservableCollection{DiscoViewItem}.</returns>
        private static ObservableCollection<DiscoInfo> CreateDiscoveryServicesCollection()
        {
            var c = new ObservableCollection<DiscoInfo>();
            //c.CollectionChanged += (s, e) =>
            //{
            //    RaisePropertyChanged(Property.DiscoveredServices);
            //};
            return c;
        }





        /// <summary>
        /// Determines whether this instance can refresh.
        /// </summary>
        /// <returns><c>true</c> if this instance can refresh; otherwise, <c>false</c>.</returns>
        public bool CanRefresh()
        {
            return !IsBusy;
        }


        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        [Command(Name="Refresh", CanExecuteMethodName = "CanRefresh", UseCommandManager = true)]
        public void GetAllEndpoints()
        {
            try
            {
                ExceptionMessage = "";
                swRequest.Start();
                _timer.Stop();
                IsBusy = true;
                MonitorDiscoPortal
                    .Agent
                    .GetAllEndpointsAsync(OnGetAllEndpointsAsyncCompleted);
            }
            catch
            {
                IsBusy = false;
                IsEmpty = true;
            }
        }


        /// <summary>
        /// The _discovered services
        /// </summary>
        private ObservableCollection<DiscoInfo> _discoveredServices;

        private string _exceptionMessage;

        /// <summary>
        /// Gets or sets the discovered services.
        /// </summary>
        /// <value>The discovered services.</value>
        public ObservableCollection<DiscoInfo> DiscoveredServices
        {
            get
            {
                return _discoveredServices;
            }
            set 
            {
                _discoveredServices = value;
                RaisePropertyChanged(Property.DiscoveredServices);
            }
        }



        /// <summary>
        /// Called when [get all endpoints async completed].
        /// </summary>
        /// <param name="items">The items.</param>
        public void OnGetAllEndpointsAsyncCompleted(DiscoInfo[] items)
        {
            MergeItems(items);
            RaisePropertyChanged(Property.DiscoveredServices);
            IsBusy = false;
            _timer.Start();
            swRequest.Stop();
            RaisePropertyChanged(Property.RequestDuration);
            swRequest.Reset();
        }

        /// <summary>
        /// Merges the items.
        /// </summary>
        /// <param name="items">The items.</param>
        private void MergeItems(DiscoInfo[] items)
        {
            if (items != null)
            {
                foreach (var it in items)
                {
                    var found = FindIn(DiscoveredServices, it);
                    if (found != null)
                    {
                        found.Status = DiscoStatus.Online;
                    }
                    else
                    {
                        it.Status = DiscoStatus.Discovered;
                        DiscoveredServices.Add(it);
                    }
                }
                foreach (var it in from it in DiscoveredServices 
                                   let found = FindIn(items, it) 
                                   where found == null select it)
                {
                    it.Status = DiscoStatus.Offline;
                }
            }
            RaisePropertyChanged(Property.DiscoveredServices);
        }

        /// <summary>
        /// Sets all unknown.
        /// </summary>
        private void SetAllUnknown()
        {
            foreach (var it in DiscoveredServices)
                it.Status = DiscoStatus.Unknown;
            RaisePropertyChanged(Property.DiscoveredServices);
        }

        /// <summary>
        /// Finds the specified it.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="it">It.</param>
        /// <returns>DiscoViewItem.</returns>
        private DiscoInfo FindIn(IEnumerable<DiscoInfo> list,   DiscoInfo it)
        {
            try
            {
                return list.First(i => i.Equals(it));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            GetAllEndpoints();
        }
    }
}
