using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Broobu.Fx.UI.Controls;
using Broobu.Fx.UI.Deamons;
using Broobu.Fx.UI.Interfaces;
using Broobu.Fx.UI.Verbs;
using DevExpress.Mvvm;
using DevExpress.Xpf.Ribbon;
using Wulka.Core;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Interaction logic for AppletWindowBase.xaml
    /// </summary>
    /// <remarks></remarks>
    public class AppletWindow : DXRibbonWindow, IPluginForm
    {
        /// <summary>
        /// </summary>
        private ReleaseNotesWindow _rw;


        /// <summary>
        ///     Initializes a new instance of the <see cref="AppletWindow" /> class.
        /// </summary>
        /// <remarks></remarks>
        protected AppletWindow()
        {
            InitializeCommands();
            WindowState = WindowState.Maximized;
            InputBindings.Add(new InputBinding(ShowReleaseNotesDoc, new KeyGesture(Key.F12)));
            Closed += AppletWindowBaseClosed;
            Loaded += (s, e) => { ComSink.Instance.NotifyAppletLoaded(); };
        }

        /// <summary>
        ///     Gets the rw.
        /// </summary>
        /// <remarks></remarks>
        public ReleaseNotesWindow Rw
        {
            get
            {
                if (_rw != null) return _rw;
                _rw = new ReleaseNotesWindow();
                _rw.Closed += (s, e) => _rw = null;
                return _rw;
            }
        }

        /// <summary>
        ///     Gets or sets the show release notes doc.
        /// </summary>
        /// <value>The show release notes doc.</value>
        /// <remarks></remarks>
        public ICommand ShowReleaseNotesDoc { get; set; }

        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        /// <remarks></remarks>
        public WulkaContext Arguments { get; set; }

        /// <summary>
        ///     Processes the verb.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ResponseInfo ProcessVerb(VerbInfo info)
        {
            IVerbProcessor proc = CreateVerbProcessor(info);
            return proc != null ? proc.ProcessVerb(this, info) : null;
        }

        /// <summary>
        ///     Gets or sets the plugin.
        /// </summary>
        /// <value>The plugin.</value>
        /// <remarks></remarks>
        public IPlugin Plugin { get; set; }

        /// <summary>
        ///     Handles the Closed event of the AppletWindowBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        /// <remarks></remarks>
        private void AppletWindowBaseClosed(object sender, EventArgs e)
        {
            Rw.Close();
        }

        /// <summary>
        ///     Initializes the commands.
        /// </summary>
        /// <remarks></remarks>
        private void InitializeCommands()
        {
            ShowReleaseNotesDoc = new DelegateCommand(ShowReleaseNotes);
        }

        /// <summary>
        ///     Shows the release notes.
        /// </summary>
        /// <remarks></remarks>
        private void ShowReleaseNotes()
        {
            Stream s = GetReleaseNotes();
            if (s == null) return;
            Rw.LoadReleaseNotes(s);
            if (Rw.IsVisible)
                Rw.Activate();
            Rw.Show();
        }

        /// <summary>
        ///     Gets the release notes.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        protected Stream GetReleaseNotes()
        {
            Assembly asy = Assembly.GetAssembly(GetType());
            string[] st = asy.GetManifestResourceNames();
            int i = st.Length;
            return asy.GetManifestResourceStream(String.Format("{0}.releasenotes.txt", GetType().Namespace));
        }


        /// <summary>
        ///     Creates the verb processor.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected virtual IVerbProcessor CreateVerbProcessor(VerbInfo info)
        {
            return null;
        }
    }
}