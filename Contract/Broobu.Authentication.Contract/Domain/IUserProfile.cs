using System;
using System.Runtime.Serialization;
using Broobu.LATI.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.Authentication.Contract.Domain
{
    public interface IUserProfile : IComposedObject
    {
        [DataMember]
        ICulture Culture { get; set; }

        [DataMember]
        DateTime DateOfBirth { get; set; }

        [DataMember]
        IRegion Region { get; set; }
    }
}