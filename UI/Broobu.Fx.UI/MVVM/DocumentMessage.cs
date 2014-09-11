using Wulka.Domain.Interfaces;

namespace Broobu.Fx.UI.MVVM
{
    public class DocumentMessage<T>
        where T : IDomainObject
    {
        public T Document;
        public object DocumentType;
        public DocumentMessageType MessageType;
    }
}