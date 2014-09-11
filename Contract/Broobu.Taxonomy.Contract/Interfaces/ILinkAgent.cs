using System;
using System.Collections.Generic;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using ILink = Wulka.Domain.Interfaces.ILink;

namespace Broobu.Taxonomy.Contract.Interfaces
{
    public interface ILinkAgent : ITaxoLinks
    {
        void ActivateAsync(ILink link, Action<ILink> act=null);
        void DeactivateAsync(ILink link, Action<ILink> act=null);
        void GetTargetsAsync(ILink link, bool activeOnly = true, Action<IEnumerable<ILink>> act=null);
        void GetSourcesAsync(ILink link, bool activeOnly = true, Action<IEnumerable<ILink>> act=null);

    }
}