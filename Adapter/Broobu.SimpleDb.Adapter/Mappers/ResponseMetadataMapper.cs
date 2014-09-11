using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter.Mappers
{
    public static class ResponseMetadataMapper 
    {
        public static ResponseMetadata MapToService(ResponseMetadataInfo info)
        {
            return new ResponseMetadata() { BoxUsage = info.BoxUsage, RequestId = info.RequestId };
        }

        public static ResponseMetadataInfo MapToInfo(ResponseMetadata data)
        {
            return new ResponseMetadataInfo() { BoxUsage = data.BoxUsage, RequestId = data.RequestId };
        }
    }



}
