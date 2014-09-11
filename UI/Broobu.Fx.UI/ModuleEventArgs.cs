using System;
using System.Reflection;

namespace Broobu.Fx.UI
{
    public class ModuleEventArgs : EventArgs
    {
        public ModuleEventArgs(string name, Module mod)
        {
            Name = name;
            Module = mod;
        }

        public string Name { get; set; }
        public Module Module { get; set; }
    }
}