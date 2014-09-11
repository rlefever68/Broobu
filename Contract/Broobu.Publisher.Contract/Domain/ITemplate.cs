using System;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.Publisher.Contract.Domain
{
    public interface ITemplate : ITaxonomyObject
    {
        string TemplateBody { get; set; }
    }
}
