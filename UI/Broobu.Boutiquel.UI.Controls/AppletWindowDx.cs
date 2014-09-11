using System;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using ActiproSoftware.Windows.Controls.Ribbon;
using Broobu.Authorization.Contract.Domain;
using Broobu.Boutique.Contract;
using Broobu.Boutique.Contract.Agent;
using Broobu.Fx.UI;
using Broobu.Fx.UI.Controls;
using Broobu.Fx.UI.Interfaces;
using Broobu.Fx.UI.Verbs;
using Iris.Fx.Core;
using Iris.Fx.Domain;
using Iris.Fx.UI;

namespace Broobu.Boutique.UI.Controls
{
    /// <summary>
    /// Interaction logic for AppletWindowBase.xaml
    /// </summary>
    /// <remarks></remarks>
    public class AppletWindow : RibbonWindow, IPluginForm
    {

        /// <summary>
        /// 
        /// </summary>
        private ReleaseNotesWindow _rw;

        /// <summary>
        /// 
        /// </summary>
        private bool _isFirstTimeActive;


        /// <summary>
        /// Gets the rw.
        /// </summary>
        /// <remarks></remarks>
        public ReleaseNotesWindow Rw
        {
            get
            {
                if (_rw == null)
                {
                    _rw = new ReleaseNotesWindow();
                    _rw.Closed += (s, e) => _rw = null;
                }
                return _rw;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AppletWindow"/> class.
        /// </summary>
        /// <remarks></remarks>
        protected AppletWindow()
        {
            InitializeCommands();
            //this.WindowState = System.Windows.WindowState.Maximized;
            this.InputBindings.Add(new InputBinding(ShowReleaseNotesDoc, new KeyGesture(Key.F12)));
            Closed += new EventHandler(AppletWindowBaseClosed);
        }

        /// <summary>
        /// Handles the Closed event of the AppletWindowBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        void AppletWindowBaseClosed(object sender, EventArgs e)
        {
            Rw.Close();
        }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        /// <remarks></remarks>
        private void InitializeCommands()
        {
            ShowReleaseNotesDoc = new DelegateCommand(ShowReleaseNotes);
        }

        /// <summary>
        /// Shows the release notes.
        /// </summary>
        /// <remarks></remarks>
        private void ShowReleaseNotes()
        {
            var s = GetReleaseNotes();
            if (s == null) return;
            Rw.LoadReleaseNotes(s);
            if (Rw.IsVisible)
                Rw.Activate();
            Rw.Show();
        }

        /// <summary>
        /// Gets the release notes.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        protected Stream GetReleaseNotes()
        {
            Assembly asy = Assembly.GetAssembly(GetType());
            string[] st = asy.GetManifestResourceNames();
            var i = st.Length;
            return asy.GetManifestResourceStream(String.Format("{0}.releasenotes.txt", GetType().Namespace));
        }


        /// <summary>
        /// Gets or sets the show release notes doc.
        /// </summary>
        /// <value>The show release notes doc.</value>
        /// <remarks></remarks>
        public ICommand ShowReleaseNotesDoc { get; set; }

        /// <summary>
        /// Processes the verb.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ResponseInfo ProcessVerb(VerbInfo info)
        {
            var proc = CreateVerbProcessor(info);
            return proc != null ? proc.ProcessVerb(this, info) : null;
        }

        /// <summary>
        /// Creates the verb processor.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected virtual IVerbProcessor CreateVerbProcessor(VerbInfo info)
        {
            return null;
        }




        /// <summary>
        /// Gets or sets the plugin.
        /// </summary>
        /// <value>The plugin.</value>
        /// <remarks></remarks>
        public IPlugin Plugin { get; set; }



        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        /// <remarks></remarks>
        public IrisContext Arguments { get; set; }



        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Activated"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        /// <remarks></remarks>
        protected override void OnActivated(EventArgs e)
        {
            if (!_isFirstTimeActive)
            {
                _isFirstTimeActive = true;
                RegisterApplet(GetAppletInfo());
            }
            base.OnActivated(e);
        }

        /// <summary>
        /// Registers the applet.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <remarks></remarks>
        private void RegisterApplet(ApplicationFunction info)
        {
            if (info == null) return;
           BoutiquePortal
                .Boutique
                .RegisterAppletAsync(info,OnAppletRegistered);
        }

        /// <summary>
        /// Called when [applet registered].
        /// </summary>
        /// <param name="response">The response.</param>
        /// <remarks></remarks>
        public void OnAppletRegistered(ApplicationFunction response)
        {
        }

        /// <summary>
        /// Gets the applet info.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
       protected virtual ApplicationFunction GetAppletInfo()
        {
            return null;
        }
    }
}
