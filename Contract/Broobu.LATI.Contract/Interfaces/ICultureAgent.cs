using System;
using System.Collections.Generic;
using Broobu.LATI.Contract.Domain;

namespace Broobu.LATI.Contract.Interfaces
{
    public interface ICultureAgent 
    {
        ICultureDocument GetById(string id);
        void GetCultureDocumentAsync(string id, Action<ICultureDocument> act = null);
        void GetRegionsAsync(string id, Action<IEnumerable<IRegion>> action=null);
        void GetCulturesAsync(string id, Action<IEnumerable<ICulture>> action = null);
    }
}
