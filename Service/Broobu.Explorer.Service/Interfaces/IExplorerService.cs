using System;
using System.ServiceModel;
using Pms.Explorer.Contract.Domain;

namespace Pms.Explorer.Service.Interfaces
{
    [ServiceContract]
    public interface IExplorerService
    {
        [OperationContract]
        EnumerationItem[] GetEnumerationsForType(string typeId);
        [OperationContract]
        EnumerationPropertyItem[] GetPropertiesForType(string typeId);
        [OperationContract]
        EnumerationPropertyItem[] GetPropertiesForEnumeration(String enumerationId); 
    }
}
