using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broobu.Components.AppFabric.Caching;

namespace TestAppfabricCache
{
    class Program
    {
        static void Main(string[] args)
        {
            CacheHelper helper = new CacheHelper("onlineservices", "test");
        }
    }
}
