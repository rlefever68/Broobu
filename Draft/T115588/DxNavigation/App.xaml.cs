using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;
using System.IO;
using System.Reflection;
using DevExpress.Mvvm.UI;

namespace DxNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AssemblyHelper.PreLoadDeployedAssemblies();
            ViewLocator.Default = new ViewLocator(AppDomain.CurrentDomain.GetAssemblies());
        }

        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
        }
    }
    public class AssemblyHelper {
        private static IEnumerable<string> GetBinFolders() {
            List<string> toReturn = new List<string>();
            toReturn.Add(AppDomain.CurrentDomain.BaseDirectory);
            return toReturn;
        }

        public static void PreLoadDeployedAssemblies() {
            foreach(var path in GetBinFolders()) {
                PreLoadAssembliesFromPath(path);
            }
        }

        private static void PreLoadAssembliesFromPath(string p) {
            FileInfo[] files = null;
            files = new DirectoryInfo(p).GetFiles("*.dll",
                SearchOption.AllDirectories);
            AssemblyName a = null;
            string s = null;
            foreach(var fi in files) {
                s = fi.FullName;
                a = AssemblyName.GetAssemblyName(s);
                if(!AppDomain.CurrentDomain.GetAssemblies().Any(assembly =>
                  AssemblyName.ReferenceMatchesDefinition(a, assembly.GetName()))) {
                    Assembly.Load(a);
                }
            }
        }
    }
}
