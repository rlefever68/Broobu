using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broobu.Disco.Business.Interfaces;
using Wulka.Data;
using Wulka.Domain;

namespace Broobu.Disco.Business.Providers
{
    class AppContracts : IAppContracts
    {
        public AppContract RegisterAppUsage(AppContract item)
        {
            return Provider<AppContract>.Save(item);
        }
    }
}
