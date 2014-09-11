using System;
using Broobu.Fx.UI.Verbs;

namespace Broobu.Fx.UI.Interfaces
{
    public interface IPluginForm
    {
        IPlugin Plugin { get; set; }
        void Show();
        event EventHandler Closed;
        void Close();
        void BringIntoView();
        ResponseInfo ProcessVerb(VerbInfo info);
    }
}