using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using Broobu.Boutique.UI.Controls.Interfaces;
using Broobu.Components.DevExpress;
using Broobu.Fx.UI;
using Broobu.Fx.UI.Deamons;
using Broobu.Fx.UI.Interfaces;

namespace Broobu.Desktop.UI
{
    class LauncherHost : AppletHost
    {
        private readonly IHostForm _shellForm;
        /// <summary>
        /// Initializes a new instance of the <see cref="LauncherHost"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public LauncherHost(IHostForm form)
        {
            _shellForm = form;
        }



 
        internal void PreloadAssemblies()
        {
            DevExpressLibraryPreloader.PreLoadCarousel();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadChart();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadFlowLayout();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadGrid();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadNavBar();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadPivot();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadPrinting();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadRibbon();
            App.DoEvents();


        }

        public void SendAppletShellContexts()
        {
            //foreach (KeyValuePair<string, string> pair in _runningApps)
            //{
            //    DeamonHelper.SendContextToApplet(_shellContext,pair.Key);
            //}
        }

    }
}
