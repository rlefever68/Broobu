using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.Framework.Domain;

namespace Pms.MobiLauncher.UI.Controls.Interfaces
{
    public interface ILoginWindow
    {
        PMSAuthRequest Request { get; set; }
        PMSSession Session { get; set; }
        bool? ShowDialog();
    }
}
