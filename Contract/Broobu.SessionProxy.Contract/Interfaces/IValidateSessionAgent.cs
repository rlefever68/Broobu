using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pms.SessionProxy.Contract.Interfaces
{
    public interface IValidateSessionAgent : IValidateSession
    {
        void ValidateAsync(string userName, string sessionId);
        event Action<bool> ValidateCompleted;
    }
}
