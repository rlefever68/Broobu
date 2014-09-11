using Broobu.Fx.UI.Verbs;
using Wulka.Core;

namespace Broobu.Fx.UI.Interfaces
{
    public enum RunMode
    {
        Normal,
        Dialog
    }

    /// <summary>
    ///     Exposes the Interface for the Application that hosts the plugins
    /// </summary>
    /// <remarks></remarks>
    public interface IPluginHost
    {
        //    /// <summary>
        //    /// Executes the applet.
        //    /// </summary>
        //    /// <param name="tag">The tag.</param>
        //    /// <param name="mode"></param>
        //    /// <remarks></remarks>
        //    void ExecuteApplet(object tag, RunMode mode=RunMode.Normal);


        /// <summary>
        ///     Broadcasts the specified verb info to the active plugins.
        ///     Any Plugins that respond to the message will return their info in the result array.
        /// </summary>
        /// <param name="verbInfo">The verb info.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        void Broadcast(VerbInfo verbInfo);

        /// <summary>
        ///     Gets the shell context.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        WulkaContext GetShellContext();


        ///// <summary>
        ///// Return the resource dictionary embedded in the host application
        ///// </summary>
        ///// <param name="resourceFileName">Name of the resource file.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //ResourceDictionary GetResourceDictionary(string resourceFileName);

        /// <summary>
        ///     Unloads the plugin.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks></remarks>
        void UnloadPlugin(string id);
    }
}