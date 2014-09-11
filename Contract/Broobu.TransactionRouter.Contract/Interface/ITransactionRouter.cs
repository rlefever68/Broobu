using System.ServiceModel;
using Pms.TransactionRouter.Contract.Domain;

namespace Pms.TransactionRouter.Contract.Interface
{
    [ServiceContract(Namespace = TransactionRouterConst.Namespace)]
    public interface ITransactionRouter
    {
        [OperationContract(IsOneWay = true)]
        void SubmitTransactionFile(TransactionFileItem transactionFile);
    }
}
