using System;
using System.Windows.Forms;
using Broobu.Boutique.Contract.Domain;
using Broobu.Fx.UI.Interfaces;

namespace Broobu.Desktop.UI
{
    public class MenuBuilder
    {
        public static void Build(MenuItem root, BoutiqueMenuInfo[]  items, Action<object, RunMode> executeApplet)
        {
            root.MenuItems.Clear();
            //_appletItemClicked = executeApplet;
            if (items == null) return;
            foreach (var it in items)
            {
                var mi = root.MenuItems.Add(it.Title);
                mi.Tag = it.PluginUrl;
                if (it.Items==null)
                    mi.Click += (s, e) => executeApplet(mi.Tag, RunMode.Normal);
                Build(mi, it.Items, executeApplet);
            }
        }

    }
}
