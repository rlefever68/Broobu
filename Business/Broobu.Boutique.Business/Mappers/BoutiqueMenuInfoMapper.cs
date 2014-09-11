using System;
using System.Collections.Generic;
//using Broobu.Authorization.Contract.Domain;
using Broobu.Boutique.Contract.Domain;
using Wulka.Domain;
using Wulka.Interfaces;

namespace Broobu.Boutique.Business.Mappers
{
    public static class BoutiqueMenuInfoMapper 
    {

        ///// <summary>
        ///// Maps from business to service.
        ///// </summary>
        ///// <param name="et">The et.</param>
        ///// <returns></returns>
        //public static BoutiqueMenuInfo ToBoutiqueMenuInfo(this ApplicationFunction et)
        //{
        //    return new BoutiqueMenuInfo 
        //    { 
        //        Icon = et.Icon, 
        //        Id = et.Id, 
        //        Order = Convert.ToInt32(et.Order), 
        //        PluginUrl = et.PluginUrl, 
        //        ServiceUrl = et.ServiceUrl, 
        //        SessionId = et.SessionId, 
        //        Title = et.Title, 
        //        ToolTip = et.ToolTip,
        //        ParentId = et.ParentId
        //    };
        //}

        ///// <summary>
        ///// Maps from business to service.
        ///// ApplicationFunctionItems are received as a flat list; converted to tree structure in BoutiqueMenuInfo.
        ///// </summary>
        ///// <param name="entities">The business entity.</param>
        ///// <returns></returns>
        //public static BoutiqueMenuInfo[] ToBoutiqueMenuInfos(this ApplicationFunction[] entities)
        //{
        //    return entities
        //        .Select(x => x.ToBoutiqueMenuInfo())
        //        .ToArray();
        //}

    }
}
