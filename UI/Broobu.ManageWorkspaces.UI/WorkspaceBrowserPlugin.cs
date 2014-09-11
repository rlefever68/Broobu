using System;
using Pms.Framework.UI.Interfaces;
using Pms.Framework.UI;

namespace Pms.ManageWorkspaces.UI
{
    public class WorkspaceBrowserPlugin :PluginBase
    {
        protected override IPluginForm CreatePluginFormInternal()
        {
            return new WorkspaceBrowserWindow();
        }
    }
}
