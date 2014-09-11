using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.SimpleDb.Adapter.Domain;

namespace Iris.SimpleDb.Adapter.Mappers
{
    public abstract class SimpleDbMapperHelperBase<TInfo, TRequest, TResponse> 
        where TInfo : SimpleDbDomainObject<TInfo>
    {
        public abstract TRequest MapToService(TInfo info);
        public abstract TInfo MapToInfo(TResponse resp);

    }
}
