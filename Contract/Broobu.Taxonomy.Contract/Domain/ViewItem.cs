using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.Taxonomy.Contract.Domain
{

    [DataContract]
    public abstract class ViewItem : DomainObject<ViewItem>
    {
        [DataMember]
        public ViewLabel[] Labels { get;set; }
    }
}
