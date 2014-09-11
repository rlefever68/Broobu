using System;
using Pms.Framework.UI;

namespace Pms.WorkspaceBrowser.UI.Controls
{
 public abstract class WorkspaceBrowserViewModelBase:ViewModelBase,IDisposable
    {
      public ApplicationEvents EventBroker
        {
            get
            {
                return ApplicationEvents.Instance;
            }
        }

      public void Dispose() { }
    }
}
