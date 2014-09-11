using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broobu.LATI.Contract.Domain;

namespace Broobu.LATI.Contract.Interfaces
{
    public interface ILatiAgent 
    {
        LocationLog RegisterLocation(LocationLog logItem);
        PointOfInterest GetPointOfInterest(string poIId);
    }
}
