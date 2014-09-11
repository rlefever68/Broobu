// Utility code shared by the host and the add-in. For convenience, placed in the add-in assembly,
// which the host references anyway (for the add-in interface). In a real solution, it's a good idea
// to place this stuff in a separate assembly, in particular in order to limit the add-in type 
// injection into the host process. (That's generally a problem for security.)

using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization.Formatters;

namespace AddIn
{
    public static class IpcUtils
    {
        public static IpcServerChannel RegisterServerChannel(string baseServerName)
        {
            var provider = new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full};
            var channel = new IpcServerChannel(null, baseServerName+"-"+Process.GetCurrentProcess().Id, provider);
            ChannelServices.RegisterChannel(channel, false);
            return channel;
        }
    };
}