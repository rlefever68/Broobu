using System;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;

namespace Broobu.Taxonomy.Contract.Domain
{
    [DataContract]
    public abstract class LinkContainer : TaxonomyObject<LinkContainer>
    {
        public override IDomainObject AddPart(IDomainObject part)
        {
            if(!(part is ILink))
                throw new Exception(String.Format("[{0}] can only contain objectes of type ILink.", part.GetType().Name));
            return base.AddPart(part);
        }
    }
}
