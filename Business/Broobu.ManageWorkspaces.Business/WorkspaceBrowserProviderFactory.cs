using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.ManageWorkspaces.Business.Interfaces;

namespace Pms.ManageWorkspaces.Business
{
    public class WorkspaceBrowserProviderFactory
    {

        public class Key
        {
            public const string Instance = "Instance";
            public const string Mock = "Mock";
        }

        public static IWorkspaceBrowserProvider CreateProvider(string key)
        {

            switch (key)
            {
                case Key.Instance:
                    return new WorkspaceBrowserProvider();
                case Key.Mock:
                default:
                    return new WorkspaceBrowserMockProvider();
            }
        }
    }
}
