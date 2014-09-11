using System;
using DevExpress.Xpf.Grid;
using Pms.Authentication.UI.Controls;
using Pms.Framework.Domain;
using Pms.Framework.UI;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Pms.ManageDiagnostics.Contract.Agent;
using Pms.ManageDiagnostics.Contract.Domain;

namespace Pms.ManageDiagnostics.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class DiagnosticsViewModel : AuthenticatedViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public new class Property
        {
            /// <summary>
            /// 
            /// </summary>
            public const string DiagnosticsReport = "DiagnosticsReport";
            /// <summary>
            /// 
            /// </summary>
            public const string RequestDuration = "RequestDuration";
            /// <summary>
            /// 
            /// </summary>
            public const string BatchDate = "BatchDate";
            /// <summary>
            /// 
            /// </summary>
            public const string Batches = "Batches";
            /// <summary>
            /// 
            /// </summary>
            public const string BatchIndex = "BatchIndex";

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Stopwatch swRequest;


        /// <summary>
        /// Gets the duration of the request.
        /// </summary>
        /// <remarks></remarks>
        public string RequestDuration
        {
            get
            {
                return String.Format("{0:F1} seconds", swRequest.Elapsed.TotalSeconds);
            }
        }


        private DiagnosticsBatchViewItem _focusedBatch;
        public DiagnosticsBatchViewItem FocusedBatch
        {
            get { return _focusedBatch; }
            set 
            { 
                _focusedBatch = value; 
                GetDiagnosticsReport();
            }
        }

        /// <summary>
        /// Gets or sets the refresh.
        /// </summary>
        /// <value>The refresh.</value>
        /// <remarks></remarks>
        public ICommand Refresh {get;set;}

        /// <summary>
        /// Gets or sets the run diagnostics.
        /// </summary>
        /// <value>The run diagnostics.</value>
        /// <remarks></remarks>
        public ICommand RunDiagnostics { get; set; }

        /// <summary>
        /// Gets or sets the refresh time span.
        /// </summary>
        /// <value>The refresh time span.</value>
        /// <remarks></remarks>
        public TimeSpan RefreshTimeSpan
        {
            get
            {
                return tmr.Interval;
            }
            set
            {
                tmr.Interval = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private DispatcherTimer tmr;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticsViewModel"/> class.
        /// </summary>
        /// <remarks></remarks>
        public DiagnosticsViewModel()
        {
            Refresh = new DelegateCommand(GetDiagnosticsBatches);
            RunDiagnostics = new DelegateCommand(StartDiagnosticsRun);
            Batches = new ObservableCollection<DiagnosticsBatchViewItem>();
            DiagnosticsReport = new ObservableCollection<DiagnosticsViewItem>();
            tmr = CreateRefreshTimer();
            swRequest = new Stopwatch();
        }

        /// <summary>
        /// Creates the refresh timer.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private DispatcherTimer CreateRefreshTimer()
        {
            var timer = new DispatcherTimer();
            timer.Tick += (s, e) => GetDiagnosticsReport();
            timer.Interval = TimeSpan.FromSeconds(1*60);
            return timer;
        }

      


        /// <summary>
        /// Starts the diagnostics run.
        /// </summary>
        /// <remarks></remarks>
        private void StartDiagnosticsRun()
        {
            ManageDiagnosticsAgentFactory
                .CreateManageDiagnosticsAgent()
                .StartDiagnosticsAsync(OnStartDiagnosticsCompleted);
        }


        private void OnStartDiagnosticsCompleted(Result result)
        {
            if(!result.HasErrors)
                GetDiagnosticsBatches();
        }


        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        /// <remarks></remarks>
        protected override void InitializeInternal(object[] parameters)
        {
            GetDiagnosticsBatches();
        }


        private ObservableCollection<DiagnosticsBatchViewItem> _batches;
        public ObservableCollection<DiagnosticsBatchViewItem> Batches 
        { 
            get { return _batches; }
            set 
            { 
                _batches = value; 
                RaisePropertyChanged(Property.Batches);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private DateTime _batchDate = DateTime.Now;
        /// <summary>
        /// Gets or sets the batch date.
        /// </summary>
        /// <value>The batch date.</value>
        /// <remarks></remarks>
        public DateTime BatchDate 
        { 
            get { return _batchDate; }
            set
            {
                if (_batchDate == value) return;
                _batchDate = value;
                RaisePropertyChanged(Property.BatchDate);
            }
        }



        /// <summary>
        /// Gets the diagnostics report.
        /// </summary>
        /// <remarks></remarks>
        private void GetDiagnosticsReport()
        {
            try
            {
                swRequest.Start();
                tmr.Stop();
                IsBusy = true;
                if(FocusedBatch!=null)
                    ManageDiagnosticsAgentFactory
                        .CreateManageDiagnosticsAgent()
                        .GetDiagnosticsReportAsync(FocusedBatch.Id,OnGetDiagnosticsReportCompleted);

            }
            catch
            {
                IsBusy = false;
                IsEmpty = true;
            }
        }



        /// <summary>
        /// Gets the diagnostics batches.
        /// </summary>
        /// <remarks></remarks>
        private void GetDiagnosticsBatches()
        {
            try
            {
                IsBusy = true;
                IsEmpty = false;
                ManageDiagnosticsAgentFactory
                    .CreateManageDiagnosticsAgent()
                    .GetDiagnosticsReportsByDateAsync(BatchDate, OnGetDiagnosticsBatchesCompleted);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                IsEmpty = true;
            }
        }







        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<DiagnosticsViewItem> _diagnosticsReport;

        /// <summary>
        /// Gets or sets the discovered services.
        /// </summary>
        /// <value>The discovered services.</value>
        /// <remarks></remarks>
        public ObservableCollection<DiagnosticsViewItem> DiagnosticsReport
        {
            get
            {
                return _diagnosticsReport;
            }
            set 
            {
                _diagnosticsReport = value;
                RaisePropertyChanged(Property.DiagnosticsReport);
            }
        }



        /// <summary>
        /// Called when [get all endpoints async completed].
        /// </summary>
        /// <param name="items">The items.</param>
        /// <remarks></remarks>
        public void OnGetDiagnosticsReportCompleted(DiagnosticsViewItem[] items)
        {
            MergeDiagnosticsViewItems(items);
            RaisePropertyChanged(Property.DiagnosticsReport);
            IsBusy = false;
            tmr.Start();
            swRequest.Stop();
            RaisePropertyChanged(Property.RequestDuration);
            swRequest.Reset();
        }

        /// <summary>
        /// Merges the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <remarks></remarks>
        private void MergeDiagnosticsViewItems(IEnumerable<DiagnosticsViewItem> items)
        {
            if (items != null)
            {
                foreach (var it in items)
                {
                    var found = FindIn(DiagnosticsReport, it);
                    if (found == null)
                    {
                        DiagnosticsReport.Add(it);
                    }
                    else
                    {
                        found.Status = it.Status;
                    }
                }
            }
            RaisePropertyChanged(Property.DiagnosticsReport);
        }


        /// <summary>
        /// Finds the specified it.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="it">It.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private DiagnosticsViewItem FindIn(IEnumerable<DiagnosticsViewItem> list, DiagnosticsViewItem it)
        {
            try
            {
                return list
                    .Where(i => i.Equals(it))
                    .First();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Called when [get diagnostics batches completed].
        /// </summary>
        /// <param name="items">The items.</param>
        /// <remarks></remarks>
        public void OnGetDiagnosticsBatchesCompleted(DiagnosticsBatchViewItem[] items)
        {
            IsEmpty = true;
            IsBusy = false;
            if (items == null) return;
            IsEmpty = (items.Count() == 0);
            Batches.Clear();
            foreach (var diagnosticsBatchViewItem in items)
            {
                Batches.Add(diagnosticsBatchViewItem);
            }
            RaisePropertyChanged(Property.Batches);
        }
    }
}
