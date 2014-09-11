using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pms.Explorer.Business.Test
{
    [TestClass]
    public class ExplorerBuisinessTestFixture
    {
        [TestMethod]
        public void Try_Generate()
        {
            ExplorerBusinessGenerator.Generate();
        }
    }
}
