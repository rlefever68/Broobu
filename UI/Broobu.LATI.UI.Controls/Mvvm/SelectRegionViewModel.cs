using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Fx.UI.MVVM;
using Broobu.LATI.Contract;
using Broobu.LATI.Contract.Domain;

namespace Broobu.LATI.UI.Controls.Mvvm
{
    public class SelectRegionViewModel : FxViewModelBase
    {
        public IRegion SelectedRegion
        {
            get { return _selectedRegion; }
            set { _selectedRegion = value; RaisePropertyChanged("SelectedRegion");}
        }

        private IEnumerable<IRegion> _regions;
        private IRegion _selectedRegion;

        public IEnumerable<IRegion> Regions
        {
            get { return _regions; }
            set { _regions = value; RaisePropertyChanged("Regions"); }
        }

        protected override void InitializeInternal(object[] parameters)
        {
            LatiPortal
                .Cultures
                .GetRegionsAsync(CultureDocument.ID, (r) => { Regions = r; });
        }
    }
}
