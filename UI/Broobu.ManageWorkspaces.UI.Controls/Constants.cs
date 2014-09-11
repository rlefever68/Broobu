using System;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Resources;

namespace Pms.ManageWorkspaces.UI.Controls
{
    public static class Constants
    {
        public const string ProjectTitle = "Workspace Browser";
        public const string Root = "ROOT";
        public const string WorkspaceItem = "WorkspaceItem";

        public static class ViewNames
        {
            public const string ModifyItem = "Modify Item";
            public const string AddItem = "Add Item";
            public const string ModifyDesc = "Modify Description";
            public const string ModifyProperty = "Modify Property";
            public const string SearchText = "Search Libraries";

            public const string DescriptionWindow = "DescriptionWindow";
            public const string PopuUpListView = "PopuUpListView";

        }
        public static class CreateAgentKey
        {
            public const string Key = WorkspaceBrowserAgentFactory.Key.Mock;
            //public const string Key = WorkspaceBrowserAgentFactory.Key.Instance;
        }
        public static class CommandParameter
        {
            public const string NewItem = "NewItem";
            public const string ListViewItemDelete = "ListViewItemDelete";
            public const string Refresh = "Refresh";
            public const string NewFolder = "NewFolder";
        }

        /// <summary>
        /// Gets the embedded file.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Byte[]</returns>
        public static Byte[] GetEmbeddedFile(string assemblyName, string fileName)
        {
            var r = new WorkspaceBrowserResource();
            return r.GetEmbeddedFile(assemblyName, fileName);
        }

    }
}
