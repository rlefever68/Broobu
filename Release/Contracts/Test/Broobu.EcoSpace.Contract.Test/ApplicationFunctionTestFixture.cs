using System;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Test;

namespace Broobu.EcoSpace.Contract.Test
{
    [TestClass]
    public class ApplicationFunctionTestFixture : ServiceTestFixtureBase
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        protected override string GetContractType()
        {
            return String.Format("{0}:IEcoSpaceSentry", EcoSpaceConst.Namespace);
        }
    }
}
