using System;
using Iris.Fx.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;

namespace Iris.Fx.Test
{
    [TestClass]
    public class LoggingTestFixture
    {

        [TestMethod]
        public void Try_BasicLogging()
        {
            Logger logger = LogManager.GetLogger("foo");
            logger.Info("Program started"); 
        }


        [TestMethod]
        public void Try_DebugLogging()
        {
            FxLog<DomainTestFixture>.DebugFormat("I am writing a Debug Log Message");
        }



        [TestMethod]
        public void Try_WarningLogging()
        {
            FxLog<DomainTestFixture>.WarnFormat("This is a Warning message.");
        }


        [TestMethod]
        public void Try_InfoLogging()
        {
            FxLog<DomainTestFixture>.InfoFormat("This is an Info message.");
        }


        [TestMethod]
        public void Try_ErrorLogging()
        {
            FxLog<DomainTestFixture>.ErrorFormat("This an Error Message.");
        }


    }
}
