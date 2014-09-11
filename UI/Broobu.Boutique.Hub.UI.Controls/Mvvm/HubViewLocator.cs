using System;
using System.Collections.Generic;
using System.Reflection;
using Broobu.Authentication.UI.Controls.Views;
using Broobu.Boutique.Hub.UI.Controls.Views;
using Broobu.Fx.UI.Views;
using DevExpress.Mvvm.UI;

namespace Broobu.Boutique.Hub.UI.Controls.Mvvm
{
    public class HubViewLocator : ViewLocatorBase
    {

        public object ResolveView(string name)
        {
            if (name == WaitView.ID) return new WaitView();
            if (name == AppHostView.ID) return new AppHostView();
            if (name == ExceptionView.ID) return new ExceptionView();
            if (name == LoginView.ID) return new LoginView();
            if (name == MenuView.ID) return new MenuView();
            return (name == RegisterUserView.ID)
                ? new RegisterUserView()
                : null;
        }

        protected override IEnumerable<Assembly> Assemblies
        {
            get { return AppDomain.CurrentDomain.GetAssemblies(); }
        }


    }
}