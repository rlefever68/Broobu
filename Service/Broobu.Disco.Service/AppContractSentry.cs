using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Broobu.Disco.Business;
using Wulka.Domain;
using Wulka.Extensions;
using Wulka.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.Disco.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class AppContractSentry : SentryBase, IAppContractSentry
    {
        protected override void RegisterRequiredDomainObjects()
        {
        }

        public string RegisterAppUsage(string item)
        {
            return DiscoProvider
                .AppContracts
                .RegisterAppUsage(item.Unzip<AppContract>())
                .Zip();
        }
    }
}
