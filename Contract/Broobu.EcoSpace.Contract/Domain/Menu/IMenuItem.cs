using System;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{
    public interface IMenuItem : ITaxonomyObject
    {
        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>The tool tip.</value>
        [DataMember]
        String ToolTip { get; set; }
    }
}