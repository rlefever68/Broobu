using Iris.Fx.Domain;


namespace Iris.SimpleDb.Adapter.Domain
{
    public abstract class SimpleDbDomainObject<T> : DomainObject<SimpleDbDomainObject<T>>
    {
        public ResponseMetadataInfo Metadata = new ResponseMetadataInfo();
    }
}
