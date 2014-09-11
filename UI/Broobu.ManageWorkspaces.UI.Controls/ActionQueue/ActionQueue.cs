using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pms.ManageWorkspaces.UI.Controls
{
    public class ActionQueue
    {

        #region "Fields / Members"
        public static ActionQueue Instance { get; set; }
        internal Queue Actions { get; set; }
        #endregion

        #region "Constructor"

        static ActionQueue()
        {
            Instance = new ActionQueue();
        }
        private ActionQueue()
        {
            Actions = new Queue();
        }

        #endregion

        #region "Public Methods"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public static void AddQueue(QueableAction action)
        {
            if (action.EventBroker != null)
                action.EventBroker.RaiseStartRefresh();
            Instance.Actions.Enqueue(action);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void DeQueue()
        {
            var count = Instance.Actions.Count;
            if (count > 0)
            {
                var dequeue = (QueableAction)Instance.Actions.Dequeue();
                    //Delegate act as an intermediary between an event source and an event destination
            }
        }
        #endregion

        public class QueableAction
        {
            public Guid SenderId { get; set; }
            public ApplicationEvents EventBroker { get; set; }
        }
    }
}
