using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Fx.UI.Dialogs;
using Iris.Fx.Domain;

namespace Broobu.Fx.UI.MVVM
{

    public class ExploreViewModel : FxViewModelBase
    {
        public IComposedObject Root { get; set; }

        protected override void InitializeInternal(object[] parameters)
        {
            ServiceContainer.RegisterService(new ExploreDialog());
        }
        


    }
}
