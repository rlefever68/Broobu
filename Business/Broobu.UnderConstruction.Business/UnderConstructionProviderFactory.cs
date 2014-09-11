using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.UnderConstruction.Business.Interfaces;

namespace Pms.UnderConstruction.Business
{
    public class UnderConstructionProviderFactory
    {
        public class Key
        {
            public const string Mock = "Mock";
            public const string RealTime = "RealTime";
        }



        public static IUnderConstructionProvider CreateProvider(string key)
        {
            switch(key)
            {
                case Key.RealTime:
                    return new UnderConstructionProvider();
                default:
                    return new UnderConstructionMockProvider();
            }
        }




    }




}
