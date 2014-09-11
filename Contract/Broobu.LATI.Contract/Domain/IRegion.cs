using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.LATI.Contract.Domain
{
    public interface IRegion : ITaxonomyObject
    {
        /// <summary>
        /// Gets or sets the name of the currency english.
        /// </summary>
        /// <value>The name of the currency english.</value>
        [DataMember]
        string CurrencyEnglishName { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency native.
        /// </summary>
        /// <value>The name of the currency native.</value>
        [DataMember]
        string CurrencyNativeName { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>The currency symbol.</value>
        [DataMember]
        string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the name of the english.
        /// </summary>
        /// <value>The name of the english.</value>
        [DataMember]
        string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the geo identifier.
        /// </summary>
        /// <value>The geo identifier.</value>
        [DataMember]
        int GeoId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is metric.
        /// </summary>
        /// <value><c>true</c> if this instance is metric; otherwise, <c>false</c>.</value>
        [DataMember]
        bool IsMetric { get; set; }

        /// <summary>
        /// Gets or sets the iso currency symbol.
        /// </summary>
        /// <value>The iso currency symbol.</value>
        [DataMember]
        string ISOCurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the native.
        /// </summary>
        /// <value>The name of the native.</value>
        [DataMember]
        string NativeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the three letter iso region.
        /// </summary>
        /// <value>The name of the three letter iso region.</value>
        [DataMember]
        string ThreeLetterISORegionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the three letter windows region.
        /// </summary>
        /// <value>The name of the three letter windows region.</value>
        [DataMember]
        string ThreeLetterWindowsRegionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the two letter iso region.
        /// </summary>
        /// <value>The name of the two letter iso region.</value>
        [DataMember]
        string TwoLetterISORegionName { get; set; }
    }
}