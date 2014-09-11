using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using Iris.Authentication.UI.Controls;
using Iris.Fx.UI;
using Iris.MonitorSession.Contract.Agent;
using Iris.MonitorSession.Contract.Domain;
using Iris.MonitorSession.Contract.Interfaces;

namespace Iris.MonitorSession.UI.Controls
{

    public class SessionViewItemViewModel : AuthenticatedViewModel
    {


        private new  class Property
        {
            public const string Sessions = "Sessions";
        }



        public ObservableCollection<SessionViewItem> Sessions { get; set; }


        private IMonitorSessionAgent _agt;
        private IMonitorSessionAgent Agent
        {
            get
            {
                if(_agt==null)
                    _agt = CreateAgent();
                return _agt;
            }
        }

        /// <summary>
        /// Creates the agent.
        /// </summary>
        /// <returns></returns>
        private IMonitorSessionAgent CreateAgent()
        {
            var agt = MonitorSessionAgentFactory.CreateAgent();
            agt.GetSessionsCompleted += (lst) =>
            {
                IsBusy = false;
                UpdateSessions(lst);
                IsEmpty = (!lst.Any());
            };
            return agt;
        }



        DispatcherTimer _tmr;


        /// <summary>
        /// Initializes a new instance of the <see cref="SessionViewItemViewModel"/> class.
        /// </summary>
        public SessionViewItemViewModel()
        { 
            Sessions = new ObservableCollection<SessionViewItem>();
            _tmr = new DispatcherTimer();
            _tmr.Interval = TimeSpan.FromMinutes(10);
            _tmr.Tick += (s, e) => { Refresh(); };
            RefreshCmd = new DelegateCommand(() => { Refresh(); });
        }


        public ICommand RefreshCmd { get; set; }


        /// <summary>
        /// Updates the sessions.
        /// </summary>
        /// <param name="lst">The LST.</param>
        private void UpdateSessions(SessionViewItem[] lst)
        {
            _tmr.Stop();
            Sessions.Clear();
            foreach (var it in lst)
            {
                Sessions.Add(it);
            }
            RaisePropertyChanged(Property.Sessions);
            _tmr.Start();
        }




        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            Refresh();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        private void Refresh()
        {
            IsBusy = true;
            Agent.GetSessionsAsync();
        }





    }


}
