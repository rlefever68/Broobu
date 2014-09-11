using System.Collections.ObjectModel;
using System.Windows.Input;
using Broobu.Authentication.UI.Controls;
using Broobu.Boutique.Contract.Domain;
using DevExpress.Mvvm.DataAnnotations;
using Iris.Fx.Utils;

namespace Broobu.Desktop.UI.Controls
{
    /// <summary>
    /// Class BoutiqueOptionsViewModel.
    /// </summary>
    [POCOViewModel]
    public class BoutiqueOptionsViewModel : AuthenticatedViewModel
    {



        /// <summary>
        /// Class Property.
        /// </summary>
        public new class Property
        {
            /// <summary>
            /// The boutique options
            /// </summary>
            public const string BoutiqueOptions = "BoutiqueOptions";
        }

        /// <summary>
        /// The XML configuration path
        /// </summary>
        public const string XmlConfigPath = "BoutiqueOptions.xml";



        /// <summary>
        /// The _ boutique options
        /// </summary>
        private ObservableCollection<BoutiqueOption> _BoutiqueOptions;
        /// <summary>
        /// Gets or sets the boutique options.
        /// </summary>
        /// <value>The boutique options.</value>
        public ObservableCollection<BoutiqueOption> BoutiqueOptions
        {
            get
            {
                return _BoutiqueOptions;
            }
            set
            {
                _BoutiqueOptions = value;
                RaisePropertyChanged(Property.BoutiqueOptions);
            }
        }



        /// <summary>
        /// Initializes the internal.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        protected override void InitializeInternal(object[] parameters)
        {
            LoadBoutiqueOptions();
        }

        /// <summary>
        /// Loads the boutique options.
        /// </summary>
        [Command(Name = "Reload")]
        public void LoadBoutiqueOptions()
        {
            BoutiqueOptions = DomainSerializer<ObservableCollection<BoutiqueOption>>
                .Deserialize(XmlConfigPath);
        }


        /// <summary>
        /// Saves the boutique options.
        /// </summary>
        [Command(Name = "Save")]
        public void SaveBoutiqueOptions()
        {
            DomainSerializer<ObservableCollection<BoutiqueOption>>
                .Serialize(BoutiqueOptions, XmlConfigPath);
        }


    }
}
