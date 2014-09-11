using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Interfaces;

namespace Broobu.Taxonomy.Contract.Domain
{
    public  partial class Hook :  ITranslatable
    {
        /// <summary>
        /// The _data culture
        /// </summary>
        string _dataCulture;

        /// <summary>
        /// Gets or sets the data culture.
        /// </summary>
        /// <value>The data culture.</value>
        [DataMember]
        public string DataCulture
        {
            get
            {
                return _dataCulture;
            }
            set
            {
                if (_dataCulture != value)
                {
                    _dataCulture = value;
                    RaisePropertyChanged("DataCulture");
                }
            }
        }


        /// <summary>
        /// The _descriptions
        /// </summary>
        private Description _description;

        /// <summary>
        /// Gets or sets the descriptions.
        /// </summary>
        /// <value>The descriptions.</value>
        [DataMember]
        public IDescription Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value == null) return;
                _description = (Description) value;
                RaisePropertyChanged("Description");
            }
        }
        


        private void AddDefaultDescriptions()
        {
            var res = TaxonomyPortal
                .Descriptions
                .GetDescriptionsForObject(ObjectId, DataCulture);
            foreach (var description in res)
            {
                AddPart(description);
            }
        }




    }
}
