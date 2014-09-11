using System.ServiceModel;
//using Broobu.Authorization.Contract.Domain;
using Broobu.Boutique.Contract.Domain;
//using Broobu.Taxonomy.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Wulka.Domain;


namespace Broobu.Boutique.Contract.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
   [ServiceContract(Namespace = BoutiqueServiceConst.Namespace)]
    public interface IBoutiqueSentry 
    {
        /// <summary>
        /// Gets the Boutique user info.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
       [OperationContract]
       string GetUserEnvironmentInfo();

    }


   


    




   
}
