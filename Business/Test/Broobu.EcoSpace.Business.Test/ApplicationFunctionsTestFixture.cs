using System;
using Broobu.Authorization.Business.Interfaces;
using Broobu.Authorization.Contract.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authorization.Business.Test
{
    [TestClass]
    public class ApplicationFunctionsTestFixture : IApplicationFunctions
    {
        public ApplicationFunction GetAppletInfo(string id)
        {
            throw new NotImplementedException();
        }

        public ApplicationFunction[] GetAllApplicationFunctions()
        {
            throw new NotImplementedException();
        }

        public ApplicationFunction[] SaveApplicationFunctions(ApplicationFunction[] applicationFunctionViewItems)
        {
            throw new NotImplementedException();
        }

        public ApplicationFunction[] DeleteApplicationFunctions(ApplicationFunction[] applicationFunctionViewItems)
        {
            throw new NotImplementedException();
        }

        public ApplicationFunction[] GetMenuForUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void RegisterRequiredDomainObjects()
        {
            throw new NotImplementedException();
        }

        public ApplicationFunction RootFolder { get; private set; }
        public ApplicationFunction UnRegisteredFolder { get; private set; }
        public ApplicationFunction CommunityFolder { get; private set; }
    }
}
