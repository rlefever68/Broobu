using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.WorkspaceBrowser.Contract.Domain;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    public class WorkspaceDetailViewViewModel:WorkspaceBrowserViewModelBase
    {
        #region Property

        /// <summary>
        /// Declare Constants
        /// </summary>
        public new class Property
        {
            public const string ListItem = "ListItem";
        }

        #endregion

        #region Constructor Declaration
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public WorkspaceDetailViewViewModel()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            EventBroker.LoadDetailView += (snd, e) => ListItem = e.ListItem;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets ListItem Data
        /// </summary>
        private IEnumerable<WorkspaceItem> _listItem;
        public IEnumerable<WorkspaceItem> ListItem
        {
            get
            {
                return _listItem;
            }
            set
            {
                _listItem = value;

                RaisePropertyChanged(Property.ListItem);

            }
        }

        #endregion

    }
}
