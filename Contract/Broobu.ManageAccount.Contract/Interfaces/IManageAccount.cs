using System;
using System.ServiceModel;
using Pms.Framework.Domain;
using Pms.ManageAccount.Contract.Domain;


namespace Pms.ManageAccount.Contract.Interfaces
{
    [ServiceContract(Namespace=ServiceConst.Namespace)]
    public interface IManageAccount
    {
        [OperationContract]
        AccountViewItem[] GetAccounts();
    }
}
