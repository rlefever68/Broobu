using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authentication.UI.Controls.Test
{
    [TestClass]
    public class AuthenticationTestFixture
    {
        [TestMethod]
        public void Try_AuthenticationHost()
        {
            AuthenticationHost.StartNativeSessionAsync(() => { });
        }
    }
}
