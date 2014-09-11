using System;
using System.Collections.Generic;
using Broobu.LATI.Contract.Domain;
using Broobu.LATI.Contract.Interfaces;
using Wulka.Domain;

namespace Broobu.LATI.Business.Interfaces
{
    public interface ICultures 
    {
        CultureDocument InflateDomain();
        ICultureDocument GetById(string id);
        IEnumerable<IRegion> GetRegions(string id);
        IEnumerable<ICulture> GetCultures(string id);
    }
}