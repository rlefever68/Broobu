using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Fx.UI.Windows;
using DevExpress.Mvvm;
using Iris.Fx.Domain;
using Iris.Fx.Interfaces;

namespace Broobu.Fx.UI.Dialogs
{
    public class ExploreDialog : IDialogService
    {
        private static ExplorerWindow _wnd;
        private static ExplorerWindow Window
        {
            get { return _wnd ?? (_wnd = new ExplorerWindow()); }
        }

        public static IDomainObject Execute(IComposedObject root)
        {
            Window.Root = root;
        }

        public UICommand ShowDialog(IEnumerable<UICommand> dialogCommands, string title, string documentType, object viewModel, object parameter,
            object parentViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
