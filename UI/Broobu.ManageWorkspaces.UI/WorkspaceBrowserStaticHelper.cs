using System;
using System.Windows;

namespace Pms.ManageWorkspaces.UI
{
    public static class WorkspaceBrowserStaticHelper
    {
        /// <summary>
        /// Loads the Theme from Resouces Assembly and applies to UI.
        /// </summary>
        public static void ApplyTheme()
        {
          //  var d = WorkspaceBrowserResource.GetResourceDictionary();
          //  if (d != null) Application.Current.Resources = d;
          Application.Current.Resources = (ResourceDictionary)Application.LoadComponent(new Uri("CommonThemes.xaml", UriKind.Relative));
        }
    }
}
