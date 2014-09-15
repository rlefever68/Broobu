using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.Fx.UI.MVVM;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    public class ManageAppletsViewModel : EcoSpaceChildViewModel
    {
        private AppletContainer _applets;


        public AppletContainer Applets
        {
            get { return _applets; }
            set { _applets = value; RaisePropertyChanged("Applets"); }
        }


        protected override void InitializeInternal(object[] parameters)
        {
            
        }

        protected override void OnEcoSpaceChanged()
        {
            Applets = EcoSpace.Applets;
        }
    }
}
