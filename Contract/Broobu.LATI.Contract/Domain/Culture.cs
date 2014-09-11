// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 01-13-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-13-2014
// ***********************************************************************
// <copyright file="Culture.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.LATI.Contract.Domain
{
    /// <summary>
    /// Class Culture.
    /// </summary>
    [DataContract]
    public class Culture : TaxonomyObject<Culture>, ICulture
    {


        /// <summary>
        /// Class Property.
        /// </summary>
        public class Property
        {
            /// <summary>
            /// The display name
            /// </summary>
            public const string DisplayName = "DisplayName";
            /// <summary>
            /// The english name
            /// </summary>
            public const string EnglishName = "EnglishName";
            /// <summary>
            /// The ietf language tag
            /// </summary>
            public const string IetfLanguageTag = "IetfLanguageTag";
            /// <summary>
            /// The lcid
            /// </summary>
            public const string LCID = "LCID";
            /// <summary>
            /// The is neutral culture
            /// </summary>
            public const string IsNeutralCulture = "IsNeutralCulture";
        }

        /// <summary>
        /// The _three letter iso language name
        /// </summary>
        private string _threeLetterIsoLanguageName;
        /// <summary>
        /// The _native name
        /// </summary>
        private string _nativeName;
        /// <summary>
        /// The _name
        /// </summary>
        private string _name;
        /// <summary>
        /// The _lcid
        /// </summary>
        private int _lcid;
        /// <summary>
        /// The _is neutral culture
        /// </summary>
        private bool _isNeutralCulture;
        /// <summary>
        /// The _ ietf language tag
        /// </summary>
        private string _IetfLanguageTag;
        /// <summary>
        /// The _english name
        /// </summary>
        private string _englishName;
        /// <summary>
        /// The _display name
        /// </summary>
        private string _displayName;
        /// <summary>
        /// The _three letter windows language name
        /// </summary>
        private string _threeLetterWindowsLanguageName;
        /// <summary>
        /// The _two letter windows language name
        /// </summary>
        private string _twoLetterWindowsLanguageName;


        /// <summary>
        /// Gets or sets the name of the english.
        /// </summary>
        /// <value>The name of the english.</value>
        [DataMember]
        public string EnglishName
        {
            get { return _englishName; }
            set
            {
                _englishName = value;
                RaisePropertyChanged(Property.EnglishName);
            }
        }

        /// <summary>
        /// Gets or sets the ietf language tag.
        /// </summary>
        /// <value>The ietf language tag.</value>
        [DataMember]
        public string IetfLanguageTag
        {
            get { return _IetfLanguageTag; }
            set
            {
                _IetfLanguageTag = value;
                RaisePropertyChanged(Property.IetfLanguageTag);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is neutral culture.
        /// </summary>
        /// <value><c>true</c> if this instance is neutral culture; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool IsNeutralCulture
        {
            get { return _isNeutralCulture; }
            set
            {
                _isNeutralCulture = value;
                RaisePropertyChanged(Property.IsNeutralCulture);
            }
        }

        /// <summary>
        /// Gets or sets the lcid.
        /// </summary>
        /// <value>The lcid.</value>
        [DataMember]
        public int LCID
        {
            get { return _lcid; }
            set
            {
                _lcid = value;
                RaisePropertyChanged(Property.LCID);
            }
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
        /// Gets or sets the name of the three letter iso language.
        /// </summary>
        /// <value>The name of the three letter iso language.</value>
        [DataMember]
        public string ThreeLetterISOLanguageName
        {
            get { return _threeLetterIsoLanguageName; }
            set
            {
                _threeLetterIsoLanguageName = value;
                RaisePropertyChanged("ThreeLetterISOLanguageName");
            }
        }

        /// <summary>
        /// Gets or sets the name of the three letter windows language.
        /// </summary>
        /// <value>The name of the three letter windows language.</value>
        [DataMember]
        public string ThreeLetterWindowsLanguageName
        {
            get { return _threeLetterWindowsLanguageName; }
            set
            {
                _threeLetterWindowsLanguageName = value;
                RaisePropertyChanged("ThreeLetterWindowsLanguageName");
            }
        }

        /// <summary>
        /// Gets or sets the name of the two letter windows language.
        /// </summary>
        /// <value>The name of the two letter windows language.</value>
        [DataMember]
        public string TwoLetterWindowsLanguageName
        {
            get { return _twoLetterWindowsLanguageName; }
            set
            {
                _twoLetterWindowsLanguageName = value;
                RaisePropertyChanged("TwoLetterWindowsLanguageName");
            }
        }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Culture>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Culture>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
    }
}
