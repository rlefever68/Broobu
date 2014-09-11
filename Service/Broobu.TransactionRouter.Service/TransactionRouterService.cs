using System;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using log4net;
using Pms.Framework.Domain;
using Pms.Framework.Interfaces;
using Pms.Framework.Transactions;

namespace Pms.TransactionRouter.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class TransactionRouterService : ITransactionRouter
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILog _logger;

        private readonly ITransactionRouterProviderFactory _fact = CreateProviderFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public TransactionRouterService()
        {
            _logger = LogManager.GetLogger(GetType()); 
            _logger.InfoFormat("Hello");
        }

        /// <summary>
        /// Submits the transaction file.
        /// </summary>
        /// <param name="transactionFile">The transaction file.</param>
        /// <remarks></remarks>
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitTransactionFile(TransactionFileItem transactionFile)
        {
            try
            {
                _logger.InfoFormat("Received SubmitTransactionFile Request");
                _fact
                    .CreateRouter()
                    .SubmitTransactionFile(transactionFile); 
            }
            catch (Exception ex)
            {
                string s = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                _logger.ErrorFormat(s);
            }
        }

        /// <summary>
        /// Creates the provider factory.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private static ITransactionRouterProviderFactory CreateProviderFactory()
        {
            var assembly = Assembly.LoadFrom(TransactionRouterConfigurationHelper.PluginAssemblyLocation);
            var types = assembly.GetTypes();
            return (from type in types
                    where type.BaseType == typeof (TransactionRouterProviderFactoryBase)
                    select (TransactionRouterProviderFactoryBase) Activator.CreateInstance(type)).FirstOrDefault();
        }
    }
}
