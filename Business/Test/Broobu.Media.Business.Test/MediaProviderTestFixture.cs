using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Media.Business.Test
{
    [TestClass]
    public class MediaProviderTestFixture
    {
        [TestMethod]
        public void Try_RegisterEnumerations()
        {
            MediaProviderFactory
                .CreateEnumerationProvider()
                .RegisterRequiredDomainObjects();
        }
    }
}
