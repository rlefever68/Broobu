using System;
using System.Collections.Generic;
using System.Text;
using Broobu.LATI.Contract.Domain;
using Broobu.LATI.Contract.Interfaces;

namespace Broobu.LATI.Business.Interfaces
{
    public interface ILatis : ILatiAgent
    {
        void InflateDomain();
    }
}
