using System;
using Pms.Framework.UI;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
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
