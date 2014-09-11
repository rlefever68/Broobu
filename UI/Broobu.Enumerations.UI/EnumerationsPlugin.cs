using System;
using Pms.Framework.UI.Interfaces;
using Pms.Framework.UI;

namespace Pms.Enumerations.UI
{
    public class EnumerationsPlugin : PluginBase
    {
        protected override IPluginForm CreatePluginFormInternal()
        {
            return new EnumerationsWindow();
        }
    }
}
