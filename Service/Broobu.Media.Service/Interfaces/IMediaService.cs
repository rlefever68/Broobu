using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Pms.Framework.Domain;
using Pms.WorkspaceBrowser.Contract.Domain;

namespace Pms.Media.Service.Interfaces
{
    [ServiceContract]
    public interface IMediaService
    {
        [OperationContract]
        String RegisterDescription(WorkspaceItemDescription workspaceItemDescription);
    }
}
