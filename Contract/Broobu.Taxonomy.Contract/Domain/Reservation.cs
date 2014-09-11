using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Wulka.Domain.Interfaces;

namespace Broobu.Taxonomy.Contract.Domain
{
    [DataContract]
    public class Reservation : Link, IReservation
    {
        public TimeSpan TimeSpan { get; set; }
    }
}
