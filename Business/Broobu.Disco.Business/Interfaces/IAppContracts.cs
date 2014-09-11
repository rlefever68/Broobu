using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wulka.Domain;
using Wulka.Interfaces;

namespace Broobu.Disco.Business.Interfaces
{
    public interface IAppContracts 
    {
        AppContract RegisterAppUsage(AppContract item);
    }
}
