using System;
using System.ServiceModel;
using Wulka.Domain;

namespace Broobu.Authentication.Service.Interfaces
{
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    public interface IAuthenticationServiceExtension
    {
        /// <summary>
        /// Gets the name of the Service Authentication Extension.
        /// </summary>
        /// <value>The name of the service extension.</value>
        string Name { get; }


        /// <summary>
        /// Gets the type of the contract that is exposes by the service.
        /// </summary>
        /// <value>The type of the contract.</value>
        Type ContractType { get; }
    }
}