using System.ServiceModel;
using Broobu.Boutique.Contract.Domain;


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
