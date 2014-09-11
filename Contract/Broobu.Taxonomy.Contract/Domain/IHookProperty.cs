using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.Taxonomy.Contract.Domain
{
    public interface IHookProperty : IDomainObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the type identifier for the DataType of this property.
        /// </summary>
        /// <value>The type identifier.</value>
        [DataMember]
        string TypeId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [DataMember]
        string Value { get; set; }
    }
}