using System;
using Broobu.Taxonomy.Business.Interfaces;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authorization.Business.Test
{
    [TestClass]
    public class SettingsTestFixture:ISettings
    {
        public Setting SaveSettings(Setting item)
        {
            throw new NotImplementedException();
        }

        public Setting GetSettings(Setting request)
        {
            throw new NotImplementedException();
        }

        public Setting GetSetting(string id)
        {
            throw new NotImplementedException();
        }

        public void RegisterRequiredDomainObjects()
        {
            throw new NotImplementedException();
        }
    }
}
