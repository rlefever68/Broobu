using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    public abstract class EcoSpaceChildViewModel : FxViewModelBase
    {
        private IEcoSpaceDocument _ecoSpaceDocument;


        /// <summary>
        /// Initializes a new instance of the <see cref="ManageRolesViewModel"/> class.
        /// </summary>
        public EcoSpaceChildViewModel()
        {
            Messenger.Default.Register<EcoSpaceMvvmMessage>(this, m =>
            {
                EcoSpace = m.EcoSpaceDocument;
            });
        }

        /// <summary>
        /// Gets or sets the eco space document.
        /// </summary>
        /// <value>The eco space document.</value>
        public IEcoSpaceDocument EcoSpace
        {
            get 
            { 
                return _ecoSpaceDocument; 
            }
            set 
            {
                if (value == null) return;
                _ecoSpaceDocument = value;
                RaisePropertyChanged("EcoSpace");
                OnEcoSpaceChanged();

            }
        }


        protected abstract void OnEcoSpaceChanged();
    }
}
