using System.Collections.Generic;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.LATI.Contract.Domain
{
    public interface ICultureDocument : ITaxonomyObject
    {
        IEnumerable<IRegion> Regions { get; }
        IEnumerable<ICulture> Cultures { get; }
    }
}