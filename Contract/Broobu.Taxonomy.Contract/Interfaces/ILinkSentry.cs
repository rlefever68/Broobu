// ***********************************************************************
// Assembly         : Broobu.Media.Contract
// Author           : ON8RL
// Created          : 12-22-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="IRelation.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Collections.Generic;
using System.ServiceModel;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Base;
using Link = Broobu.Taxonomy.Contract.Domain.Link;

namespace Broobu.Taxonomy.Contract.Interfaces
{
   
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(Link))]
    [ServiceContract(Namespace = TaxonomyConst.Namespace)]
    public interface ILinkSentry 
    {
        [OperationContract]
        string Activate(string link);
        [OperationContract]
        string Deactivate(string link);
        [OperationContract]
        string[] GetTargets(string link, bool activeOnly = true);
        [OperationContract]
        string[] GetSources(string link, bool activeOnly = true);
    }
}
