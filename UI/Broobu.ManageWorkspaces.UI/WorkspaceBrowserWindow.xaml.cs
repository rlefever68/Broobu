using System.Diagnostics;
using System.Windows.Input;
using Pms.Framework.UI;
using Pms.Framework.UI.Interfaces;

namespace Pms.ManageWorkspaces.UI
{
    /// <summary>
    /// Interaction logic for WorkspaceBrowserWindow.xaml.
    /// </summary>
    public partial class WorkspaceBrowserWindow : IPluginForm
    {
        #region Properties

        /// <summary>
        /// Gets or sets the show read me.
        /// </summary>
        /// <value>The show read me.</value>
        public ICommand ShowReadMe { get; set; }

       #endregion

        #region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceBrowserWindow()
        {
            InitializeCommands();
            InitializeComponent();
            Loaded += (s, e) => WorkspaceBrowserStaticHelper.ApplyTheme();
            InputBindings.Add(new InputBinding(ShowReadMe, new KeyGesture(Key.F12)));
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            ShowReadMe = new DelegateCommand(() => Process.Start("readme.txt"));
        }

        #endregion

    }
}
