using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.Communication.Business.Interfaces;

namespace Pms.Communication.Business
{
    public class CommunicationProviderFactory
    {



        public class Key
        {
            public const string Instance = "Instance";
            public const string Mock = "Mock";
            public const string EMail = "Email";
            public const string SnailMail = "SnailMail";
            public const string SMS = "SMS";
            public const string Media = "Media";
            public const string Gateway = "Gateway";
            public const string Queue = "Queue";
            public const string BMR = "BMR";
        }




        public ICommunicationProvider CreateProvider(string key)
        {
            throw new NotImplementedException();
        }
    }
}
