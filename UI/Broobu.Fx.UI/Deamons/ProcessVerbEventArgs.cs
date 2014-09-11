using System;
using Broobu.Fx.UI.Verbs;

namespace Broobu.Fx.UI.Deamons
{
    public class ProcessVerbEventArgs : EventArgs
    {
        public VerbInfo VerbInfo { get; set; }
    }
}