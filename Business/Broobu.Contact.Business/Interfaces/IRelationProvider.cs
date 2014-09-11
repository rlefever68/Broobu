using Broobu.Contact.Contract.Interfaces;

namespace Broobu.Contact.Business.Interfaces
{
    public interface IRelationProvider : IRelation
    {
        void RegisterRequiredObjects();
    }
}