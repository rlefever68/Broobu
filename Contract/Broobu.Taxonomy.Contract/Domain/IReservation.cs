using System;
using System.Runtime.Serialization;
using Wulka.Domain.Interfaces;

namespace Broobu.Taxonomy.Contract.Domain
{
    public interface IReservation : ILink
    {
        [DataMember]
        TimeSpan TimeSpan { get; set; }
    }
}