using Broobu.Contact.Contract.Interfaces;

namespace Broobu.Contact.Business.Interfaces
{
    public interface IDocumentProvider : IDocument
    {
        void RegisterRequiredObjects();
    }
}