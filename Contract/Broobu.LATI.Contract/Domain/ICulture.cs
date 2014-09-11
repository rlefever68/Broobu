using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.LATI.Contract.Domain
{
    public interface ICulture : ITaxonomyObject
    {
        /// <summary>
        /// Gets or sets the name of the english.
        /// </summary>
        /// <value>The name of the english.</value>
        [DataMember]
        string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the lcid.
        /// </summary>
        /// <value>The lcid.</value>
        [DataMember]
        int LCID { get; set; }

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
        /// Gets or sets the name of the three letter iso language.
        /// </summary>
        /// <value>The name of the three letter iso language.</value>
        [DataMember]
        string ThreeLetterISOLanguageName { get; set; }

        /// <summary>
        /// Gets or sets the name of the three letter windows language.
        /// </summary>
        /// <value>The name of the three letter windows language.</value>
        [DataMember]
        string ThreeLetterWindowsLanguageName { get; set; }

        /// <summary>
        /// Gets or sets the name of the two letter windows language.
        /// </summary>
        /// <value>The name of the two letter windows language.</value>
        [DataMember]
        string TwoLetterWindowsLanguageName { get; set; }
    }
}