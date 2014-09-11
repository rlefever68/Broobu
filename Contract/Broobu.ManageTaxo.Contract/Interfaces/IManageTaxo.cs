using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.ManageTaxo.Contract.Interfaces
{
    [ServiceContract(Namespace = ManageTaxoServiceConst.Namespace)]
    [ServiceKnownType(typeof(Hook))]
    public interface IManageTaxo
    {
        [OperationContract]
        DescriptionItem[] GetTranslationsForObject(HookItem filter);

        [OperationContract]
        DescriptionItem[] GetDescriptionTypes();

        [OperationContract]
        Description SaveDescription(Description document);

        [OperationContract]
        Description DeleteDescription(Description document);

        [OperationContract]
        HookItem[] GetHookItems(HookItem root);

        [OperationContract]
        Hook SaveHook(Hook document);

        [OperationContract]
        Hook DeleteHook(Hook document);


        [OperationContract]
        Hook GetHook(string id);

        [OperationContract]
        Description GetDescription(DescriptionItem item);


    }
}
