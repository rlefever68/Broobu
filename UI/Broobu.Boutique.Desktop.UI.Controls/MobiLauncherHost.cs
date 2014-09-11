using System.Windows.Forms;
using Pms.Shell.Agent;
using Pms.Shell.Agent.Interfaces;
using Pms.Shell.UI;

namespace Pms.MobiLauncher.UI.Controls
{
    class MobiGuiderHost : PluginHostBase
    {

        private const string ShellAgentKey = ShellAgentFactory.Key.Mock;

        public class DefaultUser
        {
            public const string UserName = "default";
            public const string Password = "default";
        }


        private IShellAgent _agent;
        private IShellAgent Agent
        {
            get { return _agent ?? (_agent = CreateShellAgent()); }
        }

        

        



        private static  IHostForm _shellForm;
        
        


        //  readonly DiscoveryViewModel _vm = new DiscoveryViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="MobiGuiderHost"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public MobiGuiderHost(ApplicationContext ctx)
        {
            if(_shellForm==null) return;
            _shellForm.Load += (s, e) => LoginDefaultUser();
            _shellForm.OnAppletItemClicked += (s, e) => ExecuteApplet(e.Tag);
        }

       


        /// <summary>
        /// Creates the shell agent.
        /// </summary>
        /// <returns></returns>
        private static IShellAgent CreateShellAgent()
        {
            var agt = ShellAgentFactory.CreateAgent(ShellAgentKey);
            agt.OnLoginUserCompleted += (snd, e) => _shellForm.ConfigureForUser(e.Info);
            return agt;
        }


        /// <summary>
        /// Logins the default user.
        /// </summary>
        protected override void LoginDefaultUserInternal()
        {
            Agent.LoginUserAsync(DefaultUser.UserName, DefaultUser.Password);
        }

       
    }
}
