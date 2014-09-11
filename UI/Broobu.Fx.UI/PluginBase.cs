using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using Broobu.Fx.UI.Dialogs;
using Broobu.Fx.UI.Interfaces;
using Broobu.Fx.UI.Verbs;
using Iris.Fx.Core;
using Application = System.Windows.Application;

namespace Broobu.Fx.UI
{
    /// <summary>
    /// </summary>
    /// <remarks></remarks>
    public abstract class PluginBase : IPlugin
    {
        /// <summary>
        /// </summary>
        private readonly Dictionary<string, Assembly> _assemblies = new Dictionary<string, Assembly>();

        /// <summary>
        /// </summary>
        private IPluginForm _form;

        /// <summary>
        ///     Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        /// <remarks></remarks>
        public IPluginHost Host { get; set; }

        /// <summary>
        ///     Gets the host context.
        /// </summary>
        /// <remarks></remarks>
        protected IrisContext HostContext
        {
            //get
            //{
            //    return Host == null ? null : Host.GetShellContext(this);
            //}
            get { return IrisContext.Current; }
        }


        public string HomeDir { get; set; }

        /// <summary>
        ///     Gets the assemblies.
        /// </summary>
        /// <remarks></remarks>
        protected Dictionary<string, Assembly> Assemblies
        {
            get { return _assemblies; }
        }

        /// <summary>
        ///     Gets the plugin form.
        /// </summary>
        /// <value>The plugin form.</value>
        /// <remarks></remarks>
        protected IPluginForm PluginForm
        {
            get { return _form ?? (_form = CreatePluginForm()); }
        }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        /// <remarks></remarks>
        public string Id { get; set; }

        public void ProcessVerb(VerbInfo verbInfo)
        {
            //return PluginForm != null ? PluginForm.ProcessVerb(verbInfo) : null;
        }

        /// <summary>
        ///     Terminates this instance.
        /// </summary>
        /// <remarks></remarks>
        public void Terminate()
        {
            PluginForm.Close();
            Host.UnloadPlugin(Id);
            Host = null;
        }

        public void SendShellContext(IrisContext context)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Runs the specified plugin host.
        /// </summary>
        /// <param name="pluginHost">The plugin host.</param>
        /// <remarks></remarks>
        public void Run(IPluginHost pluginHost, RunMode mode)
        {
            Host = pluginHost;
            Run(mode);
        }


        /// <summary>
        ///     Creates the plugin form internal.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        protected abstract IPluginForm CreatePluginFormInternal();

        /// <summary>
        ///     Creates the plugin form.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private IPluginForm CreatePluginForm()
        {
            IPluginForm f = CreatePluginFormInternal();
            //f.Plugin = this;
            ApplyThemes();
            //f.Closed += (s, e) =>
            //{
            //    _form = null;
            //};
            return f;
        }


        /// <summary>
        ///     Applies the themes.
        /// </summary>
        /// <remarks></remarks>
        private void ApplyThemes()
        {
            Application.Current.Resources = GetHostResourceDictionary("commonthemes.xaml");
        }


        /// <summary>
        ///     Runs this instance.
        /// </summary>
        /// <remarks></remarks>
        public virtual void Run(RunMode mode)
        {
            if (_form == null)
                _form = CreatePluginForm();
            if (_form is Window)
            {
                if (mode == RunMode.Normal)
                    ((Window) _form).Show();
                else
                    ((Window) _form).ShowDialog();
                ((Window) _form).Activate();
            }
            if ((_form is Form))
            {
                if (mode == RunMode.Normal)
                    ((Form) _form).Show();
                else
                    ((Form) _form).ShowDialog();
                ((Form) _form).Activate();
            }
            PleaseWaitDialog.Close();
        }


        public void Broadcast(VerbInfo nfo)
        {
            //return Host != null ? Host.Broadcast(nfo) : null;
        }


        /// <summary>
        ///     Gets the host resource dictionary.
        /// </summary>
        /// <param name="resourceFileName">Name of the resource file.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ResourceDictionary GetHostResourceDictionary(string resourceFileName)
        {
            return Host != null ? Host.GetResourceDictionary(resourceFileName) : new ResourceDictionary();
        }
    }
}