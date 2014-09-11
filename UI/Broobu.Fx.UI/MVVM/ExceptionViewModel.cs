using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.WindowsUI.Navigation;
using NLog;

namespace Broobu.Fx.UI.MVVM
{
    public class ExceptionViewModel : FxViewModelBase, INavigationAware
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private Exception _exception;

        public ExceptionViewModel()
        {
            Messenger.Default.Register<ExceptionMvvmMsg>(this, m => { Exception = m.Exception; });
        }

        public Exception Exception
        {
            get { return _exception; }
            set
            {
                _exception = value;
                RaisePropertyChanged("Exception");
            }
        }


        public void NavigatedTo(NavigationEventArgs e)
        {
            _logger.Info("Navigate to ExecptionView, {0}", e.Content);
            if (e.Parameter is Exception)
            {
                Exception = e.Parameter as Exception;
            }
        }

        public void NavigatingFrom(NavigatingEventArgs e)
        {
        }

        public void NavigatedFrom(NavigationEventArgs e)
        {
        }

        protected override void InitializeInternal(object[] parameters)
        {
        }

        [Command(Name = "GoBack", UseCommandManager = true)]
        public void GoBack()
        {
            Messenger.Default.Send(new GoBackMvvmMessage());
        }
    }
}