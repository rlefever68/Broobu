using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Broobu.Publisher.Contract.Domain;

namespace Broobu.Publisher.Contract.Interfaces
{

    public interface IPublish
    {
        PublishInfo Publish(PublishInfo info);
    }
}
