using System;

namespace Broobu.Fx.UI.Deamons
{
    public class AppletEventArgs : EventArgs
    {
        public string Id { get; set; }
        public string AppletName { get; set; }
    }
}