// ***********************************************************************
// Assembly         : Broobu.LATI.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="Region.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.LATI.Contract.Domain
{
    /// <summary>
    /// Class Region.
    /// </summary>
    [DataContract]
    public class Region : TaxonomyObject<Region>, IRegion
    {
        /// <summary>
        /// The _currency english name
        /// </summary>
        private string _currencyEnglishName;
        /// <summary>
        /// The _currency native name
        /// </summary>
        private string _currencyNativeName;
        /// <summary>
        /// The _currency symbol
        /// </summary>
        private string _currencySymbol;
        /// <summary>
        /// The _display name
        /// </summary>
        private string _displayName;
        /// <summary>
        /// The _english name
        /// </summary>
        private string _englishName;
        /// <summary>
        /// The _geo identifier
        /// </summary>
        private int _geoId;
        /// <summary>
        /// The _is metric
        /// </summary>
        private bool _isMetric;
        /// <summary>
        /// The _iso currency symbol
        /// </summary>
        private string _isoCurrencySymbol;
        /// <summary>
        /// The _name
        /// </summary>
        private string _name;
        /// <summary>
        /// The _native name
        /// </summary>
        private string _nativeName;
        /// <summary>
        /// The _three letter iso region name
        /// </summary>
        private string _threeLetterIsoRegionName;
        /// <summary>
        /// The _three letter windows region name
        /// </summary>
        private string _threeLetterWindowsRegionName;
        /// <summary>
        /// The _two letter iso region name
        /// </summary>
        private string _twoLetterIsoRegionName;

        /// <summary>
        /// Gets or sets the name of the currency english.
        /// </summary>
        /// <value>The name of the currency english.</value>
        [DataMember]
        public string CurrencyEnglishName
        {
            get { return _currencyEnglishName; }
            set { _currencyEnglishName = value; RaisePropertyChanged("CurrencyEnglishName"); }
        }

        /// <summary>
        /// Gets or sets the name of the currency native.
        /// </summary>
        /// <value>The name of the currency native.</value>
        [DataMember]
        public string CurrencyNativeName
        {
            get { return _currencyNativeName; }
            set { _currencyNativeName = value; RaisePropertyChanged("CurrencyNativeName"); }
        }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>The currency symbol.</value>
        [DataMember]
        public string CurrencySymbol
        {
            get { return _currencySymbol; }
            set { _currencySymbol = value; RaisePropertyChanged("CurrencySymbol"); }
        }


        /// <summary>
        /// Gets or sets the name of the english.
        /// </summary>
        /// <value>The name of the english.</value>
        [DataMember]
        public string EnglishName
        {
            get { return _englishName; }
            set { _englishName = value; RaisePropertyChanged("EnglishName"); }
        }

        /// <summary>
        /// Gets or sets the geo identifier.
        /// </summary>
        /// <value>The geo identifier.</value>
        [DataMember]
        public int GeoId
        {
            get { return _geoId; }
            set { _geoId = value; RaisePropertyChanged("GeoId"); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is metric.
        /// </summary>
        /// <value><c>true</c> if this instance is metric; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool IsMetric
        {
            get { return _isMetric; }
            set { _isMetric = value; RaisePropertyChanged("IsMetric"); }
        }

        /// <summary>
        /// Gets or sets the iso currency symbol.
        /// </summary>
        /// <value>The iso currency symbol.</value>
        [DataMember]
        public string ISOCurrencySymbol
        {
            get { return _isoCurrencySymbol; }
            set { _isoCurrencySymbol = value; RaisePropertyChanged("ISOCurrencySymbol"); }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }

        /// <summary>
        /// Gets or sets the name of the native.
        /// </summary>
        /// <value>The name of the native.</value>
        [DataMember]
        public string NativeName
        {
            get { return _nativeName; }
            set { _nativeName = value; RaisePropertyChanged("NativeName"); }
        }

        /// <summary>
        /// Gets or sets the name of the three letter iso region.
        /// </summary>
        /// <value>The name of the three letter iso region.</value>
        [DataMember]
        public string ThreeLetterISORegionName
        {
            get { return _threeLetterIsoRegionName; }
            set { _threeLetterIsoRegionName = value; RaisePropertyChanged("ThreeLetterISORegionName"); }
        }

        /// <summary>
        /// Gets or sets the name of the three letter windows region.
        /// </summary>
        /// <value>The name of the three letter windows region.</value>
        [DataMember]
        public string ThreeLetterWindowsRegionName
        {
            get { return _threeLetterWindowsRegionName; }
            set { _threeLetterWindowsRegionName = value; RaisePropertyChanged("ThreeLetterWindowsRegionName"); }
        }

        /// <summary>
        /// Gets or sets the name of the two letter iso region.
        /// </summary>
        /// <value>The name of the two letter iso region.</value>
        [DataMember]
        public string TwoLetterISORegionName
        {
            get { return _twoLetterIsoRegionName; }
            set { _twoLetterIsoRegionName = value; RaisePropertyChanged("TwoLetterISORegionName"); }
        }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Region>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Region>.Validate(this);
        }

        /// <summary>
        /// Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
    }
}
