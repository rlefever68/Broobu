using System;
using Wulka.Core;

namespace Broobu.Fx.UI.Deamons
{
    public class SetContextEventArgs : EventArgs
    {
        public WulkaContext Context { get; set; }
    }
}