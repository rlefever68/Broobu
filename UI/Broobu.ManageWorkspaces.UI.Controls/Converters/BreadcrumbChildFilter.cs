using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;

namespace Pms.ManageWorkspaces.UI.Controls.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class BreadcrumbChildFilter : IValueConverter
    {
        public static WorkspaceItem[] workspaceitems;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var item = Agent.GetWorkspace((string)value);
            if (item == null) return null;
            Mouse.OverrideCursor = null;
            return value != null ? item.Where(selecteditem => (selecteditem.Children != null) && (selecteditem.Children.Count() > 0)).ToList() : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the agent.
        /// </summary>
        /// <value>The agent.</value>
        private IWorkspaceBrowserAgent _agent;
        private IWorkspaceBrowserAgent Agent
        {
            get { return _agent ?? (_agent = WorkspaceBrowserAgentFactory.CreateAgent(Constants.CreateAgentKey.Key)); }
        }

    }
}
