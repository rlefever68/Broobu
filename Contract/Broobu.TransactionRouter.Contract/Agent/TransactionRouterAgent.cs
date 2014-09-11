using Pms.Framework.Domain;
using Pms.Framework.Networking.Wcf;
using Pms.TransactionRouter.Contract.Domain;
using Pms.TransactionRouter.Contract.Interface;
using Pms.Framework.Interfaces;

namespace Pms.TransactionRouter.Contract.Agent
{
    public class TransactionRouterAgent : DiscoProxy<ITransactionRouter>, ITransactionRouterAgent
    {

        public void SubmitTransactionFile(TransactionFileItem transactionFile)
        {
            Client.SubmitTransactionFile(transactionFile);
        }


        protected override string GetContractNamespace()
        {
            return TransactionRouterConst.Namespace;
        }
    }
}
