using System;
using Pms.ManageWorkspaces.Contract.Interfaces;


namespace Pms.ManageWorkspaces.Contract.Agent
{
    public class WorkspaceBrowserAgentFactory
    {

        public class Key
        {
            public const string Instance = "Instance";
            public const string Mock = "Mock";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IWorkspaceBrowserAgent CreateAgent(string key)
        {
            return new WorkspaceBrowserAgent();
        }

    }
}
